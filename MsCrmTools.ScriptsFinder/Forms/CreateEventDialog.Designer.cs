﻿namespace MsCrmTools.ScriptsFinder.Forms
{
    partial class CreateEventDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderDesc = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnSolutionPickerCancel = new System.Windows.Forms.Button();
            this.btnSolutionPickerValidate = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.lblEnabled = new System.Windows.Forms.Label();
            this.txtParameters = new System.Windows.Forms.TextBox();
            this.lblParameters = new System.Windows.Forms.Label();
            this.chkPassExecutionContext = new System.Windows.Forms.CheckBox();
            this.lblPassExecutionContext = new System.Windows.Forms.Label();
            this.txtMethod = new System.Windows.Forms.TextBox();
            this.lblMethod = new System.Windows.Forms.Label();
            this.pnlLibrary = new System.Windows.Forms.Panel();
            this.cbbLibrary = new System.Windows.Forms.ComboBox();
            this.btnReloadWebResources = new System.Windows.Forms.Button();
            this.lblLibrary = new System.Windows.Forms.Label();
            this.txtField = new System.Windows.Forms.TextBox();
            this.lblField = new System.Windows.Forms.Label();
            this.cbbEvent = new System.Windows.Forms.ComboBox();
            this.lblEvent = new System.Windows.Forms.Label();
            this.cbbControl = new System.Windows.Forms.ComboBox();
            this.lblControl = new System.Windows.Forms.Label();
            this.cbbUiItems = new System.Windows.Forms.ComboBox();
            this.lblUiItem = new System.Windows.Forms.Label();
            this.cbbEntity = new System.Windows.Forms.ComboBox();
            this.lblEntity = new System.Windows.Forms.Label();
            this.pnlAction = new System.Windows.Forms.Panel();
            this.rdbRegisterLibrary = new System.Windows.Forms.RadioButton();
            this.rdbRegisterEvent = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlLibrary.SuspendLayout();
            this.pnlAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblHeaderDesc);
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(800, 100);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeaderDesc
            // 
            this.lblHeaderDesc.AutoSize = true;
            this.lblHeaderDesc.Font = new System.Drawing.Font("Segoe UI Light", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderDesc.Location = new System.Drawing.Point(18, 58);
            this.lblHeaderDesc.Name = "lblHeaderDesc";
            this.lblHeaderDesc.Size = new System.Drawing.Size(464, 30);
            this.lblHeaderDesc.TabIndex = 1;
            this.lblHeaderDesc.Text = "Provide information below to register a new item";
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderTitle.Location = new System.Drawing.Point(15, 13);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(434, 45);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "Register a new event or library";
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnSolutionPickerCancel);
            this.pnlFooter.Controls.Add(this.btnSolutionPickerValidate);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 965);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(800, 64);
            this.pnlFooter.TabIndex = 1;
            // 
            // btnSolutionPickerCancel
            // 
            this.btnSolutionPickerCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSolutionPickerCancel.Location = new System.Drawing.Point(635, 9);
            this.btnSolutionPickerCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnSolutionPickerCancel.Name = "btnSolutionPickerCancel";
            this.btnSolutionPickerCancel.Size = new System.Drawing.Size(150, 44);
            this.btnSolutionPickerCancel.TabIndex = 6;
            this.btnSolutionPickerCancel.Text = "Cancel";
            this.btnSolutionPickerCancel.UseVisualStyleBackColor = true;
            // 
            // btnSolutionPickerValidate
            // 
            this.btnSolutionPickerValidate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSolutionPickerValidate.Location = new System.Drawing.Point(473, 9);
            this.btnSolutionPickerValidate.Margin = new System.Windows.Forms.Padding(6);
            this.btnSolutionPickerValidate.Name = "btnSolutionPickerValidate";
            this.btnSolutionPickerValidate.Size = new System.Drawing.Size(150, 44);
            this.btnSolutionPickerValidate.TabIndex = 5;
            this.btnSolutionPickerValidate.Text = "OK";
            this.btnSolutionPickerValidate.UseVisualStyleBackColor = true;
            this.btnSolutionPickerValidate.Click += new System.EventHandler(this.btnSolutionPickerValidate_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.chkEnabled);
            this.pnlMain.Controls.Add(this.lblEnabled);
            this.pnlMain.Controls.Add(this.txtParameters);
            this.pnlMain.Controls.Add(this.lblParameters);
            this.pnlMain.Controls.Add(this.chkPassExecutionContext);
            this.pnlMain.Controls.Add(this.lblPassExecutionContext);
            this.pnlMain.Controls.Add(this.txtMethod);
            this.pnlMain.Controls.Add(this.lblMethod);
            this.pnlMain.Controls.Add(this.pnlLibrary);
            this.pnlMain.Controls.Add(this.lblLibrary);
            this.pnlMain.Controls.Add(this.txtField);
            this.pnlMain.Controls.Add(this.lblField);
            this.pnlMain.Controls.Add(this.cbbEvent);
            this.pnlMain.Controls.Add(this.lblEvent);
            this.pnlMain.Controls.Add(this.cbbControl);
            this.pnlMain.Controls.Add(this.lblControl);
            this.pnlMain.Controls.Add(this.cbbUiItems);
            this.pnlMain.Controls.Add(this.lblUiItem);
            this.pnlMain.Controls.Add(this.cbbEntity);
            this.pnlMain.Controls.Add(this.lblEntity);
            this.pnlMain.Controls.Add(this.pnlAction);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 100);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMain.Size = new System.Drawing.Size(800, 865);
            this.pnlMain.TabIndex = 2;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkEnabled.Location = new System.Drawing.Point(10, 706);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(780, 27);
            this.chkEnabled.TabIndex = 17;
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // lblEnabled
            // 
            this.lblEnabled.AutoSize = true;
            this.lblEnabled.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEnabled.Location = new System.Drawing.Point(10, 671);
            this.lblEnabled.Name = "lblEnabled";
            this.lblEnabled.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblEnabled.Size = new System.Drawing.Size(91, 35);
            this.lblEnabled.TabIndex = 16;
            this.lblEnabled.Text = "Enabled";
            // 
            // txtParameters
            // 
            this.txtParameters.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtParameters.Location = new System.Drawing.Point(10, 640);
            this.txtParameters.Name = "txtParameters";
            this.txtParameters.Size = new System.Drawing.Size(780, 31);
            this.txtParameters.TabIndex = 15;
            // 
            // lblParameters
            // 
            this.lblParameters.AutoSize = true;
            this.lblParameters.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblParameters.Location = new System.Drawing.Point(10, 605);
            this.lblParameters.Name = "lblParameters";
            this.lblParameters.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblParameters.Size = new System.Drawing.Size(122, 35);
            this.lblParameters.TabIndex = 14;
            this.lblParameters.Text = "Parameters";
            // 
            // chkPassExecutionContext
            // 
            this.chkPassExecutionContext.AutoSize = true;
            this.chkPassExecutionContext.Checked = true;
            this.chkPassExecutionContext.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPassExecutionContext.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkPassExecutionContext.Location = new System.Drawing.Point(10, 578);
            this.chkPassExecutionContext.Name = "chkPassExecutionContext";
            this.chkPassExecutionContext.Size = new System.Drawing.Size(780, 27);
            this.chkPassExecutionContext.TabIndex = 13;
            this.chkPassExecutionContext.UseVisualStyleBackColor = true;
            // 
            // lblPassExecutionContext
            // 
            this.lblPassExecutionContext.AutoSize = true;
            this.lblPassExecutionContext.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPassExecutionContext.Location = new System.Drawing.Point(10, 543);
            this.lblPassExecutionContext.Name = "lblPassExecutionContext";
            this.lblPassExecutionContext.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblPassExecutionContext.Size = new System.Drawing.Size(241, 35);
            this.lblPassExecutionContext.TabIndex = 12;
            this.lblPassExecutionContext.Text = "Pass Execution Context";
            // 
            // txtMethod
            // 
            this.txtMethod.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtMethod.Location = new System.Drawing.Point(10, 512);
            this.txtMethod.Name = "txtMethod";
            this.txtMethod.Size = new System.Drawing.Size(780, 31);
            this.txtMethod.TabIndex = 11;
            // 
            // lblMethod
            // 
            this.lblMethod.AutoSize = true;
            this.lblMethod.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMethod.Location = new System.Drawing.Point(10, 477);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblMethod.Size = new System.Drawing.Size(84, 35);
            this.lblMethod.TabIndex = 10;
            this.lblMethod.Text = "Method";
            // 
            // pnlLibrary
            // 
            this.pnlLibrary.Controls.Add(this.cbbLibrary);
            this.pnlLibrary.Controls.Add(this.btnReloadWebResources);
            this.pnlLibrary.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLibrary.Location = new System.Drawing.Point(10, 438);
            this.pnlLibrary.Name = "pnlLibrary";
            this.pnlLibrary.Size = new System.Drawing.Size(780, 39);
            this.pnlLibrary.TabIndex = 20;
            // 
            // cbbLibrary
            // 
            this.cbbLibrary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbLibrary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLibrary.FormattingEnabled = true;
            this.cbbLibrary.Location = new System.Drawing.Point(0, 0);
            this.cbbLibrary.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.cbbLibrary.Name = "cbbLibrary";
            this.cbbLibrary.Size = new System.Drawing.Size(741, 33);
            this.cbbLibrary.TabIndex = 1;
            // 
            // btnReloadWebResources
            // 
            this.btnReloadWebResources.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnReloadWebResources.Image = global::MsCrmTools.ScriptsFinder.Properties.Resources.arrow_refresh;
            this.btnReloadWebResources.Location = new System.Drawing.Point(741, 0);
            this.btnReloadWebResources.Name = "btnReloadWebResources";
            this.btnReloadWebResources.Size = new System.Drawing.Size(39, 39);
            this.btnReloadWebResources.TabIndex = 0;
            this.btnReloadWebResources.UseVisualStyleBackColor = true;
            this.btnReloadWebResources.Click += new System.EventHandler(this.btnReloadWebResources_Click);
            // 
            // lblLibrary
            // 
            this.lblLibrary.AutoSize = true;
            this.lblLibrary.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLibrary.Location = new System.Drawing.Point(10, 403);
            this.lblLibrary.Name = "lblLibrary";
            this.lblLibrary.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblLibrary.Size = new System.Drawing.Size(78, 35);
            this.lblLibrary.TabIndex = 8;
            this.lblLibrary.Text = "Library";
            // 
            // txtField
            // 
            this.txtField.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtField.Location = new System.Drawing.Point(10, 372);
            this.txtField.Name = "txtField";
            this.txtField.Size = new System.Drawing.Size(780, 31);
            this.txtField.TabIndex = 19;
            this.txtField.Visible = false;
            // 
            // lblField
            // 
            this.lblField.AutoSize = true;
            this.lblField.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblField.Location = new System.Drawing.Point(10, 337);
            this.lblField.Name = "lblField";
            this.lblField.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblField.Size = new System.Drawing.Size(59, 35);
            this.lblField.TabIndex = 18;
            this.lblField.Text = "Field";
            this.lblField.Visible = false;
            // 
            // cbbEvent
            // 
            this.cbbEvent.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbbEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbEvent.FormattingEnabled = true;
            this.cbbEvent.Location = new System.Drawing.Point(10, 304);
            this.cbbEvent.Name = "cbbEvent";
            this.cbbEvent.Size = new System.Drawing.Size(780, 33);
            this.cbbEvent.TabIndex = 7;
            this.cbbEvent.SelectedIndexChanged += new System.EventHandler(this.cbbEvent_SelectedIndexChanged);
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEvent.Location = new System.Drawing.Point(10, 269);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblEvent.Size = new System.Drawing.Size(67, 35);
            this.lblEvent.TabIndex = 6;
            this.lblEvent.Text = "Event";
            // 
            // cbbControl
            // 
            this.cbbControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbbControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbControl.FormattingEnabled = true;
            this.cbbControl.Location = new System.Drawing.Point(10, 236);
            this.cbbControl.Name = "cbbControl";
            this.cbbControl.Size = new System.Drawing.Size(780, 33);
            this.cbbControl.TabIndex = 5;
            this.cbbControl.SelectedIndexChanged += new System.EventHandler(this.cbbControl_SelectedIndexChanged);
            // 
            // lblControl
            // 
            this.lblControl.AutoSize = true;
            this.lblControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblControl.Location = new System.Drawing.Point(10, 201);
            this.lblControl.Name = "lblControl";
            this.lblControl.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblControl.Size = new System.Drawing.Size(81, 35);
            this.lblControl.TabIndex = 4;
            this.lblControl.Text = "Control";
            // 
            // cbbUiItems
            // 
            this.cbbUiItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbbUiItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUiItems.FormattingEnabled = true;
            this.cbbUiItems.Location = new System.Drawing.Point(10, 168);
            this.cbbUiItems.Name = "cbbUiItems";
            this.cbbUiItems.Size = new System.Drawing.Size(780, 33);
            this.cbbUiItems.TabIndex = 3;
            this.cbbUiItems.SelectedIndexChanged += new System.EventHandler(this.cbbForm_SelectedIndexChanged);
            // 
            // lblUiItem
            // 
            this.lblUiItem.AutoSize = true;
            this.lblUiItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUiItem.Location = new System.Drawing.Point(10, 133);
            this.lblUiItem.Name = "lblUiItem";
            this.lblUiItem.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblUiItem.Size = new System.Drawing.Size(78, 35);
            this.lblUiItem.TabIndex = 2;
            this.lblUiItem.Text = "UI item";
            // 
            // cbbEntity
            // 
            this.cbbEntity.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbbEntity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbEntity.FormattingEnabled = true;
            this.cbbEntity.Location = new System.Drawing.Point(10, 100);
            this.cbbEntity.Name = "cbbEntity";
            this.cbbEntity.Size = new System.Drawing.Size(780, 33);
            this.cbbEntity.TabIndex = 1;
            this.cbbEntity.SelectedIndexChanged += new System.EventHandler(this.cbbEntity_SelectedIndexChanged);
            // 
            // lblEntity
            // 
            this.lblEntity.AutoSize = true;
            this.lblEntity.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEntity.Location = new System.Drawing.Point(10, 65);
            this.lblEntity.Name = "lblEntity";
            this.lblEntity.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblEntity.Size = new System.Drawing.Size(66, 35);
            this.lblEntity.TabIndex = 0;
            this.lblEntity.Text = "Entity";
            // 
            // pnlAction
            // 
            this.pnlAction.Controls.Add(this.rdbRegisterLibrary);
            this.pnlAction.Controls.Add(this.rdbRegisterEvent);
            this.pnlAction.Controls.Add(this.label1);
            this.pnlAction.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAction.Location = new System.Drawing.Point(10, 10);
            this.pnlAction.Name = "pnlAction";
            this.pnlAction.Size = new System.Drawing.Size(780, 55);
            this.pnlAction.TabIndex = 21;
            // 
            // rdbRegisterLibrary
            // 
            this.rdbRegisterLibrary.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdbRegisterLibrary.Location = new System.Drawing.Point(250, 0);
            this.rdbRegisterLibrary.Name = "rdbRegisterLibrary";
            this.rdbRegisterLibrary.Size = new System.Drawing.Size(150, 55);
            this.rdbRegisterLibrary.TabIndex = 3;
            this.rdbRegisterLibrary.Text = "A Library";
            this.rdbRegisterLibrary.UseVisualStyleBackColor = true;
            // 
            // rdbRegisterEvent
            // 
            this.rdbRegisterEvent.Checked = true;
            this.rdbRegisterEvent.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdbRegisterEvent.Location = new System.Drawing.Point(100, 0);
            this.rdbRegisterEvent.Name = "rdbRegisterEvent";
            this.rdbRegisterEvent.Size = new System.Drawing.Size(150, 55);
            this.rdbRegisterEvent.TabIndex = 2;
            this.rdbRegisterEvent.TabStop = true;
            this.rdbRegisterEvent.Text = "An Event";
            this.rdbRegisterEvent.UseVisualStyleBackColor = true;
            this.rdbRegisterEvent.CheckedChanged += new System.EventHandler(this.rdbRegisterEvent_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Register";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CreateEventDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 1029);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Name = "CreateEventDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New registration";
            this.Load += new System.EventHandler(this.CreateEventDialog_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlLibrary.ResumeLayout(false);
            this.pnlAction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ComboBox cbbEntity;
        private System.Windows.Forms.Label lblEntity;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.Label lblEnabled;
        private System.Windows.Forms.TextBox txtParameters;
        private System.Windows.Forms.Label lblParameters;
        private System.Windows.Forms.CheckBox chkPassExecutionContext;
        private System.Windows.Forms.Label lblPassExecutionContext;
        private System.Windows.Forms.TextBox txtMethod;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.Label lblLibrary;
        private System.Windows.Forms.ComboBox cbbEvent;
        private System.Windows.Forms.Label lblEvent;
        private System.Windows.Forms.ComboBox cbbControl;
        private System.Windows.Forms.Label lblControl;
        private System.Windows.Forms.ComboBox cbbUiItems;
        private System.Windows.Forms.Label lblUiItem;
        private System.Windows.Forms.TextBox txtField;
        private System.Windows.Forms.Label lblField;
        private System.Windows.Forms.Label lblHeaderDesc;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Button btnSolutionPickerCancel;
        private System.Windows.Forms.Button btnSolutionPickerValidate;
        private System.Windows.Forms.Panel pnlLibrary;
        private System.Windows.Forms.Button btnReloadWebResources;
        private System.Windows.Forms.ComboBox cbbLibrary;
        private System.Windows.Forms.Panel pnlAction;
        private System.Windows.Forms.RadioButton rdbRegisterLibrary;
        private System.Windows.Forms.RadioButton rdbRegisterEvent;
        private System.Windows.Forms.Label label1;
    }
}