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
            lblPort = new Label();
            btnOK = new Button();
            nudPort = new NumericUpDown();
            hlpProvider = new HelpProvider();
            nudDiscordClientId = new NumericUpDown();
            lblDicordClientId = new Label();
            chkAutoStart = new CheckBox();
            chkAutoStartWebservice = new CheckBox();
            gbxImgur = new GroupBox();
            tbxRefreshTokenImgur = new TextBox();
            tbxClientSecretImgur = new TextBox();
            tbxClientIdImgur = new TextBox();
            lblRefreshTokenImgur = new Label();
            lblClientSecretImgur = new Label();
            lblClientIdImgur = new Label();
            ((System.ComponentModel.ISupportInitialize)nudPort).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDiscordClientId).BeginInit();
            gbxImgur.SuspendLayout();
            SuspendLayout();
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Location = new Point(12, 22);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(32, 15);
            lblPort.TabIndex = 0;
            lblPort.Text = "Port:";
            // 
            // btnOK
            // 
            btnOK.Location = new Point(12, 295);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 5;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // nudPort
            // 
            nudPort.Location = new Point(146, 20);
            nudPort.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            nudPort.Name = "nudPort";
            nudPort.Size = new Size(133, 23);
            nudPort.TabIndex = 1;
            nudPort.KeyDown += nudPort_KeyDown;
            // 
            // nudDiscordClientId
            // 
            nudDiscordClientId.Location = new Point(146, 49);
            nudDiscordClientId.Maximum = new decimal(new int[] { 1661992959, 1808227885, 5, 0 });
            nudDiscordClientId.Name = "nudDiscordClientId";
            nudDiscordClientId.Size = new Size(133, 23);
            nudDiscordClientId.TabIndex = 2;
            nudDiscordClientId.KeyDown += nudDiscordClientId_KeyDown;
            // 
            // lblDicordClientId
            // 
            lblDicordClientId.AutoSize = true;
            lblDicordClientId.Location = new Point(12, 51);
            lblDicordClientId.Name = "lblDicordClientId";
            lblDicordClientId.Size = new Size(98, 15);
            lblDicordClientId.TabIndex = 3;
            lblDicordClientId.Text = "Discord Client ID:";
            // 
            // chkAutoStart
            // 
            chkAutoStart.CheckAlign = ContentAlignment.MiddleRight;
            chkAutoStart.Location = new Point(12, 80);
            chkAutoStart.Name = "chkAutoStart";
            chkAutoStart.Size = new Size(150, 24);
            chkAutoStart.TabIndex = 4;
            chkAutoStart.Text = "Auto Start:";
            chkAutoStart.UseVisualStyleBackColor = true;
            chkAutoStart.KeyDown += chkAutoStart_KeyDown;
            // 
            // chkAutoStartWebservice
            // 
            chkAutoStartWebservice.CheckAlign = ContentAlignment.MiddleRight;
            chkAutoStartWebservice.Location = new Point(12, 109);
            chkAutoStartWebservice.Name = "chkAutoStartWebservice";
            chkAutoStartWebservice.Size = new Size(150, 24);
            chkAutoStartWebservice.TabIndex = 5;
            chkAutoStartWebservice.Text = "Auto Start Webservice:";
            chkAutoStartWebservice.UseVisualStyleBackColor = true;
            chkAutoStartWebservice.KeyDown += chkAutoStartWebservice_KeyDown;
            // 
            // gbxImgur
            // 
            gbxImgur.BackColor = SystemColors.Window;
            gbxImgur.Controls.Add(tbxRefreshTokenImgur);
            gbxImgur.Controls.Add(tbxClientSecretImgur);
            gbxImgur.Controls.Add(tbxClientIdImgur);
            gbxImgur.Controls.Add(lblRefreshTokenImgur);
            gbxImgur.Controls.Add(lblClientSecretImgur);
            gbxImgur.Controls.Add(lblClientIdImgur);
            gbxImgur.Location = new Point(8, 139);
            gbxImgur.Name = "gbxImgur";
            gbxImgur.Size = new Size(281, 106);
            gbxImgur.TabIndex = 6;
            gbxImgur.TabStop = false;
            gbxImgur.Text = "Imgur";
            // 
            // tbxRefreshTokenImgur
            // 
            tbxRefreshTokenImgur.Location = new Point(138, 74);
            tbxRefreshTokenImgur.Name = "tbxRefreshTokenImgur";
            tbxRefreshTokenImgur.Size = new Size(133, 23);
            tbxRefreshTokenImgur.TabIndex = 5;
            tbxRefreshTokenImgur.KeyDown += tbxRefreshTokenImgur_KeyDown;
            // 
            // tbxClientSecretImgur
            // 
            tbxClientSecretImgur.Location = new Point(138, 45);
            tbxClientSecretImgur.Name = "tbxClientSecretImgur";
            tbxClientSecretImgur.Size = new Size(133, 23);
            tbxClientSecretImgur.TabIndex = 4;
            tbxClientSecretImgur.KeyDown += tbxClientSecretImgur_KeyDown;
            // 
            // tbxClientIdImgur
            // 
            tbxClientIdImgur.Location = new Point(138, 16);
            tbxClientIdImgur.Name = "tbxClientIdImgur";
            tbxClientIdImgur.Size = new Size(133, 23);
            tbxClientIdImgur.TabIndex = 3;
            tbxClientIdImgur.KeyDown += tbxClientIdImgur_KeyDown;
            // 
            // lblRefreshTokenImgur
            // 
            lblRefreshTokenImgur.AutoSize = true;
            lblRefreshTokenImgur.Location = new Point(12, 77);
            lblRefreshTokenImgur.Name = "lblRefreshTokenImgur";
            lblRefreshTokenImgur.Size = new Size(83, 15);
            lblRefreshTokenImgur.TabIndex = 2;
            lblRefreshTokenImgur.Text = "Refresh Token:";
            // 
            // lblClientSecretImgur
            // 
            lblClientSecretImgur.AutoSize = true;
            lblClientSecretImgur.Location = new Point(12, 48);
            lblClientSecretImgur.Name = "lblClientSecretImgur";
            lblClientSecretImgur.Size = new Size(76, 15);
            lblClientSecretImgur.TabIndex = 1;
            lblClientSecretImgur.Text = "Client Secret:";
            // 
            // lblClientIdImgur
            // 
            lblClientIdImgur.AutoSize = true;
            lblClientIdImgur.Location = new Point(12, 19);
            lblClientIdImgur.Name = "lblClientIdImgur";
            lblClientIdImgur.Size = new Size(55, 15);
            lblClientIdImgur.TabIndex = 0;
            lblClientIdImgur.Text = "Client ID:";
            // 
            // frmOptions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(293, 330);
            Controls.Add(gbxImgur);
            Controls.Add(chkAutoStartWebservice);
            Controls.Add(chkAutoStart);
            Controls.Add(lblDicordClientId);
            Controls.Add(nudDiscordClientId);
            Controls.Add(nudPort);
            Controls.Add(btnOK);
            Controls.Add(lblPort);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmOptions";
            ShowInTaskbar = false;
            Text = "Options";
            Load += frmOptions_Load;
            ((System.ComponentModel.ISupportInitialize)nudPort).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDiscordClientId).EndInit();
            gbxImgur.ResumeLayout(false);
            gbxImgur.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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