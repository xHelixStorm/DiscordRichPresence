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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblProfiles = new System.Windows.Forms.Label();
            this.cbxProfiles = new System.Windows.Forms.ComboBox();
            this.gbxOptions = new System.Windows.Forms.GroupBox();
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
            this.tbxTargetDomain = new System.Windows.Forms.TextBox();
            this.tbxSourceDomain = new System.Windows.Forms.TextBox();
            this.lblSmallText = new System.Windows.Forms.Label();
            this.lblSmallImage = new System.Windows.Forms.Label();
            this.lblLargeText = new System.Windows.Forms.Label();
            this.lblLargeImage = new System.Windows.Forms.Label();
            this.lblTargetDomain = new System.Windows.Forms.Label();
            this.lblSourceDomain = new System.Windows.Forms.Label();
            this.tbxProfileName = new System.Windows.Forms.TextBox();
            this.lblProfileName = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.chkAudible = new System.Windows.Forms.CheckBox();
            this.gbxOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProfiles
            // 
            resources.ApplyResources(this.lblProfiles, "lblProfiles");
            this.lblProfiles.Name = "lblProfiles";
            // 
            // cbxProfiles
            // 
            resources.ApplyResources(this.cbxProfiles, "cbxProfiles");
            this.cbxProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProfiles.FormattingEnabled = true;
            this.cbxProfiles.Name = "cbxProfiles";
            this.cbxProfiles.SelectionChangeCommitted += new System.EventHandler(this.cbxProfiles_SelectionChangeCommitted);
            // 
            // gbxOptions
            // 
            resources.ApplyResources(this.gbxOptions, "gbxOptions");
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
            this.gbxOptions.Controls.Add(this.tbxTargetDomain);
            this.gbxOptions.Controls.Add(this.tbxSourceDomain);
            this.gbxOptions.Controls.Add(this.lblSmallText);
            this.gbxOptions.Controls.Add(this.lblSmallImage);
            this.gbxOptions.Controls.Add(this.lblLargeText);
            this.gbxOptions.Controls.Add(this.lblLargeImage);
            this.gbxOptions.Controls.Add(this.lblTargetDomain);
            this.gbxOptions.Controls.Add(this.lblSourceDomain);
            this.gbxOptions.Controls.Add(this.tbxProfileName);
            this.gbxOptions.Controls.Add(this.lblProfileName);
            this.gbxOptions.Name = "gbxOptions";
            this.gbxOptions.TabStop = false;
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbxTypes
            // 
            resources.ApplyResources(this.cbxTypes, "cbxTypes");
            this.cbxTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTypes.FormattingEnabled = true;
            this.cbxTypes.Name = "cbxTypes";
            // 
            // tbxName
            // 
            resources.ApplyResources(this.tbxName, "tbxName");
            this.tbxName.Name = "tbxName";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lblType
            // 
            resources.ApplyResources(this.lblType, "lblType");
            this.lblType.Name = "lblType";
            // 
            // chkTargetSmallText
            // 
            resources.ApplyResources(this.chkTargetSmallText, "chkTargetSmallText");
            this.chkTargetSmallText.Name = "chkTargetSmallText";
            this.chkTargetSmallText.UseVisualStyleBackColor = true;
            // 
            // chkTargetSmallImage
            // 
            resources.ApplyResources(this.chkTargetSmallImage, "chkTargetSmallImage");
            this.chkTargetSmallImage.Name = "chkTargetSmallImage";
            this.chkTargetSmallImage.UseVisualStyleBackColor = true;
            // 
            // chkTargetLargeText
            // 
            resources.ApplyResources(this.chkTargetLargeText, "chkTargetLargeText");
            this.chkTargetLargeText.Name = "chkTargetLargeText";
            this.chkTargetLargeText.UseVisualStyleBackColor = true;
            // 
            // chkTargetLargeImage
            // 
            resources.ApplyResources(this.chkTargetLargeImage, "chkTargetLargeImage");
            this.chkTargetLargeImage.Name = "chkTargetLargeImage";
            this.chkTargetLargeImage.UseVisualStyleBackColor = true;
            // 
            // chkTargetDetails
            // 
            resources.ApplyResources(this.chkTargetDetails, "chkTargetDetails");
            this.chkTargetDetails.Name = "chkTargetDetails";
            this.chkTargetDetails.UseVisualStyleBackColor = true;
            // 
            // chkTargetState
            // 
            resources.ApplyResources(this.chkTargetState, "chkTargetState");
            this.chkTargetState.Name = "chkTargetState";
            this.chkTargetState.UseVisualStyleBackColor = true;
            // 
            // tbxDetails
            // 
            resources.ApplyResources(this.tbxDetails, "tbxDetails");
            this.tbxDetails.Name = "tbxDetails";
            // 
            // tbxState
            // 
            resources.ApplyResources(this.tbxState, "tbxState");
            this.tbxState.Name = "tbxState";
            // 
            // lblDetails
            // 
            resources.ApplyResources(this.lblDetails, "lblDetails");
            this.lblDetails.Name = "lblDetails";
            // 
            // lblState
            // 
            resources.ApplyResources(this.lblState, "lblState");
            this.lblState.Name = "lblState";
            // 
            // tbxSmallText
            // 
            resources.ApplyResources(this.tbxSmallText, "tbxSmallText");
            this.tbxSmallText.Name = "tbxSmallText";
            // 
            // tbxSmallImage
            // 
            resources.ApplyResources(this.tbxSmallImage, "tbxSmallImage");
            this.tbxSmallImage.Name = "tbxSmallImage";
            // 
            // tbxLargeText
            // 
            resources.ApplyResources(this.tbxLargeText, "tbxLargeText");
            this.tbxLargeText.Name = "tbxLargeText";
            // 
            // tbxLargeImage
            // 
            resources.ApplyResources(this.tbxLargeImage, "tbxLargeImage");
            this.tbxLargeImage.Name = "tbxLargeImage";
            // 
            // tbxTargetDomain
            // 
            resources.ApplyResources(this.tbxTargetDomain, "tbxTargetDomain");
            this.tbxTargetDomain.Name = "tbxTargetDomain";
            // 
            // tbxSourceDomain
            // 
            resources.ApplyResources(this.tbxSourceDomain, "tbxSourceDomain");
            this.tbxSourceDomain.Name = "tbxSourceDomain";
            // 
            // lblSmallText
            // 
            resources.ApplyResources(this.lblSmallText, "lblSmallText");
            this.lblSmallText.Name = "lblSmallText";
            // 
            // lblSmallImage
            // 
            resources.ApplyResources(this.lblSmallImage, "lblSmallImage");
            this.lblSmallImage.Name = "lblSmallImage";
            // 
            // lblLargeText
            // 
            resources.ApplyResources(this.lblLargeText, "lblLargeText");
            this.lblLargeText.Name = "lblLargeText";
            // 
            // lblLargeImage
            // 
            resources.ApplyResources(this.lblLargeImage, "lblLargeImage");
            this.lblLargeImage.Name = "lblLargeImage";
            // 
            // lblTargetDomain
            // 
            resources.ApplyResources(this.lblTargetDomain, "lblTargetDomain");
            this.lblTargetDomain.Name = "lblTargetDomain";
            // 
            // lblSourceDomain
            // 
            resources.ApplyResources(this.lblSourceDomain, "lblSourceDomain");
            this.lblSourceDomain.Name = "lblSourceDomain";
            // 
            // tbxProfileName
            // 
            resources.ApplyResources(this.tbxProfileName, "tbxProfileName");
            this.tbxProfileName.Name = "tbxProfileName";
            // 
            // lblProfileName
            // 
            resources.ApplyResources(this.lblProfileName, "lblProfileName");
            this.lblProfileName.Name = "lblProfileName";
            // 
            // btnAdd
            // 
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            resources.ApplyResources(this.btnUpdate, "btnUpdate");
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // chkAudible
            // 
            resources.ApplyResources(this.chkAudible, "chkAudible");
            this.chkAudible.Name = "chkAudible";
            this.chkAudible.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gbxOptions);
            this.Controls.Add(this.cbxProfiles);
            this.Controls.Add(this.lblProfiles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.gbxOptions.ResumeLayout(false);
            this.gbxOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblProfiles;
        private ComboBox cbxProfiles;
        private GroupBox gbxOptions;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TextBox tbxProfileName;
        private Label lblProfileName;
        private TextBox tbxSmallText;
        private TextBox tbxSmallImage;
        private TextBox tbxLargeText;
        private TextBox tbxLargeImage;
        private TextBox tbxTargetDomain;
        private TextBox tbxSourceDomain;
        private Label lblSmallText;
        private Label lblSmallImage;
        private Label lblLargeText;
        private Label lblLargeImage;
        private Label lblTargetDomain;
        private Label lblSourceDomain;
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
    }
}