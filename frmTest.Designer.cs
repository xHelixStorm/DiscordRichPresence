namespace DiscordRichPresence
{
    partial class frmTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTest));
            this.gbxOptions = new System.Windows.Forms.GroupBox();
            this.chkAudible = new System.Windows.Forms.CheckBox();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.tbxDetails = new System.Windows.Forms.TextBox();
            this.tbxState = new System.Windows.Forms.TextBox();
            this.lblDetails = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.tbxSmallText = new System.Windows.Forms.TextBox();
            this.tbxSmallImage = new System.Windows.Forms.TextBox();
            this.tbxLargeText = new System.Windows.Forms.TextBox();
            this.tbxLargeImage = new System.Windows.Forms.TextBox();
            this.lblSmallText = new System.Windows.Forms.Label();
            this.lblSmallImage = new System.Windows.Forms.Label();
            this.lblLargeText = new System.Windows.Forms.Label();
            this.lblLargeImage = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbxOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxOptions
            // 
            this.gbxOptions.BackColor = System.Drawing.SystemColors.Window;
            this.gbxOptions.Controls.Add(this.btnClose);
            this.gbxOptions.Controls.Add(this.chkAudible);
            this.gbxOptions.Controls.Add(this.btnEnd);
            this.gbxOptions.Controls.Add(this.btnTest);
            this.gbxOptions.Controls.Add(this.tbxDetails);
            this.gbxOptions.Controls.Add(this.tbxState);
            this.gbxOptions.Controls.Add(this.lblDetails);
            this.gbxOptions.Controls.Add(this.lblState);
            this.gbxOptions.Controls.Add(this.tbxSmallText);
            this.gbxOptions.Controls.Add(this.tbxSmallImage);
            this.gbxOptions.Controls.Add(this.tbxLargeText);
            this.gbxOptions.Controls.Add(this.tbxLargeImage);
            this.gbxOptions.Controls.Add(this.lblSmallText);
            this.gbxOptions.Controls.Add(this.lblSmallImage);
            this.gbxOptions.Controls.Add(this.lblLargeText);
            this.gbxOptions.Controls.Add(this.lblLargeImage);
            this.gbxOptions.Location = new System.Drawing.Point(12, 7);
            this.gbxOptions.Name = "gbxOptions";
            this.gbxOptions.Size = new System.Drawing.Size(333, 301);
            this.gbxOptions.TabIndex = 6;
            this.gbxOptions.TabStop = false;
            this.gbxOptions.Text = "Options";
            // 
            // chkAudible
            // 
            this.chkAudible.AutoSize = true;
            this.chkAudible.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAudible.Location = new System.Drawing.Point(7, 234);
            this.chkAudible.Name = "chkAudible";
            this.chkAudible.Size = new System.Drawing.Size(70, 19);
            this.chkAudible.TabIndex = 23;
            this.chkAudible.Text = "Audible:";
            this.chkAudible.UseVisualStyleBackColor = true;
            // 
            // btnEnd
            // 
            this.btnEnd.Enabled = false;
            this.btnEnd.Location = new System.Drawing.Point(98, 264);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(75, 23);
            this.btnEnd.TabIndex = 25;
            this.btnEnd.Text = "End";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(11, 264);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 24;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // tbxDetails
            // 
            this.tbxDetails.Location = new System.Drawing.Point(119, 53);
            this.tbxDetails.Name = "tbxDetails";
            this.tbxDetails.Size = new System.Drawing.Size(200, 23);
            this.tbxDetails.TabIndex = 13;
            // 
            // tbxState
            // 
            this.tbxState.Location = new System.Drawing.Point(119, 17);
            this.tbxState.Name = "tbxState";
            this.tbxState.Size = new System.Drawing.Size(200, 23);
            this.tbxState.TabIndex = 11;
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Location = new System.Drawing.Point(7, 56);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(45, 15);
            this.lblDetails.TabIndex = 15;
            this.lblDetails.Text = "Details:";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(7, 20);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(36, 15);
            this.lblState.TabIndex = 14;
            this.lblState.Text = "State:";
            // 
            // tbxSmallText
            // 
            this.tbxSmallText.Location = new System.Drawing.Point(119, 196);
            this.tbxSmallText.Name = "tbxSmallText";
            this.tbxSmallText.Size = new System.Drawing.Size(200, 23);
            this.tbxSmallText.TabIndex = 21;
            // 
            // tbxSmallImage
            // 
            this.tbxSmallImage.Location = new System.Drawing.Point(119, 160);
            this.tbxSmallImage.Name = "tbxSmallImage";
            this.tbxSmallImage.Size = new System.Drawing.Size(200, 23);
            this.tbxSmallImage.TabIndex = 19;
            // 
            // tbxLargeText
            // 
            this.tbxLargeText.Location = new System.Drawing.Point(119, 127);
            this.tbxLargeText.Name = "tbxLargeText";
            this.tbxLargeText.Size = new System.Drawing.Size(200, 23);
            this.tbxLargeText.TabIndex = 17;
            // 
            // tbxLargeImage
            // 
            this.tbxLargeImage.Location = new System.Drawing.Point(119, 91);
            this.tbxLargeImage.Name = "tbxLargeImage";
            this.tbxLargeImage.Size = new System.Drawing.Size(200, 23);
            this.tbxLargeImage.TabIndex = 15;
            // 
            // lblSmallText
            // 
            this.lblSmallText.AutoSize = true;
            this.lblSmallText.Location = new System.Drawing.Point(7, 199);
            this.lblSmallText.Name = "lblSmallText";
            this.lblSmallText.Size = new System.Drawing.Size(63, 15);
            this.lblSmallText.TabIndex = 7;
            this.lblSmallText.Text = "Small Text:";
            // 
            // lblSmallImage
            // 
            this.lblSmallImage.AutoSize = true;
            this.lblSmallImage.Location = new System.Drawing.Point(7, 163);
            this.lblSmallImage.Name = "lblSmallImage";
            this.lblSmallImage.Size = new System.Drawing.Size(75, 15);
            this.lblSmallImage.TabIndex = 6;
            this.lblSmallImage.Text = "Small Image:";
            // 
            // lblLargeText
            // 
            this.lblLargeText.AutoSize = true;
            this.lblLargeText.Location = new System.Drawing.Point(7, 130);
            this.lblLargeText.Name = "lblLargeText";
            this.lblLargeText.Size = new System.Drawing.Size(63, 15);
            this.lblLargeText.TabIndex = 5;
            this.lblLargeText.Text = "Large Text:";
            // 
            // lblLargeImage
            // 
            this.lblLargeImage.AutoSize = true;
            this.lblLargeImage.Location = new System.Drawing.Point(7, 94);
            this.lblLargeImage.Name = "lblLargeImage";
            this.lblLargeImage.Size = new System.Drawing.Size(75, 15);
            this.lblLargeImage.TabIndex = 4;
            this.lblLargeImage.Text = "Large Image:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(185, 264);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 315);
            this.ControlBox = false;
            this.Controls.Add(this.gbxOptions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTest";
            this.ShowInTaskbar = false;
            this.Text = "Discord Rich Presence Tester";
            this.Load += new System.EventHandler(this.frmTest_Load);
            this.Shown += new System.EventHandler(this.frmTest_Shown);
            this.gbxOptions.ResumeLayout(false);
            this.gbxOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox gbxOptions;
        private CheckBox chkAudible;
        private Button btnEnd;
        private Button btnTest;
        private TextBox tbxDetails;
        private TextBox tbxState;
        private Label lblDetails;
        private Label lblState;
        private TextBox tbxSmallText;
        private TextBox tbxSmallImage;
        private TextBox tbxLargeText;
        private TextBox tbxLargeImage;
        private Label lblSmallText;
        private Label lblSmallImage;
        private Label lblLargeText;
        private Label lblLargeImage;
        private Button btnClose;
    }
}