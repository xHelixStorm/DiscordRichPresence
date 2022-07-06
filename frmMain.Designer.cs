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
            this.lblProfiles = new System.Windows.Forms.Label();
            this.cbxProfiles = new System.Windows.Forms.ComboBox();
            this.gbxOptions = new System.Windows.Forms.GroupBox();
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
            this.tbxName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gbxOptions.SuspendLayout();
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
            this.cbxProfiles.Name = "cbxProfiles";
            this.cbxProfiles.Size = new System.Drawing.Size(121, 23);
            this.cbxProfiles.TabIndex = 1;
            this.cbxProfiles.SelectionChangeCommitted += new System.EventHandler(this.cbxProfiles_SelectionChangeCommitted);
            // 
            // gbxOptions
            // 
            this.gbxOptions.BackColor = System.Drawing.SystemColors.Window;
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
            this.gbxOptions.Controls.Add(this.tbxName);
            this.gbxOptions.Controls.Add(this.lblName);
            this.gbxOptions.Location = new System.Drawing.Point(12, 35);
            this.gbxOptions.Name = "gbxOptions";
            this.gbxOptions.Size = new System.Drawing.Size(526, 403);
            this.gbxOptions.TabIndex = 2;
            this.gbxOptions.TabStop = false;
            this.gbxOptions.Text = "Options";
            // 
            // tbxDetails
            // 
            this.tbxDetails.Enabled = false;
            this.tbxDetails.Location = new System.Drawing.Point(119, 160);
            this.tbxDetails.Name = "tbxDetails";
            this.tbxDetails.Size = new System.Drawing.Size(200, 23);
            this.tbxDetails.TabIndex = 17;
            // 
            // tbxState
            // 
            this.tbxState.Enabled = false;
            this.tbxState.Location = new System.Drawing.Point(119, 124);
            this.tbxState.Name = "tbxState";
            this.tbxState.Size = new System.Drawing.Size(200, 23);
            this.tbxState.TabIndex = 16;
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Location = new System.Drawing.Point(7, 163);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(45, 15);
            this.lblDetails.TabIndex = 15;
            this.lblDetails.Text = "Details:";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(7, 127);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(36, 15);
            this.lblState.TabIndex = 14;
            this.lblState.Text = "State:";
            // 
            // tbxSmallText
            // 
            this.tbxSmallText.Enabled = false;
            this.tbxSmallText.Location = new System.Drawing.Point(119, 303);
            this.tbxSmallText.Name = "tbxSmallText";
            this.tbxSmallText.Size = new System.Drawing.Size(200, 23);
            this.tbxSmallText.TabIndex = 13;
            // 
            // tbxSmallImage
            // 
            this.tbxSmallImage.Enabled = false;
            this.tbxSmallImage.Location = new System.Drawing.Point(119, 267);
            this.tbxSmallImage.Name = "tbxSmallImage";
            this.tbxSmallImage.Size = new System.Drawing.Size(200, 23);
            this.tbxSmallImage.TabIndex = 12;
            // 
            // tbxLargeText
            // 
            this.tbxLargeText.Enabled = false;
            this.tbxLargeText.Location = new System.Drawing.Point(119, 234);
            this.tbxLargeText.Name = "tbxLargeText";
            this.tbxLargeText.Size = new System.Drawing.Size(200, 23);
            this.tbxLargeText.TabIndex = 11;
            // 
            // tbxLargeImage
            // 
            this.tbxLargeImage.Enabled = false;
            this.tbxLargeImage.Location = new System.Drawing.Point(119, 198);
            this.tbxLargeImage.Name = "tbxLargeImage";
            this.tbxLargeImage.Size = new System.Drawing.Size(200, 23);
            this.tbxLargeImage.TabIndex = 10;
            // 
            // tbxTargetDomain
            // 
            this.tbxTargetDomain.Enabled = false;
            this.tbxTargetDomain.Location = new System.Drawing.Point(119, 88);
            this.tbxTargetDomain.Name = "tbxTargetDomain";
            this.tbxTargetDomain.Size = new System.Drawing.Size(200, 23);
            this.tbxTargetDomain.TabIndex = 9;
            // 
            // tbxSourceDomain
            // 
            this.tbxSourceDomain.Enabled = false;
            this.tbxSourceDomain.Location = new System.Drawing.Point(119, 52);
            this.tbxSourceDomain.Name = "tbxSourceDomain";
            this.tbxSourceDomain.Size = new System.Drawing.Size(200, 23);
            this.tbxSourceDomain.TabIndex = 8;
            // 
            // lblSmallText
            // 
            this.lblSmallText.AutoSize = true;
            this.lblSmallText.Location = new System.Drawing.Point(7, 306);
            this.lblSmallText.Name = "lblSmallText";
            this.lblSmallText.Size = new System.Drawing.Size(63, 15);
            this.lblSmallText.TabIndex = 7;
            this.lblSmallText.Text = "Small Text:";
            // 
            // lblSmallImage
            // 
            this.lblSmallImage.AutoSize = true;
            this.lblSmallImage.Location = new System.Drawing.Point(7, 270);
            this.lblSmallImage.Name = "lblSmallImage";
            this.lblSmallImage.Size = new System.Drawing.Size(75, 15);
            this.lblSmallImage.TabIndex = 6;
            this.lblSmallImage.Text = "Small Image:";
            // 
            // lblLargeText
            // 
            this.lblLargeText.AutoSize = true;
            this.lblLargeText.Location = new System.Drawing.Point(7, 237);
            this.lblLargeText.Name = "lblLargeText";
            this.lblLargeText.Size = new System.Drawing.Size(63, 15);
            this.lblLargeText.TabIndex = 5;
            this.lblLargeText.Text = "Large Text:";
            // 
            // lblLargeImage
            // 
            this.lblLargeImage.AutoSize = true;
            this.lblLargeImage.Location = new System.Drawing.Point(7, 201);
            this.lblLargeImage.Name = "lblLargeImage";
            this.lblLargeImage.Size = new System.Drawing.Size(75, 15);
            this.lblLargeImage.TabIndex = 4;
            this.lblLargeImage.Text = "Large Image:";
            // 
            // lblTargetDomain
            // 
            this.lblTargetDomain.AutoSize = true;
            this.lblTargetDomain.Location = new System.Drawing.Point(7, 91);
            this.lblTargetDomain.Name = "lblTargetDomain";
            this.lblTargetDomain.Size = new System.Drawing.Size(87, 15);
            this.lblTargetDomain.TabIndex = 3;
            this.lblTargetDomain.Text = "Target Domain:";
            // 
            // lblSourceDomain
            // 
            this.lblSourceDomain.AutoSize = true;
            this.lblSourceDomain.Location = new System.Drawing.Point(7, 55);
            this.lblSourceDomain.Name = "lblSourceDomain";
            this.lblSourceDomain.Size = new System.Drawing.Size(91, 15);
            this.lblSourceDomain.TabIndex = 2;
            this.lblSourceDomain.Text = "Source Domain:";
            // 
            // tbxName
            // 
            this.tbxName.Enabled = false;
            this.tbxName.Location = new System.Drawing.Point(119, 16);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(200, 23);
            this.tbxName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(7, 19);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(42, 15);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gbxOptions);
            this.Controls.Add(this.cbxProfiles);
            this.Controls.Add(this.lblProfiles);
            this.Name = "frmMain";
            this.Text = "Discord Rich Presence Creator";
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
        private TextBox tbxName;
        private Label lblName;
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
    }
}