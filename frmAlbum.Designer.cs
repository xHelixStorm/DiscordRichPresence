namespace DiscordRichPresence
{
    partial class frmAlbum
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlbum));
            this.lblAlbums = new System.Windows.Forms.Label();
            this.cbxAlbums = new System.Windows.Forms.ComboBox();
            this.dgvImages = new System.Windows.Forms.DataGridView();
            this.clmAlbumId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAlbumName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmImageId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmImageUrl = new System.Windows.Forms.DataGridViewLinkColumn();
            this.clmKeyBind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pgbProgress = new System.Windows.Forms.ProgressBar();
            this.btnDeleteImage = new System.Windows.Forms.Button();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.btnDownloadAlbum = new System.Windows.Forms.Button();
            this.btnDeleteAlbum = new System.Windows.Forms.Button();
            this.btnAddAlbum = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.hlpProvider = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImages)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAlbums
            // 
            this.lblAlbums.AutoSize = true;
            this.lblAlbums.Location = new System.Drawing.Point(22, 28);
            this.lblAlbums.Name = "lblAlbums";
            this.lblAlbums.Size = new System.Drawing.Size(51, 15);
            this.lblAlbums.TabIndex = 0;
            this.lblAlbums.Text = "Albums:";
            // 
            // cbxAlbums
            // 
            this.cbxAlbums.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAlbums.FormattingEnabled = true;
            this.cbxAlbums.Location = new System.Drawing.Point(96, 25);
            this.cbxAlbums.Name = "cbxAlbums";
            this.cbxAlbums.Size = new System.Drawing.Size(152, 23);
            this.cbxAlbums.TabIndex = 1;
            this.cbxAlbums.SelectionChangeCommitted += new System.EventHandler(this.cbxAlbums_SelectionChangeCommitted);
            // 
            // dgvImages
            // 
            this.dgvImages.AllowDrop = true;
            this.dgvImages.AllowUserToAddRows = false;
            this.dgvImages.AllowUserToDeleteRows = false;
            this.dgvImages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmAlbumId,
            this.clmAlbumName,
            this.clmImageId,
            this.clmImageUrl,
            this.clmKeyBind,
            this.clmImage});
            this.dgvImages.Location = new System.Drawing.Point(12, 102);
            this.dgvImages.Name = "dgvImages";
            this.dgvImages.RowTemplate.Height = 25;
            this.dgvImages.ShowCellToolTips = false;
            this.dgvImages.Size = new System.Drawing.Size(943, 382);
            this.dgvImages.TabIndex = 8;
            this.dgvImages.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvImages_CellEndEdit);
            this.dgvImages.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvImages_CellMouseEnter);
            this.dgvImages.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvImages_CellMouseLeave);
            this.dgvImages.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvImages_DragDrop);
            this.dgvImages.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvImages_DragEnter);
            // 
            // clmAlbumId
            // 
            this.clmAlbumId.HeaderText = "Album ID";
            this.clmAlbumId.Name = "clmAlbumId";
            this.clmAlbumId.ReadOnly = true;
            this.clmAlbumId.Width = 150;
            // 
            // clmAlbumName
            // 
            this.clmAlbumName.HeaderText = "Album Name";
            this.clmAlbumName.Name = "clmAlbumName";
            this.clmAlbumName.ReadOnly = true;
            this.clmAlbumName.Width = 150;
            // 
            // clmImageId
            // 
            this.clmImageId.HeaderText = "Image ID";
            this.clmImageId.Name = "clmImageId";
            this.clmImageId.ReadOnly = true;
            this.clmImageId.Width = 150;
            // 
            // clmImageUrl
            // 
            this.clmImageUrl.HeaderText = "Image Url";
            this.clmImageUrl.Name = "clmImageUrl";
            this.clmImageUrl.ReadOnly = true;
            this.clmImageUrl.Width = 150;
            // 
            // clmKeyBind
            // 
            this.clmKeyBind.HeaderText = "Key Bind";
            this.clmKeyBind.Name = "clmKeyBind";
            this.clmKeyBind.Width = 150;
            // 
            // clmImage
            // 
            this.clmImage.HeaderText = "Image";
            this.clmImage.Name = "clmImage";
            this.clmImage.ReadOnly = true;
            this.clmImage.Width = 150;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Controls.Add(this.pgbProgress);
            this.groupBox1.Controls.Add(this.btnDeleteImage);
            this.groupBox1.Controls.Add(this.btnAddImage);
            this.groupBox1.Controls.Add(this.btnDownloadAlbum);
            this.groupBox1.Controls.Add(this.btnDeleteAlbum);
            this.groupBox1.Controls.Add(this.btnAddAlbum);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(943, 90);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // pgbProgress
            // 
            this.pgbProgress.Location = new System.Drawing.Point(6, 48);
            this.pgbProgress.Name = "pgbProgress";
            this.pgbProgress.Size = new System.Drawing.Size(362, 23);
            this.pgbProgress.Step = 1;
            this.pgbProgress.TabIndex = 7;
            this.pgbProgress.Visible = false;
            // 
            // btnDeleteImage
            // 
            this.btnDeleteImage.Location = new System.Drawing.Point(503, 47);
            this.btnDeleteImage.Name = "btnDeleteImage";
            this.btnDeleteImage.Size = new System.Drawing.Size(100, 23);
            this.btnDeleteImage.TabIndex = 7;
            this.btnDeleteImage.Text = "Delete Image";
            this.btnDeleteImage.UseVisualStyleBackColor = true;
            this.btnDeleteImage.Click += new System.EventHandler(this.btnDeleteImage_Click);
            // 
            // btnAddImage
            // 
            this.btnAddImage.Enabled = false;
            this.btnAddImage.Location = new System.Drawing.Point(397, 47);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(100, 23);
            this.btnAddImage.TabIndex = 6;
            this.btnAddImage.Text = "Add Image";
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // btnDownloadAlbum
            // 
            this.btnDownloadAlbum.Location = new System.Drawing.Point(609, 18);
            this.btnDownloadAlbum.Name = "btnDownloadAlbum";
            this.btnDownloadAlbum.Size = new System.Drawing.Size(100, 23);
            this.btnDownloadAlbum.TabIndex = 5;
            this.btnDownloadAlbum.Text = "Downl. Album";
            this.btnDownloadAlbum.UseVisualStyleBackColor = true;
            this.btnDownloadAlbum.Click += new System.EventHandler(this.btnDownloadAlbum_Click);
            // 
            // btnDeleteAlbum
            // 
            this.btnDeleteAlbum.Enabled = false;
            this.btnDeleteAlbum.Location = new System.Drawing.Point(503, 18);
            this.btnDeleteAlbum.Name = "btnDeleteAlbum";
            this.btnDeleteAlbum.Size = new System.Drawing.Size(100, 23);
            this.btnDeleteAlbum.TabIndex = 4;
            this.btnDeleteAlbum.Text = "Delete Album";
            this.btnDeleteAlbum.UseVisualStyleBackColor = true;
            this.btnDeleteAlbum.Click += new System.EventHandler(this.btnDeleteAlbum_Click);
            // 
            // btnAddAlbum
            // 
            this.btnAddAlbum.Location = new System.Drawing.Point(397, 18);
            this.btnAddAlbum.Name = "btnAddAlbum";
            this.btnAddAlbum.Size = new System.Drawing.Size(100, 23);
            this.btnAddAlbum.TabIndex = 3;
            this.btnAddAlbum.Text = "Add Album";
            this.btnAddAlbum.UseVisualStyleBackColor = true;
            this.btnAddAlbum.Click += new System.EventHandler(this.btnAddAlbum_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(242, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmAlbum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 492);
            this.Controls.Add(this.dgvImages);
            this.Controls.Add(this.cbxAlbums);
            this.Controls.Add(this.lblAlbums);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(80, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAlbum";
            this.hlpProvider.SetShowHelp(this, false);
            this.Text = "frmAlbum";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAlbum_FormClosing);
            this.Load += new System.EventHandler(this.frmAlbum_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvImages)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblAlbums;
        private ComboBox cbxAlbums;
        private DataGridView dgvImages;
        private GroupBox groupBox1;
        private Button btnAddImage;
        private Button btnDownloadAlbum;
        private Button btnDeleteAlbum;
        private Button btnAddAlbum;
        private Button btnSearch;
        private Button btnDownloadImage;
        private Button btnDeleteImage;
        private ProgressBar pgbProgress;
        private DataGridViewTextBoxColumn clmAlbumId;
        private DataGridViewTextBoxColumn clmAlbumName;
        private DataGridViewTextBoxColumn clmImageId;
        private DataGridViewLinkColumn clmImageUrl;
        private DataGridViewTextBoxColumn clmKeyBind;
        private DataGridViewImageColumn clmImage;
        private HelpProvider hlpProvider;
    }
}