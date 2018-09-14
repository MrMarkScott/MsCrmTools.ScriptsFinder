﻿using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Metadata.Query;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml;

namespace MsCrmTools.ScriptsFinder
{
    public class ScriptsManager
    {
        private readonly IOrganizationService service;
        private readonly BackgroundWorker worker;
        private List<EntityMetadata> emds;
        private int userLcid;

        public ScriptsManager(IOrganizationService service, BackgroundWorker worker)
        {
            this.service = service;
            this.worker = worker;
            Scripts = new List<Script>();
        }

        public List<Script> Scripts { get; }

        public void Find(List<Entity> solutions, Version crmVersion)
        {
            worker.ReportProgress(0, "Loading User language...");
            GetCurrentUserLcid();

            worker.ReportProgress(0, "Loading Entities metadata...");
            emds = GetEntities(solutions);

            worker.ReportProgress(0, "Loading Scripts...");
            foreach (var emd in emds.Where(x => x.DisplayName.UserLocalizedLabel != null))
            {
                LoadScripts(emd);
                LoadRibbonCommands(emd);

                // Grid events are only available since CRM 8.2
                if (crmVersion >= new Version(8, 2, 0, 0))
                {
                    LoadCustomControls(emd);
                }
            }

            LoadRibbonCustomRule();
        }

        private void GetCurrentUserLcid()
        {
            var user = (WhoAmIResponse)service.Execute(new WhoAmIRequest());

            var userSettings = service.RetrieveMultiple(new QueryByAttribute("usersettings")
            {
                Attributes = { "systemuserid" },
                Values = { user.UserId },
            }).Entities.First();

            userLcid = userSettings.GetAttributeValue<int>("uilanguageid");
        }

        private List<EntityMetadata> GetEntities(List<Entity> solutions)
        {
            if (solutions.Count > 0)
            {
                var components = service.RetrieveMultiple(new QueryExpression("solutioncomponent")
                {
                    ColumnSet = new ColumnSet("objectid"),
                    NoLock = true,
                    Criteria = new FilterExpression
                    {
                        Conditions =
                        {
                            new ConditionExpression("solutionid", ConditionOperator.In,
                                solutions.Select(s => s.Id).ToArray()),
                            new ConditionExpression("componenttype", ConditionOperator.Equal, 1)
                        }
                    }
                }).Entities;

                var list = components.Select(component => component.GetAttributeValue<Guid>("objectid"))
                    .ToList();

                if (list.Count > 0)
                {
                    EntityQueryExpression entityQueryExpression = new EntityQueryExpression
                    {
                        Criteria = new MetadataFilterExpression(LogicalOperator.Or),
                        Properties = new MetadataPropertiesExpression
                        {
                            AllProperties = false,
                            PropertyNames = { "DisplayName", "LogicalName", "Attributes", "ObjectTypeCode" }
                        },
                        AttributeQuery = new AttributeQueryExpression
                        {
                            // Récupération de l'attribut spécifié
                            Properties = new MetadataPropertiesExpression
                            {
                                AllProperties = false,
                                PropertyNames = { "DisplayName", "LogicalName" }
                            }
                        }
                    };

                    list.ForEach(id =>
                    {
                        entityQueryExpression.Criteria.Conditions.Add(new MetadataConditionExpression("MetadataId", MetadataConditionOperator.Equals, id));
                    });

                    RetrieveMetadataChangesRequest retrieveMetadataChangesRequest = new RetrieveMetadataChangesRequest
                    {
                        Query = entityQueryExpression,
                        ClientVersionStamp = null
                    };

                    var response = (RetrieveMetadataChangesResponse)service.Execute(retrieveMetadataChangesRequest);

                    return response.EntityMetadata.ToList();
                }

                return new List<EntityMetadata>();
            }
            else
            {
                EntityQueryExpression entityQueryExpression = new EntityQueryExpression
                {
                    Criteria = new MetadataFilterExpression(LogicalOperator.Or)
                    {
                        Conditions =
                        {
                            new MetadataConditionExpression("IsCustomizable", MetadataConditionOperator.Equals, true),
                            new MetadataConditionExpression("IsManaged", MetadataConditionOperator.Equals, false),
                        }
                    },
                    Properties = new MetadataPropertiesExpression
                    {
                        AllProperties = false,
                        PropertyNames = { "DisplayName", "LogicalName", "Attributes", "ObjectTypeCode" }
                    },
                    AttributeQuery = new AttributeQueryExpression
                    {
                        // Récupération de l'attribut spécifié
                        Properties = new MetadataPropertiesExpression
                        {
                            AllProperties = false,
                            PropertyNames = { "DisplayName", "LogicalName" }
                        }
                    }
                };

                RetrieveMetadataChangesRequest retrieveMetadataChangesRequest = new RetrieveMetadataChangesRequest
                {
                    Query = entityQueryExpression,
                    ClientVersionStamp = null
                };

                var response = (RetrieveMetadataChangesResponse)service.Execute(retrieveMetadataChangesRequest);

                return response.EntityMetadata.ToList();
            }
        }

        private void LoadCustomControls(EntityMetadata emd)
        {
            var ccs = service.RetrieveMultiple(new QueryExpression("customcontroldefaultconfig")
            {
                ColumnSet = new ColumnSet("eventsxml"),
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("primaryentitytypecode", ConditionOperator.Equal, emd.ObjectTypeCode.Value),
                        new ConditionExpression("eventsxml", ConditionOperator.NotNull)
                    }
                }
            });

            foreach (var cc in ccs.Entities)
            {
                var doc = new XmlDocument();
                doc.LoadXml(cc.GetAttributeValue<string>("eventsxml"));

                foreach (XmlNode eventNode in doc.SelectNodes("//event"))
                {
                    string eventName = eventNode.Attributes["name"].Value;

                    foreach (XmlNode handlerNode in eventNode.SelectNodes("Handlers/Handler"))
                    {
                        var script = new Script();
                        script.EntityLogicalName = emd.LogicalName;
                        script.EntityName = emd.DisplayName.UserLocalizedLabel.Label;
                        script.ScriptLocation = handlerNode.Attributes["libraryName"].Value;
                        script.MethodCalled = handlerNode.Attributes["functionName"].Value;
                        script.IsActive = handlerNode.Attributes["enabled"].Value == "true";
                        script.PassExecutionContext = handlerNode.Attributes["passExecutionContext"]?.Value == "true";
                        script.Event = eventName;
                        script.Arguments = handlerNode.Attributes["parameters"] != null ? handlerNode.Attributes["parameters"].Value : "";
                        script.Type = "Homepage Grid event";

                        if (eventName == "onchange")
                        {
                            var amd = emd.Attributes.FirstOrDefault(x => x.LogicalName == eventNode.Attributes["attribute"].Value);

                            if (amd != null)
                            {
                                var displayName = amd.DisplayName != null && amd.DisplayName.UserLocalizedLabel != null
                                    ? amd.DisplayName.UserLocalizedLabel.Label
                                    : "(" + amd.LogicalName + ")";

                                script.Attribute = displayName;
                                script.AttributeLogicalName = amd.LogicalName;
                            }
                        }
                        else
                        {
                            script.Attribute = "";
                            script.AttributeLogicalName = "";
                        }

                        Scripts.Add(script);
                    }
                }

                foreach (XmlNode libraryNode in doc.SelectNodes("//Library"))
                {
                    var script = new Script();
                    script.EntityLogicalName = emd.LogicalName;
                    script.EntityName = emd.DisplayName.UserLocalizedLabel.Label;
                    script.ScriptLocation = libraryNode.Attributes["name"].Value;
                    script.MethodCalled = string.Empty;
                    script.Event = string.Empty;
                    script.Attribute = string.Empty;
                    script.AttributeLogicalName = string.Empty;
                    script.Type = "Homepage Grid Library";

                    Scripts.Add(script);
                }
            }
        }

        private void LoadRibbonCommands(EntityMetadata emd)
        {
            var commands = service.RetrieveMultiple(new QueryExpression("ribboncommand")
            {
                ColumnSet = new ColumnSet(true),
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("commanddefinition", ConditionOperator.Like, "%Library=\"$webresource:%"),
                        new ConditionExpression("entity", ConditionOperator.Equal, emd.LogicalName)
                    }
                }
            });

            foreach (var command in commands.Entities)
            {
                var commandDoc = new XmlDocument();
                commandDoc.LoadXml(command.GetAttributeValue<string>("commanddefinition"));

                var actionsNode = commandDoc.SelectSingleNode("CommandDefinition/Actions");
                if (actionsNode == null)
                {
                    return;
                }

                foreach (XmlNode actionNode in actionsNode.ChildNodes)
                {
                    var libraryNode = actionNode.Attributes?["Library"];
                    if (libraryNode == null)
                    {
                        continue;
                    }

                    var libraryName = libraryNode.Value;

                    if (libraryName.Split(':').Length == 1)
                        continue;

                    var script = new Script();
                    script.EntityLogicalName = emd.LogicalName;
                    script.EntityName = emd.DisplayName.UserLocalizedLabel.Label;
                    script.ScriptLocation = libraryName.Split(':')[1];
                    script.MethodCalled = actionNode.Attributes["FunctionName"].Value;
                    script.Event = "";
                    script.Attribute = "";
                    script.AttributeLogicalName = "";
                    script.FormState = string.Empty;
                    script.Type = "Ribbon Command";

                    var parameters = new List<string>();

                    foreach (XmlNode parameterNode in actionNode.ChildNodes)
                    {
                        // ReSharper disable once PossibleNullReferenceException
                        parameters.Add(string.Format("{0}:{1}", parameterNode.Name, parameterNode.Attributes["Value"].Value));
                    }

                    script.Arguments = string.Join(" / ", parameters);

                    if (script.ScriptLocation.IndexOf("_main_system_library", StringComparison.Ordinal) >= 0)
                    {
                        continue;
                    }

                    Scripts.Add(script);
                }
            }
        }

        private void LoadRibbonCustomRule()
        {
            var rules = service.RetrieveMultiple(new QueryExpression("ribbonrule")
            {
                ColumnSet = new ColumnSet(true),
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("ruledefinition", ConditionOperator.Like, "%Library=\"$webresource:%"),
                    }
                }
            });

            foreach (var rule in rules.Entities)
            {
                var commandDoc = new XmlDocument();
                commandDoc.LoadXml(rule.GetAttributeValue<string>("ruledefinition"));

                var customRulesNode = commandDoc.SelectNodes("//CustomRule");
                if (customRulesNode == null)
                {
                    return;
                }

                foreach (XmlNode customRuleNode in customRulesNode)
                {
                    var libraryNode = customRuleNode.Attributes?["Library"];
                    if (libraryNode == null)
                    {
                        continue;
                    }

                    var libraryName = libraryNode.Value;

                    if (libraryName.Split(':').Length == 1)
                        continue;

                    var script = new Script();
                    script.EntityLogicalName = rule.GetAttributeValue<string>("entity");
                    script.EntityName = emds.FirstOrDefault(e => e.LogicalName == script.EntityLogicalName)?.DisplayName.UserLocalizedLabel.Label ?? "Application Ribbon";
                    script.ScriptLocation = libraryName.Split(':')[1];
                    script.MethodCalled = customRuleNode.Attributes["FunctionName"].Value;
                    script.Event = "";
                    script.Attribute = "";
                    script.AttributeLogicalName = "";
                    script.FormState = string.Empty;
                    script.Type = "Ribbon Custom Rule";

                    var parameters = new List<string>();

                    foreach (XmlNode parameterNode in customRuleNode.ChildNodes)
                    {
                        // ReSharper disable once PossibleNullReferenceException
                        parameters.Add(string.Format("{0}:{1}", parameterNode.Name, parameterNode.Attributes["Value"].Value));
                    }

                    script.Arguments = string.Join(" / ", parameters);

                    if (script.ScriptLocation.IndexOf("_main_system_library", StringComparison.Ordinal) >= 0)
                    {
                        continue;
                    }

                    Scripts.Add(script);
                }
            }
        }

        private void LoadScripts(EntityMetadata emd)
        {
            var qba = new QueryByAttribute("systemform");
            qba.Attributes.Add("objecttypecode");
            qba.Values.Add(emd.ObjectTypeCode ?? 0);
            qba.ColumnSet = new ColumnSet(true);

            foreach (var form in service.RetrieveMultiple(qba).Entities)
            {
                if (form["formxml"] == null)
                {
                    continue;
                }

                var doc = new XmlDocument();
                doc.LoadXml(form["formxml"].ToString());

                foreach (XmlNode eventNode in doc.SelectNodes("//event"))
                {
                    string eventName = eventNode.Attributes["name"]?.Value;
                    if (eventName == null) continue;

                    foreach (XmlNode handlerNode in eventNode.SelectNodes("Handlers/Handler"))
                    {
                        var script = new Script();
                        script.EntityLogicalName = emd.LogicalName;
                        script.EntityName = emd.DisplayName?.UserLocalizedLabel?.Label ?? "N/A";
                        script.ScriptLocation = handlerNode.Attributes["libraryName"]?.Value ?? "N/A";
                        script.MethodCalled = handlerNode.Attributes["functionName"]?.Value ?? "N/A";
                        script.IsActive = handlerNode.Attributes["enabled"]?.Value == "true";
                        script.PassExecutionContext = handlerNode.Attributes["passExecutionContext"]?.Value == "true";
                        script.Event = eventName;
                        script.Arguments = handlerNode.Attributes["parameters"]?.Value ?? "";
                        script.Type = "Form event";

                        if (script.ScriptLocation.IndexOf("_main_system_library", StringComparison.Ordinal) >= 0)
                        {
                            continue;
                        }

                        if (eventName == "onchange")
                        {
                            var amd = emd.Attributes.FirstOrDefault(x => eventNode.Attributes != null && x.LogicalName == eventNode.Attributes["attribute"]?.Value);

                            if (amd != null)
                            {
                                var displayName = amd.DisplayName?.UserLocalizedLabel?.Label ?? "(" + amd.LogicalName + ")";
                                script.Attribute = displayName;
                                script.AttributeLogicalName = amd.LogicalName;
                            }
                            else if (eventNode.Attributes["control"] == null)
                            {
                                script.Attribute = eventNode.Attributes["attribute"]?.Value ?? "N/A";
                                script.AttributeLogicalName = eventNode.Attributes["attribute"]?.Value ?? "N/A";
                                script.HasProblem = true;
                            }
                            else
                            {
                                XmlNode node = doc.SelectSingleNode("//control[@id='" + eventNode.Attributes["control"].Value + "']");
                                XmlNode targetEntityNode = node.SelectSingleNode("parameters/TargetEntityType");

                                if (targetEntityNode == null) continue;

                                amd = emds.First(e => e.LogicalName == targetEntityNode.InnerText).Attributes.First(x => x.LogicalName == eventNode.Attributes?["attribute"]?.Value);
                                var displayName = amd.DisplayName?.UserLocalizedLabel?.Label ?? "(" + amd.LogicalName + ")";
                                script.Attribute = displayName;
                                script.AttributeLogicalName = amd.LogicalName;
                            }

                            if (eventNode.Attributes["control"] != null)
                            {
                                var control = eventNode.Attributes["control"].Value;

                                XmlNode node = doc.SelectSingleNode("//control[@id='" + control + "']");

                                var labelNode = node.ParentNode.SelectSingleNode("labels/label[@languagecode='" + userLcid + "']") ??
                                                node.ParentNode.SelectSingleNode("labels/label");

                                var label = labelNode.Attributes["description"]?.Value ?? "N/A";

                                script.Type = "Subgrid event";
                                script.Attribute = $"{label} / {script.Attribute}";
                                script.AttributeLogicalName = $"{control} / {script.AttributeLogicalName}";
                            }
                        }
                        else if (eventName == "onrecordselect")
                        {
                            var control = eventNode.Attributes["control"]?.Value;
                            if (control == null) continue;

                            XmlNode node = doc.SelectSingleNode("//control[@id='" + control + "']");
                            var label = node.ParentNode?.SelectSingleNode("labels/label[@languagecode='" + userLcid + "']")?.Attributes?[
                                    "description"]?.Value ?? "N/A";

                            script.Type = "Subgrid event";
                            script.Attribute = label;
                            script.AttributeLogicalName = control;
                        }
                        else if (eventName == "onsave")
                        {
                            if (eventNode.Attributes["control"] != null)
                            {
                                var control = eventNode.Attributes["control"].Value;
                                if (control == null) continue;

                                XmlNode node = doc.SelectSingleNode("//control[@id='" + control + "']");
                                var label = node.ParentNode?.SelectSingleNode("labels/label[@languagecode='" + userLcid + "']")?.Attributes?[
                                                "description"]?.Value ?? "N/A";

                                script.Type = "Subgrid event";
                                script.Attribute = label;
                                script.AttributeLogicalName = control;
                            }
                        }
                        else
                        {
                            script.Attribute = "";
                            script.AttributeLogicalName = "";
                        }
                        script.FormName = form["name"]?.ToString() ?? "N/A";
                        script.FormState = "Active";
                        if (form.Contains("formactivationstate"))
                        {
                            script.FormState = form.GetAttributeValue<OptionSetValue>("formactivationstate").Value == 0
                            ? "Inactive"
                            : "Active";
                        }

                        var type = form.GetAttributeValue<OptionSetValue>("type")?.Value ?? -1;
                        script.FormType = type == 2
                            ? "Main"
                            : (type == 7 ? "Quick Create" : "value: " + type);
                        Scripts.Add(script);
                    }
                }

                foreach (XmlNode libraryNode in doc.SelectNodes("//Library"))
                {
                    var script = new Script();
                    script.EntityLogicalName = emd.LogicalName;
                    script.EntityName = emd.DisplayName?.UserLocalizedLabel?.Label ?? "N/A";
                    script.ScriptLocation = libraryNode.Attributes?["name"]?.Value ?? "N/A";
                    script.MethodCalled = string.Empty;
                    script.Event = string.Empty;
                    script.Attribute = string.Empty;
                    script.AttributeLogicalName = string.Empty;
                    script.Type = "Form Library";

                    script.FormName = form["name"].ToString();
                    script.FormState = form.GetAttributeValue<OptionSetValue>("formactivationstate")?.Value == 0
                        ? "Inactive"
                        : "Active";

                    var type = form.GetAttributeValue<OptionSetValue>("type")?.Value ?? -1;
                    script.FormType = type == 2
                        ? "Main"
                        : (type == 7 ? "Quick Create" : "value: " + type);

                    if (script.ScriptLocation.IndexOf("_main_system_library", StringComparison.Ordinal) >= 0)
                    {
                        continue;
                    }

                    Scripts.Add(script);
                }
            }
        }
    }
}