namespace DiscordRichPresence
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblProfiles = new System.Windows.Forms.Label();
            this.cbxProfiles = new System.Windows.Forms.ComboBox();
            this.gbxOptions = new System.Windows.Forms.GroupBox();
            this.chkAudible = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbxTypes = new System.Windows.Forms.ComboBox();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.chkTargetSmallText = new System.Windows.Forms.CheckBox();
            this.chkTargetSmallImage = new System.Windows.Forms.CheckBox();
            this.chkTargetLargeText = new System.Windows.Forms.CheckBox();
            this.chkTargetLargeImage = new System.Windows.Forms.CheckBox();
            this.chkTargetDetails = new System.Windows.Forms.CheckBox();
            this.chkTargetState = new System.Windows.Forms.CheckBox();
            this.tbxDetails = new System.Windows.Forms.TextBox();
            this.tbxState = new System.Windows.Forms.TextBox();
            this.lblDetails = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.tbxSmallText = new System.Windows.Forms.TextBox();
            this.tbxSmallImage = new System.Windows.Forms.TextBox();
            this.tbxLargeText = new System.Windows.Forms.TextBox();
            this.tbxLargeImage = new System.Windows.Forms.TextBox();
            this.tbxTargetUrl = new System.Windows.Forms.TextBox();
            this.tbxSourceUrl = new System.Windows.Forms.TextBox();
            this.lblSmallText = new System.Windows.Forms.Label();
            this.lblSmallImage = new System.Windows.Forms.Label();
            this.lblLargeText = new System.Windows.Forms.Label();
            this.lblLargeImage = new System.Windows.Forms.Label();
            this.lblTargetUrl = new System.Windows.Forms.Label();
            this.lblSourceUrl = new System.Windows.Forms.Label();
            this.tbxProfileName = new System.Windows.Forms.TextBox();
            this.lblProfileName = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.ntfIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsTrayIconContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmClose = new System.Windows.Forms.ToolStripMenuItem();
            this.hlpProvider = new System.Windows.Forms.HelpProvider();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnOptions = new System.Windows.Forms.Button();
            this.gbxWebservice = new System.Windows.Forms.GroupBox();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.gbxOptions.SuspendLayout();
            this.cmsTrayIconContext.SuspendLayout();
            this.gbxWebservice.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProfiles
            // 
            this.lblProfiles.AutoSize = true;
            this.lblProfiles.Location = new System.Drawing.Point(12, 9);
            this.lblProfiles.Name = "lblProfiles";
            this.lblProfiles.Size = new System.Drawing.Size(49, 15);
            this.lblProfiles.TabIndex = 0;
            this.lblProfiles.Text = "Profiles:";
            // 
            // cbxProfiles
            // 
            this.cbxProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProfiles.Enabled = false;
            this.cbxProfiles.FormattingEnabled = true;
            this.cbxProfiles.Location = new System.Drawing.Point(64, 6);
            this.cbxProfiles.MaxDropDownItems = 100;
            this.cbxProfiles.Name = "cbxProfiles";
            this.cbxProfiles.Size = new System.Drawing.Size(121, 23);
            this.cbxProfiles.TabIndex = 1;
            this.cbxProfiles.SelectionChangeCommitted += new System.EventHandler(this.cbxProfiles_SelectionChangeCommitted);
            // 
            // gbxOptions
            // 
            this.gbxOptions.BackColor = System.Drawing.SystemColors.Window;
            this.gbxOptions.Controls.Add(this.chkAudible);
            this.gbxOptions.Controls.Add(this.btnCancel);
            this.gbxOptions.Controls.Add(this.btnSave);
            this.gbxOptions.Controls.Add(this.cbxTypes);
            this.gbxOptions.Controls.Add(this.tbxName);
            this.gbxOptions.Controls.Add(this.label1);
            this.gbxOptions.Controls.Add(this.lblType);
            this.gbxOptions.Controls.Add(this.chkTargetSmallText);
            this.gbxOptions.Controls.Add(this.chkTargetSmallImage);
            this.gbxOptions.Controls.Add(this.chkTargetLargeText);
            this.gbxOptions.Controls.Add(this.chkTargetLargeImage);
            this.gbxOptions.Controls.Add(this.chkTargetDetails);
            this.gbxOptions.Controls.Add(this.chkTargetState);
            this.gbxOptions.Controls.Add(this.tbxDetails);
            this.gbxOptions.Controls.Add(this.tbxState);
            this.gbxOptions.Controls.Add(this.lblDetails);
            this.gbxOptions.Controls.Add(this.lblState);
            this.gbxOptions.Controls.Add(this.tbxSmallText);
            this.gbxOptions.Controls.Add(this.tbxSmallImage);
            this.gbxOptions.Controls.Add(this.tbxLargeText);
            this.gbxOptions.Controls.Add(this.tbxLargeImage);
            this.gbxOptions.Controls.Add(this.tbxTargetUrl);
            this.gbxOptions.Controls.Add(this.tbxSourceUrl);
            this.gbxOptions.Controls.Add(this.lblSmallText);
            this.gbxOptions.Controls.Add(this.lblSmallImage);
            this.gbxOptions.Controls.Add(this.lblLargeText);
            this.gbxOptions.Controls.Add(this.lblLargeImage);
            this.gbxOptions.Controls.Add(this.lblTargetUrl);
            this.gbxOptions.Controls.Add(this.lblSourceUrl);
            this.gbxOptions.Controls.Add(this.tbxProfileName);
            this.gbxOptions.Controls.Add(this.lblProfileName);
            this.gbxOptions.Location = new System.Drawing.Point(12, 35);
            this.gbxOptions.Name = "gbxOptions";
            this.gbxOptions.Size = new System.Drawing.Size(400, 472);
            this.gbxOptions.TabIndex = 5;
            this.gbxOptions.TabStop = false;
            this.gbxOptions.Text = "Options";
            // 
            // chkAudible
            // 
            this.chkAudible.AutoSize = true;
            this.chkAudible.Enabled = false;
            this.chkAudible.Location = new System.Drawing.Point(325, 413);
            this.chkAudible.Name = "chkAudible";
            this.chkAudible.Size = new System.Drawing.Size(67, 19);
            this.chkAudible.TabIndex = 23;
            this.chkAudible.Text = "Audible";
            this.chkAudible.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(98, 443);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(11, 443);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbxTypes
            // 
            this.cbxTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTypes.Enabled = false;
            this.cbxTypes.FormattingEnabled = true;
            this.cbxTypes.Location = new System.Drawing.Point(119, 124);
            this.cbxTypes.Name = "cbxTypes";
            this.cbxTypes.Size = new System.Drawing.Size(200, 23);
            this.cbxTypes.TabIndex = 9;
            // 
            // tbxName
            // 
            this.tbxName.Enabled = false;
            this.tbxName.Location = new System.Drawing.Point(119, 160);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(200, 23);
            this.tbxName.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "Name:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(7, 127);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 15);
            this.lblType.TabIndex = 24;
            this.lblType.Text = "Type:";
            // 
            // chkTargetSmallText
            // 
            this.chkTargetSmallText.AutoSize = true;
            this.chkTargetSmallText.Enabled = false;
            this.chkTargetSmallText.Location = new System.Drawing.Point(325, 377);
            this.chkTargetSmallText.Name = "chkTargetSmallText";
            this.chkTargetSmallText.Size = new System.Drawing.Size(58, 19);
            this.chkTargetSmallText.TabIndex = 22;
            this.chkTargetSmallText.Text = "Target";
            this.chkTargetSmallText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkTargetSmallText.UseVisualStyleBackColor = true;
            // 
            // chkTargetSmallImage
            // 
            this.chkTargetSmallImage.AutoSize = true;
            this.chkTargetSmallImage.Enabled = false;
            this.chkTargetSmallImage.Location = new System.Drawing.Point(325, 341);
            this.chkTargetSmallImage.Name = "chkTargetSmallImage";
            this.chkTargetSmallImage.Size = new System.Drawing.Size(58, 19);
            this.chkTargetSmallImage.TabIndex = 20;
            this.chkTargetSmallImage.Text = "Target";
            this.chkTargetSmallImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkTargetSmallImage.UseVisualStyleBackColor = true;
            // 
            // chkTargetLargeText
            // 
            this.chkTargetLargeText.AutoSize = true;
            this.chkTargetLargeText.Enabled = false;
            this.chkTargetLargeText.Location = new System.Drawing.Point(325, 308);
            this.chkTargetLargeText.Name = "chkTargetLargeText";
            this.chkTargetLargeText.Size = new System.Drawing.Size(58, 19);
            this.chkTargetLargeText.TabIndex = 18;
            this.chkTargetLargeText.Text = "Target";
            this.chkTargetLargeText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkTargetLargeText.UseVisualStyleBackColor = true;
            // 
            // chkTargetLargeImage
            // 
            this.chkTargetLargeImage.AutoSize = true;
            this.chkTargetLargeImage.Enabled = false;
            this.chkTargetLargeImage.Location = new System.Drawing.Point(325, 272);
            this.chkTargetLargeImage.Name = "chkTargetLargeImage";
            this.chkTargetLargeImage.Size = new System.Drawing.Size(58, 19);
            this.chkTargetLargeImage.TabIndex = 16;
            this.chkTargetLargeImage.Text = "Target";
            this.chkTargetLargeImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkTargetLargeImage.UseVisualStyleBackColor = true;
            // 
            // chkTargetDetails
            // 
            this.chkTargetDetails.AutoSize = true;
            this.chkTargetDetails.Enabled = false;
            this.chkTargetDetails.Location = new System.Drawing.Point(325, 234);
            this.chkTargetDetails.Name = "chkTargetDetails";
            this.chkTargetDetails.Size = new System.Drawing.Size(58, 19);
            this.chkTargetDetails.TabIndex = 14;
            this.chkTargetDetails.Text = "Target";
            this.chkTargetDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkTargetDetails.UseVisualStyleBackColor = true;
            // 
            // chkTargetState
            // 
            this.chkTargetState.AutoSize = true;
            this.chkTargetState.Enabled = false;
            this.chkTargetState.Location = new System.Drawing.Point(325, 198);
            this.chkTargetState.Name = "chkTargetState";
            this.chkTargetState.Size = new System.Drawing.Size(58, 19);
            this.chkTargetState.TabIndex = 12;
            this.chkTargetState.Text = "Target";
            this.chkTargetState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkTargetState.UseVisualStyleBackColor = true;
            // 
            // tbxDetails
            // 
            this.tbxDetails.Enabled = false;
            this.tbxDetails.Location = new System.Drawing.Point(119, 232);
            this.tbxDetails.Name = "tbxDetails";
            this.tbxDetails.Size = new System.Drawing.Size(200, 23);
            this.tbxDetails.TabIndex = 13;
            // 
            // tbxState
            // 
            this.tbxState.Enabled = false;
            this.tbxState.Location = new System.Drawing.Point(119, 196);
            this.tbxState.Name = "tbxState";
            this.tbxState.Size = new System.Drawing.Size(200, 23);
            this.tbxState.TabIndex = 11;
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Location = new System.Drawing.Point(7, 235);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(45, 15);
            this.lblDetails.TabIndex = 15;
            this.lblDetails.Text = "Details:";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(7, 199);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(36, 15);
            this.lblState.TabIndex = 14;
            this.lblState.Text = "State:";
            // 
            // tbxSmallText
            // 
            this.tbxSmallText.Enabled = false;
            this.tbxSmallText.Location = new System.Drawing.Point(119, 375);
            this.tbxSmallText.Name = "tbxSmallText";
            this.tbxSmallText.Size = new System.Drawing.Size(200, 23);
            this.tbxSmallText.TabIndex = 21;
            // 
            // tbxSmallImage
            // 
            this.tbxSmallImage.Enabled = false;
            this.tbxSmallImage.Location = new System.Drawing.Point(119, 339);
            this.tbxSmallImage.Name = "tbxSmallImage";
            this.tbxSmallImage.Size = new System.Drawing.Size(200, 23);
            this.tbxSmallImage.TabIndex = 19;
            // 
            // tbxLargeText
            // 
            this.tbxLargeText.Enabled = false;
            this.tbxLargeText.Location = new System.Drawing.Point(119, 306);
            this.tbxLargeText.Name = "tbxLargeText";
            this.tbxLargeText.Size = new System.Drawing.Size(200, 23);
            this.tbxLargeText.TabIndex = 17;
            // 
            // tbxLargeImage
            // 
            this.tbxLargeImage.Enabled = false;
            this.tbxLargeImage.Location = new System.Drawing.Point(119, 270);
            this.tbxLargeImage.Name = "tbxLargeImage";
            this.tbxLargeImage.Size = new System.Drawing.Size(200, 23);
            this.tbxLargeImage.TabIndex = 15;
            // 
            // tbxTargetUrl
            // 
            this.tbxTargetUrl.Enabled = false;
            this.tbxTargetUrl.Location = new System.Drawing.Point(119, 88);
            this.tbxTargetUrl.Name = "tbxTargetUrl";
            this.tbxTargetUrl.Size = new System.Drawing.Size(200, 23);
            this.tbxTargetUrl.TabIndex = 8;
            // 
            // tbxSourceUrl
            // 
            this.tbxSourceUrl.Enabled = false;
            this.tbxSourceUrl.Location = new System.Drawing.Point(119, 52);
            this.tbxSourceUrl.Name = "tbxSourceUrl";
            this.tbxSourceUrl.Size = new System.Drawing.Size(200, 23);
            this.tbxSourceUrl.TabIndex = 7;
            // 
            // lblSmallText
            // 
            this.lblSmallText.AutoSize = true;
            this.lblSmallText.Location = new System.Drawing.Point(7, 378);
            this.lblSmallText.Name = "lblSmallText";
            this.lblSmallText.Size = new System.Drawing.Size(63, 15);
            this.lblSmallText.TabIndex = 7;
            this.lblSmallText.Text = "Small Text:";
            // 
            // lblSmallImage
            // 
            this.lblSmallImage.AutoSize = true;
            this.lblSmallImage.Location = new System.Drawing.Point(7, 342);
            this.lblSmallImage.Name = "lblSmallImage";
            this.lblSmallImage.Size = new System.Drawing.Size(75, 15);
            this.lblSmallImage.TabIndex = 6;
            this.lblSmallImage.Text = "Small Image:";
            // 
            // lblLargeText
            // 
            this.lblLargeText.AutoSize = true;
            this.lblLargeText.Location = new System.Drawing.Point(7, 309);
            this.lblLargeText.Name = "lblLargeText";
            this.lblLargeText.Size = new System.Drawing.Size(63, 15);
            this.lblLargeText.TabIndex = 5;
            this.lblLargeText.Text = "Large Text:";
            // 
            // lblLargeImage
            // 
            this.lblLargeImage.AutoSize = true;
            this.lblLargeImage.Location = new System.Drawing.Point(7, 273);
            this.lblLargeImage.Name = "lblLargeImage";
            this.lblLargeImage.Size = new System.Drawing.Size(75, 15);
            this.lblLargeImage.TabIndex = 4;
            this.lblLargeImage.Text = "Large Image:";
            // 
            // lblTargetUrl
            // 
            this.lblTargetUrl.AutoSize = true;
            this.lblTargetUrl.Location = new System.Drawing.Point(7, 91);
            this.lblTargetUrl.Name = "lblTargetUrl";
            this.lblTargetUrl.Size = new System.Drawing.Size(60, 15);
            this.lblTargetUrl.TabIndex = 3;
            this.lblTargetUrl.Text = "Target Url:";
            // 
            // lblSourceUrl
            // 
            this.lblSourceUrl.AutoSize = true;
            this.lblSourceUrl.Location = new System.Drawing.Point(7, 55);
            this.lblSourceUrl.Name = "lblSourceUrl";
            this.lblSourceUrl.Size = new System.Drawing.Size(64, 15);
            this.lblSourceUrl.TabIndex = 2;
            this.lblSourceUrl.Text = "Source Url:";
            // 
            // tbxProfileName
            // 
            this.tbxProfileName.Enabled = false;
            this.tbxProfileName.Location = new System.Drawing.Point(119, 16);
            this.tbxProfileName.Name = "tbxProfileName";
            this.tbxProfileName.Size = new System.Drawing.Size(200, 23);
            this.tbxProfileName.TabIndex = 6;
            // 
            // lblProfileName
            // 
            this.lblProfileName.AutoSize = true;
            this.lblProfileName.Location = new System.Drawing.Point(7, 19);
            this.lblProfileName.Name = "lblProfileName";
            this.lblProfileName.Size = new System.Drawing.Size(79, 15);
            this.lblProfileName.TabIndex = 0;
            this.lblProfileName.Text = "Profile Name:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(429, 50);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(429, 86);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(429, 122);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ntfIcon
            // 
            this.ntfIcon.ContextMenuStrip = this.cmsTrayIconContext;
            this.ntfIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("ntfIcon.Icon")));
            this.ntfIcon.Text = "Discord Rich Presence Creator";
            this.ntfIcon.Visible = true;
            this.ntfIcon.DoubleClick += new System.EventHandler(this.ntfIcon_DoubleClick);
            // 
            // cmsTrayIconContext
            // 
            this.cmsTrayIconContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmOpen,
            this.toolStripSeparator1,
            this.tsmClose});
            this.cmsTrayIconContext.Name = "cmsTrayIconContext";
            this.cmsTrayIconContext.Size = new System.Drawing.Size(104, 54);
            // 
            // tsmOpen
            // 
            this.tsmOpen.Name = "tsmOpen";
            this.tsmOpen.Size = new System.Drawing.Size(103, 22);
            this.tsmOpen.Text = "Open";
            this.tsmOpen.Click += new System.EventHandler(this.tsmOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(100, 6);
            // 
            // tsmClose
            // 
            this.tsmClose.Name = "tsmClose";
            this.tsmClose.Size = new System.Drawing.Size(103, 22);
            this.tsmClose.Text = "Close";
            this.tsmClose.Click += new System.EventHandler(this.tsmClose_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Location = new System.Drawing.Point(429, 158);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(75, 23);
            this.btnMinimize.TabIndex = 4;
            this.btnMinimize.Text = "Minimize";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.Location = new System.Drawing.Point(430, 194);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(75, 23);
            this.btnOptions.TabIndex = 6;
            this.btnOptions.Text = "Options";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // gbxWebservice
            // 
            this.gbxWebservice.BackColor = System.Drawing.SystemColors.Window;
            this.gbxWebservice.Controls.Add(this.btnEnd);
            this.gbxWebservice.Controls.Add(this.btnStart);
            this.gbxWebservice.Location = new System.Drawing.Point(418, 263);
            this.gbxWebservice.Name = "gbxWebservice";
            this.gbxWebservice.Size = new System.Drawing.Size(99, 129);
            this.gbxWebservice.TabIndex = 7;
            this.gbxWebservice.TabStop = false;
            this.gbxWebservice.Text = "Webservice";
            // 
            // btnEnd
            // 
            this.btnEnd.Enabled = false;
            this.btnEnd.Location = new System.Drawing.Point(12, 77);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(75, 23);
            this.btnEnd.TabIndex = 8;
            this.btnEnd.Text = "End";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 37);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 515);
            this.Controls.Add(this.gbxWebservice);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gbxOptions);
            this.Controls.Add(this.cbxProfiles);
            this.Controls.Add(this.lblProfiles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.ShowInTaskbar = false;
            this.Text = "Discord Rich Presence Creator";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.gbxOptions.ResumeLayout(false);
            this.gbxOptions.PerformLayout();
            this.cmsTrayIconContext.ResumeLayout(false);
            this.gbxWebservice.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblProfiles;
        private ComboBox cbxProfiles;
        private GroupBox gbxOptions;
        private TextBox tbxProfileName;
        private Label lblProfileName;
        private TextBox tbxSmallText;
        private TextBox tbxSmallImage;
        private TextBox tbxLargeText;
        private TextBox tbxLargeImage;
        private TextBox tbxTargetUrl;
        private TextBox tbxSourceUrl;
        private Label lblSmallText;
        private Label lblSmallImage;
        private Label lblLargeText;
        private Label lblLargeImage;
        private Label lblTargetUrl;
        private Label lblSourceUrl;
        private TextBox tbxDetails;
        private TextBox tbxState;
        private Label lblDetails;
        private Label lblState;
        private CheckBox chkTargetSmallText;
        private CheckBox chkTargetSmallImage;
        private CheckBox chkTargetLargeText;
        private CheckBox chkTargetLargeImage;
        private CheckBox chkTargetDetails;
        private CheckBox chkTargetState;
        private ComboBox cbxTypes;
        private TextBox tbxName;
        private Label label1;
        private Label lblType;
        private Button btnSave;
        private Button btnAdd;
        private Button btnCancel;
        private Button btnUpdate;
        private Button btnDelete;
        private CheckBox chkAudible;
        private NotifyIcon ntfIcon;
        private HelpProvider hlpProvider;
        private Button btnMinimize;
        private Button btnOptions;
        private ContextMenuStrip cmsTrayIconContext;
        private ToolStripMenuItem tsmOpen;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem tsmClose;
        private GroupBox gbxWebservice;
        private Button btnEnd;
        private Button btnStart;
    }
}