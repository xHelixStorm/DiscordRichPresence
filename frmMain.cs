using DiscordRichPresence.constructors;
using DiscordRichPresence.modules;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscordRichPresence
{
    public partial class frmMain : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public frmMain()
        {
            InitializeComponent();

            logger.Info("Initialize Form");

            //Begin to fetch all existing Profiles
            fetchAllProfiles();
        }

        private void fetchAllProfiles()
        {
            cbxProfiles.Items.Clear();
            var profiles = modSQL.fetchAllProfiles();
            if (profiles != null && profiles.Count > 0)
            {
                cbxProfiles.Enabled = true;
                profiles.ForEach(profile => cbxProfiles.Items.Add(profile));
            }
            else if (profiles == null)
            {
                Console.WriteLine("Profiles couldn't be obtained!");
            }
        }

        private void cbxProfiles_SelectionChangeCommitted(object sender, EventArgs e)
        {
            logger.Debug("SelectionChangeCommitted event thrown for field cbxProfiles");
            ComboBox item = sender as ComboBox;
            if(item != null)
            {
                Profile profile = item.SelectedItem as Profile;
                fillOptionsGroupBox(profile);
            }
            else
            {
                fillOptionsGroupBox(null);
            }
        }

        private void fillOptionsGroupBox(Profile? profile)
        {
            string name = "";
            string sourceDomain = "";
            string targetDomain = "";
            string state = "";
            string details = "";
            string largeImage = "";
            string largeText = "";
            string smallImage = "";
            string smallText = "";

            if(profile != null)
            {
                name = profile.Name;
                sourceDomain = profile.SourceDomain;
                targetDomain = profile.TargetDomain;
                state = profile.State;
                details = profile.Details;
                largeImage = profile.LargeImage;
                largeText = profile.LargeText;
                smallImage = profile.SmallImage;
                smallText = profile.SmallText;
            }

            tbxName.Text = name;
            tbxSourceDomain.Text = sourceDomain;
            tbxTargetDomain.Text = targetDomain;
            tbxState.Text = state;
            tbxDetails.Text = details;
            tbxLargeImage.Text = largeImage;
            tbxLargeText.Text = largeText;
            tbxSmallImage.Text = smallImage;
            tbxSmallText.Text = smallText;
        }
    }
}
