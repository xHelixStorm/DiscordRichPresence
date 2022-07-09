namespace DiscordRichPresence
{
    partial class frmOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOptions));
            this.lblPort = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.hlpProvider = new System.Windows.Forms.HelpProvider();
            this.nudDiscordClientId = new System.Windows.Forms.NumericUpDown();
            this.lblDicordClientId = new System.Windows.Forms.Label();
            this.chkAutoStart = new System.Windows.Forms.CheckBox();
            this.chkAutoStartWebservice = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscordClientId)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(12, 22);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(32, 15);
            this.lblPort.TabIndex = 0;
            this.lblPort.Text = "Port:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 149);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // nudPort
            // 
            this.nudPort.Location = new System.Drawing.Point(146, 20);
            this.nudPort.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(133, 23);
            this.nudPort.TabIndex = 1;
            this.nudPort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudPort_KeyDown);
            // 
            // nudDiscordClientId
            // 
            this.nudDiscordClientId.Location = new System.Drawing.Point(146, 49);
            this.nudDiscordClientId.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            0});
            this.nudDiscordClientId.Name = "nudDiscordClientId";
            this.nudDiscordClientId.Size = new System.Drawing.Size(133, 23);
            this.nudDiscordClientId.TabIndex = 2;
            this.nudDiscordClientId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudDiscordClientId_KeyDown);
            // 
            // lblDicordClientId
            // 
            this.lblDicordClientId.AutoSize = true;
            this.lblDicordClientId.Location = new System.Drawing.Point(12, 51);
            this.lblDicordClientId.Name = "lblDicordClientId";
            this.lblDicordClientId.Size = new System.Drawing.Size(98, 15);
            this.lblDicordClientId.TabIndex = 3;
            this.lblDicordClientId.Text = "Discord Client ID:";
            // 
            // chkAutoStart
            // 
            this.chkAutoStart.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAutoStart.Location = new System.Drawing.Point(12, 80);
            this.chkAutoStart.Name = "chkAutoStart";
            this.chkAutoStart.Size = new System.Drawing.Size(150, 24);
            this.chkAutoStart.TabIndex = 3;
            this.chkAutoStart.Text = "Auto Start:";
            this.chkAutoStart.UseVisualStyleBackColor = true;
            this.chkAutoStart.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkAutoStart_KeyDown);
            // 
            // chkAutoStartWebservice
            // 
            this.chkAutoStartWebservice.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAutoStartWebservice.Location = new System.Drawing.Point(12, 109);
            this.chkAutoStartWebservice.Name = "chkAutoStartWebservice";
            this.chkAutoStartWebservice.Size = new System.Drawing.Size(150, 24);
            this.chkAutoStartWebservice.TabIndex = 4;
            this.chkAutoStartWebservice.Text = "Auto Start Webservice:";
            this.chkAutoStartWebservice.UseVisualStyleBackColor = true;
            this.chkAutoStartWebservice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkAutoStartWebservice_KeyDown);
            // 
            // frmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 188);
            this.Controls.Add(this.chkAutoStartWebservice);
            this.Controls.Add(this.chkAutoStart);
            this.Controls.Add(this.lblDicordClientId);
            this.Controls.Add(this.nudDiscordClientId);
            this.Controls.Add(this.nudPort);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblPort);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOptions";
            this.ShowInTaskbar = false;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.frmOptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscordClientId)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblPort;
        private Button btnOK;
        private NumericUpDown nudPort;
        private HelpProvider hlpProvider;
        private NumericUpDown nudDiscordClientId;
        private Label lblDicordClientId;
        private CheckBox chkAutoStart;
        private CheckBox chkAutoStartWebservice;
    }
}