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
            this.gbxImgur = new System.Windows.Forms.GroupBox();
            this.tbxRefreshTokenImgur = new System.Windows.Forms.TextBox();
            this.tbxClientSecretImgur = new System.Windows.Forms.TextBox();
            this.tbxClientIdImgur = new System.Windows.Forms.TextBox();
            this.lblRefreshTokenImgur = new System.Windows.Forms.Label();
            this.lblClientSecretImgur = new System.Windows.Forms.Label();
            this.lblClientIdImgur = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscordClientId)).BeginInit();
            this.gbxImgur.SuspendLayout();
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
            this.btnOK.Location = new System.Drawing.Point(12, 295);
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
            99999,
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
            this.chkAutoStart.TabIndex = 4;
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
            this.chkAutoStartWebservice.TabIndex = 5;
            this.chkAutoStartWebservice.Text = "Auto Start Webservice:";
            this.chkAutoStartWebservice.UseVisualStyleBackColor = true;
            this.chkAutoStartWebservice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkAutoStartWebservice_KeyDown);
            // 
            // gbxImgur
            // 
            this.gbxImgur.BackColor = System.Drawing.SystemColors.Window;
            this.gbxImgur.Controls.Add(this.tbxRefreshTokenImgur);
            this.gbxImgur.Controls.Add(this.tbxClientSecretImgur);
            this.gbxImgur.Controls.Add(this.tbxClientIdImgur);
            this.gbxImgur.Controls.Add(this.lblRefreshTokenImgur);
            this.gbxImgur.Controls.Add(this.lblClientSecretImgur);
            this.gbxImgur.Controls.Add(this.lblClientIdImgur);
            this.gbxImgur.Location = new System.Drawing.Point(8, 139);
            this.gbxImgur.Name = "gbxImgur";
            this.gbxImgur.Size = new System.Drawing.Size(281, 106);
            this.gbxImgur.TabIndex = 6;
            this.gbxImgur.TabStop = false;
            this.gbxImgur.Text = "Imgur";
            // 
            // tbxRefreshTokenImgur
            // 
            this.tbxRefreshTokenImgur.Location = new System.Drawing.Point(138, 74);
            this.tbxRefreshTokenImgur.Name = "tbxRefreshTokenImgur";
            this.tbxRefreshTokenImgur.Size = new System.Drawing.Size(133, 23);
            this.tbxRefreshTokenImgur.TabIndex = 5;
            this.tbxRefreshTokenImgur.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxRefreshTokenImgur_KeyDown);
            // 
            // tbxClientSecretImgur
            // 
            this.tbxClientSecretImgur.Location = new System.Drawing.Point(138, 45);
            this.tbxClientSecretImgur.Name = "tbxClientSecretImgur";
            this.tbxClientSecretImgur.Size = new System.Drawing.Size(133, 23);
            this.tbxClientSecretImgur.TabIndex = 4;
            this.tbxClientSecretImgur.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxClientSecretImgur_KeyDown);
            // 
            // tbxClientIdImgur
            // 
            this.tbxClientIdImgur.Location = new System.Drawing.Point(138, 16);
            this.tbxClientIdImgur.Name = "tbxClientIdImgur";
            this.tbxClientIdImgur.Size = new System.Drawing.Size(133, 23);
            this.tbxClientIdImgur.TabIndex = 3;
            this.tbxClientIdImgur.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxClientIdImgur_KeyDown);
            // 
            // lblRefreshTokenImgur
            // 
            this.lblRefreshTokenImgur.AutoSize = true;
            this.lblRefreshTokenImgur.Location = new System.Drawing.Point(12, 77);
            this.lblRefreshTokenImgur.Name = "lblRefreshTokenImgur";
            this.lblRefreshTokenImgur.Size = new System.Drawing.Size(83, 15);
            this.lblRefreshTokenImgur.TabIndex = 2;
            this.lblRefreshTokenImgur.Text = "Refresh Token:";
            // 
            // lblClientSecretImgur
            // 
            this.lblClientSecretImgur.AutoSize = true;
            this.lblClientSecretImgur.Location = new System.Drawing.Point(12, 48);
            this.lblClientSecretImgur.Name = "lblClientSecretImgur";
            this.lblClientSecretImgur.Size = new System.Drawing.Size(76, 15);
            this.lblClientSecretImgur.TabIndex = 1;
            this.lblClientSecretImgur.Text = "Client Secret:";
            // 
            // lblClientIdImgur
            // 
            this.lblClientIdImgur.AutoSize = true;
            this.lblClientIdImgur.Location = new System.Drawing.Point(12, 19);
            this.lblClientIdImgur.Name = "lblClientIdImgur";
            this.lblClientIdImgur.Size = new System.Drawing.Size(55, 15);
            this.lblClientIdImgur.TabIndex = 0;
            this.lblClientIdImgur.Text = "Client ID:";
            // 
            // frmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 330);
            this.Controls.Add(this.gbxImgur);
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
            this.gbxImgur.ResumeLayout(false);
            this.gbxImgur.PerformLayout();
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
        private GroupBox gbxImgur;
        private TextBox tbxRefreshTokenImgur;
        private TextBox tbxClientSecretImgur;
        private TextBox tbxClientIdImgur;
        private Label lblRefreshTokenImgur;
        private Label lblClientSecretImgur;
        private Label lblClientIdImgur;
    }
}