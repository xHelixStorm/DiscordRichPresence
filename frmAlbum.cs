using DiscordRichPresence.constructors;
using DiscordRichPresence.modules;
using DiscordRichPresence.Tooltips;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscordRichPresence
{
    public partial class frmAlbum : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private static bool loadImages = false;
        private static ToolTip toolTip = new ToolTip();
        private static ImageTooltip imageToolTip = new ImageTooltip();

        public frmAlbum()
        {
            InitializeComponent();

            //Set initial tooltip values
            toolTip.Active = false;
            imageToolTip.Active = false;
            imageToolTip.SetToolTip(dgvImages, "Image");
        }

        private void frmAlbum_Load(object sender, EventArgs e)
        {
            logger.Info("Initialize Form frmAlbum");

            this.Cursor = Cursors.WaitCursor;
            //Fetch existing albums
            InitializeAlbums();
            //Initialize help provider
            InitializeHelpProvider();
            this.Cursor = Cursors.Default;
        }

        private void frmAlbum_FormClosing(object sender, FormClosingEventArgs e)
        {
            loadImages = false;
        }

        private void InitializeAlbums()
        {
            cbxAlbums.Items.Clear();
            cbxAlbums.Items.Add(new Album("", "<All Albums>", false));
            cbxAlbums.SelectedIndex = 0;
            var albums = modSQL.GetAllAlbums();
            if(albums != null)
            {
                foreach(var album in albums)
                {
                    cbxAlbums.Items.Add(album);
                }
            }
            else
            {
                logger.Error("Albums couldn't be obtained.");
                modUtil.throwError("Albums couldn't be retrieved! Please reopen the form.");
            }
        }

        private void InitializeHelpProvider()
        {
            hlpProvider.SetShowHelp(cbxAlbums, true);
            hlpProvider.SetShowHelp(chkDefault, true);
            hlpProvider.SetShowHelp(btnSearch, true);
            hlpProvider.SetShowHelp(btnAddAlbum, true);
            hlpProvider.SetShowHelp(btnDeleteAlbum, true);
            hlpProvider.SetShowHelp(btnDownloadAlbum, true);
            hlpProvider.SetShowHelp(btnAddImage, true);
            hlpProvider.SetShowHelp(btnDeleteImage, true);
            hlpProvider.SetShowHelp(dgvImages, true);

            hlpProvider.SetHelpString(cbxAlbums, "Display all downloaded or created Imgur albums.");
            hlpProvider.SetHelpString(chkDefault, "Defining an album as default album will result in automatically collect new images from sites where the Discord activity is triggered.");
            hlpProvider.SetHelpString(btnSearch, "Display all images below the selected album.");
            hlpProvider.SetHelpString(btnAddAlbum, "Create a new album on Imgur and display the created album in this application.");
            hlpProvider.SetHelpString(btnDeleteAlbum, "Delete the selected Album along with the images inside from Imgur and this application.");
            hlpProvider.SetHelpString(btnDownloadAlbum, "Provide an album id to download the album with its images from Imgur to this application.");
            hlpProvider.SetHelpString(btnAddImage, "Add one or more images to the selected album. Dragging and dropping images onto the grid works as well.");
            hlpProvider.SetHelpString(btnDeleteImage, "Delete one or more selected images in the grid from Imgur and this application.");
            hlpProvider.SetHelpString(dgvImages, "Show information of albums and images.");
        }

        private void cbxAlbums_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox item = sender as ComboBox;
            if(item != null)
            {
                Album album = (Album)item.SelectedItem;
                string value = album.AlbumId;
                bool enabled = value.Length > 0;

                btnDeleteAlbum.Enabled = enabled;
                btnAddImage.Enabled = enabled;

                if(album.AlbumId.Length > 0)
                {
                    chkDefault.Enabled = true;
                    chkDefault.Checked = album.IsDefault;
                }
                else
                {
                    chkDefault.Checked = false;
                    chkDefault.Enabled = false;
                }
            }

            btnSearch_Click(sender, e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            loadImages = false;

            dgvImages.Rows.Clear();
            string albumId = ((Album)cbxAlbums.SelectedItem).AlbumId;
            var images = modSQL.GetAlbumImages(albumId);
            if(images != null)
            {
                foreach (var image in images)
                {
                    dgvImages.Rows.Add(
                        image.Album.AlbumId,
                        image.Album.Name,
                        image.ImageId,
                        image.Url,
                        image.Key
                    );
                }
                LoadImages(dgvImages);
            }
            else
            {
                logger.Error("Images couldn't be retrieved for album {0}.", albumId);
                modUtil.throwError("Images couldn't be retrieved. Please try again!");
            }

            this.Cursor = Cursors.Default;
        }

        private async void LoadImages(DataGridView dgvImages)
        {
            loadImages = true;
            await Task.Run(async () =>
            {
                foreach(DataGridViewRow row in dgvImages.Rows)
                {
                    if (!loadImages) break;
                    try
                    {
                        var request = new HttpRequestMessage(HttpMethod.Get, row.Cells[3].Value.ToString());
                        var response = await modUtil.GetHttpClient().SendAsync(request);
                        response.EnsureSuccessStatusCode();
                        Bitmap bmp = new Bitmap(await response.Content.ReadAsStreamAsync());
                        row.Cells[5].Value = bmp;
                        row.Cells[5].Tag = bmp;
                    } catch( Exception ex)
                    {
                        logger.Warn(ex, "Image {0} couldn't be loaded", row.Cells[3].Value.ToString());
                    }
                }
            });
            loadImages = false;
        }

        private void btnAddAlbum_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Please insert the name of the new album.", "Album creation");
            if (input.Length == 0) return;
            Album album = new Album("", input, false);

            try
            {
                album.CreateAlbum();
                InitializeAlbums();

                var index = 0;
                for (index = 0; index < cbxAlbums.Items.Count; index++)
                {
                    if (((Album)cbxAlbums.Items[index]).AlbumId == album.AlbumId)
                        break;
                }
                cbxAlbums.SelectedIndex = index;
                btnSearch_Click(sender, e);
                cbxAlbums_SelectionChangeCommitted(cbxAlbums, e);
            } catch(Exception ex)
            {
                logger.Error(ex, "Album couldn't be created");
                modUtil.throwError("Album coulnd't be created. Please try again!");
            }
        }

        private async void btnDeleteAlbum_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;

            Album album = cbxAlbums.SelectedItem as Album;
            if(album != null && album.AlbumId.Length > 0)
            {
                DialogResult result = MessageBox.Show("Do you really want to delete this album? Note that all images under this album will be deleted in Imgur as well.", "Delete album", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    List<Img> images = modSQL.GetAlbumImages(album.AlbumId);
                    if (images != null)
                    {
                        pgbProgress.Visible = true;
                        pgbProgress.Value = 0;
                        pgbProgress.Maximum = images.Count;

                        foreach (Img img in images)
                        {
                            try
                            {
                                await img.ImageDelete();
                            } catch(Exception ex)
                            {
                                logger.Error(ex, "Image with the id {0} couldn't be deleted", img.ImageId);
                            }
                            pgbProgress.PerformStep();
                        }

                        try
                        {
                            album.DeleteAlbum();
                        }
                        catch (Exception ex)
                        {
                            logger.Error(ex, "All images for the selected album {0} except the album have been deleted.", album.AlbumId);
                            modUtil.throwError("All images for the selected album except the album have been deleted.");
                        }

                        InitializeAlbums();

                        pgbProgress.Visible = false;
                    }
                    else
                    {
                        logger.Error("Album images couldn't be retrieved.");
                        modUtil.throwError("Album couldn't be deleted. Please try again!");
                    }
                }
            }

            this.Enabled = true;
            this.Cursor = Cursors.Default;
        }

        private void btnDownloadAlbum_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            string input = Interaction.InputBox("Please insert the id of the album, which may contain images, to download.", "Album download");
            if (input.Length > 0)
            {
                Album album = new Album(input, "", false);

                pgbProgress.Visible = true;
                pgbProgress.Value = 0;

                try
                {
                    JArray images = album.DownloadAlbum();
                    pgbProgress.Maximum = images.Count;

                    foreach (JObject image in images)
                    {
                        Img img = new Img(
                            (string)image.GetValue("id"),
                            (string)image.GetValue("link"),
                            "",
                            album
                        );
                        if (modSQL.InsertImage(img) < 0)
                        {
                            throw new Exception("Image couldn't be saved.");
                        }
                        pgbProgress.PerformStep();
                    }

                    InitializeAlbums();

                    var index = 0;
                    for(index = 0; index < cbxAlbums.Items.Count; index++)
                    {
                        if (((Album)cbxAlbums.Items[index]).AlbumId == album.AlbumId)
                            break;
                    }
                    cbxAlbums.SelectedIndex = index;
                    btnSearch_Click(sender, e);
                    cbxAlbums_SelectionChangeCommitted(cbxAlbums, e);
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Download of Album failed");
                    modUtil.throwError("Download of Album failed. Please try again!");
                }

                pgbProgress.Visible = false;
            }

            this.Cursor = Cursors.Default;
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = "c:\\";
            fileDialog.Filter = "Image Files(*.JPG;*.GIF;*.PNG)|*.JPG;*.GIF;*.PNG";
            fileDialog.RestoreDirectory = true;
            fileDialog.Multiselect = true;

            DialogResult result = fileDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                Album album = cbxAlbums.SelectedItem as Album;
                if(album != null)
                {
                    this.Cursor = Cursors.WaitCursor;

                    bool err = false;
                    foreach (var file in fileDialog.FileNames)
                    {
                        Img image = new Img("", "", "", album);
                        try {
                            image.UploadImage(file);
                        } catch(Exception ex)
                        {
                            logger.Error(ex, "Image couldn't be uploaded to Imgur");
                            err = true;
                        }
                    }
                    btnSearch_Click(sender, e);

                    if(err)
                        modUtil.throwError("One or more images couldn't be uploaded.");

                    this.Cursor = Cursors.Default;
                }
            }
        }

        private async void btnDeleteImage_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to delete the selected image(s)? The image(s) will be deleted from Imgur as well.", "Image deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(DialogResult.Yes == result)
            {
                this.Cursor = Cursors.WaitCursor;

                bool err = false;
                var rows = dgvImages.SelectedRows;
                foreach (DataGridViewRow row in rows)
                {
                    var cells = row.Cells;
                    Img img = new Img(
                        cells[2].Value.ToString(),
                        cells[3].Value.ToString(),
                        "",
                        new Album(
                            cells[0].Value.ToString(),
                            cells[1].Value.ToString(),
                            false
                        )
                    );
                    try
                    {
                        await img.ImageDelete();
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex, "Image {0} couldn't be deleted", img.ImageId);
                        err = true;
                    }
                }

                btnSearch_Click(sender, e);

                if (err)
                    modUtil.throwError("One or more images couldn't be deleted.");

                this.Cursor = Cursors.Default;
            }
        }

        private void dgvImages_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            var item = sender as DataGridView;
            if (item != null)
            {
                if (e.RowIndex == -1) return;
                var row = item.Rows[e.RowIndex];
                if (row != null)
                {
                    if (e.ColumnIndex >= 0 && e.ColumnIndex < 5)
                    {
                        var cell = row.Cells[e.ColumnIndex];
                        if(cell.Value != null)
                        {
                            toolTip.SetToolTip(dgvImages, cell.Value.ToString());
                            toolTip.Active = true;
                        }
                    }
                    else if (e.ColumnIndex == 5)
                    {
                        var cell = row.Cells[e.ColumnIndex];
                        if (cell.Tag != null)
                        {
                            imageToolTip.SetImage((Bitmap)cell.Tag);
                            imageToolTip.Active = true;
                        }
                    }
                }
            }
        }

        private void dgvImages_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            toolTip.Active = false;
            imageToolTip.Active = false;
        }

        private void dgvImages_DragDrop(object sender, DragEventArgs e)
        {
            if(e.Data != null)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    Album album = cbxAlbums.SelectedItem as Album;
                    if(album != null && album.AlbumId.Length > 0)
                    {
                        this.Cursor = Cursors.WaitCursor;

                        bool err = false;
                        string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop);
                        foreach (string file in fileList)
                        {
                            Img image = new Img("", "", "", album);
                            try
                            {
                                image.UploadImage(file);
                            }
                            catch (Exception ex)
                            {
                                logger.Error(ex, "Image couldn't be uploaded to Imgur");
                                err = true;
                            }
                        }

                        btnSearch_Click(sender, e);

                        if (err)
                            modUtil.throwError("One or more files couldn't be uploaded. Please try again!");

                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        private void dgvImages_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data != null)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.Move;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }

        private void dgvImages_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var item = sender as DataGridView;
            if (item != null)
            {
                if (e.RowIndex == -1) return;
                var row = item.Rows[e.RowIndex];
                if (row != null)
                {
                    var keyBind = row.Cells[4].Value;
                    var imageId = row.Cells[2].Value.ToString();
                    if(modSQL.UpdateImageKeyBind(imageId, keyBind != null ? keyBind.ToString() : "") < 0)
                    {
                        logger.Error("Key Bind for image {0} couldn't be updated", imageId);
                        modUtil.throwError("Key Bind couldn't be updated. Please try again!");
                    }
                }
            }
        }

        private void chkDefault_Click(object sender, EventArgs e)
        {
            CheckBox checkbox = sender as CheckBox;
            if(checkbox != null)
            {
                if (checkbox.Checked)
                {
                    Album album = modSQL.GetDefaultAlbum();
                    Album curAlbum = (Album)cbxAlbums.SelectedItem;
                    if (album != null && album.AlbumId != curAlbum.AlbumId)
                    {
                        DialogResult result = MessageBox.Show("A default album has been already defined. Do you wish to make this your default album?", "Default album", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            if(modSQL.UpdateAlbumDefault(album.AlbumId, false) > 0)
                            {
                                if(modSQL.UpdateAlbumDefault(curAlbum.AlbumId, true) == 0)
                                {
                                    logger.Error("Default album couldn't be updated");
                                    modUtil.throwError("Default album couldn't be updated. Please try again!");
                                }
                            }
                            else
                            {
                                logger.Error("Default album couldn't be updated");
                                modUtil.throwError("Default album couldn't be updated. Please try again!");
                            }
                        }
                    }
                    else
                    {
                        if (modSQL.UpdateAlbumDefault(curAlbum.AlbumId, true) == 0)
                        {
                            logger.Error("Default album couldn't be updated");
                            modUtil.throwError("Default album couldn't be updated. Please try again!");
                        }
                    }
                }
                else
                {
                    if (modSQL.UpdateAlbumDefault(((Album)cbxAlbums.SelectedItem).AlbumId, false) == 0)
                    {
                        logger.Error("Default album couldn't be updated");
                        modUtil.throwError("Default album couldn't be updated. Please try again!");
                    }
                }
            }
        }
    }
}
