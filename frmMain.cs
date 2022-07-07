using DiscordRichPresence.constructors;
using DiscordRichPresence.enums;
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

        private bool insertMode = false;
        private bool updateMode = false;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            logger.Info("Initialize Form");
            //initialize combo box for the activity type selections
            initializeActivityTypes();
            //Fetch all existing Profiles
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
                cbxProfiles.Enabled = false;
                modUtil.throwError("Profiles couldn't be obtained");
            }
            else
            {
                cbxProfiles.Enabled = false;
            }
            fillOptionsGroupBox(null);
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void initializeActivityTypes()
        {
            foreach(ActivityType activityType in Enum.GetValues(typeof(ActivityType))){
                IActivityType activity = new IActivityType(activityType);
                cbxTypes.Items.Add(activity);
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
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
            }
            else
            {
                fillOptionsGroupBox(null);
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
            }
        }

        private void fillOptionsGroupBox(Profile? profile)
        {
            string profileName = "";
            string sourceDomain = "";
            string targetDomain = "";
            int typeIndex = 0;
            string name = "";
            string state = "";
            bool targetState = false;
            string details = "";
            bool targetDetails = false;
            string largeImage = "";
            bool targetLargeImage = false;
            string largeText = "";
            bool targetLargeText = false;
            string smallImage = "";
            bool targetSmallImage = false;
            string smallText = "";
            bool targetSmallText = false;
            bool audible = false;

            if(profile != null)
            {
                int sourceLength = "source;".Length;
                int targetLength = "target;".Length;

                profileName = profile.ProfileName;
                sourceDomain = profile.SourceDomain;
                targetDomain = profile.TargetDomain;
                for (int i = 0; i < cbxTypes.Items.Count; i++)
                {
                    if (((IActivityType)cbxTypes.Items[i]).Type == profile.Type)
                    {
                        typeIndex = i;
                        break;
                    }
                }
                name = profile.Name;
                if(profile.State.StartsWith("target;"))
                {
                    state = profile.State.Substring(targetLength);
                    targetState = true;
                }
                else
                {
                    state = profile.State.Substring(sourceLength);
                }
                if(profile.Details.StartsWith("target;"))
                {
                    details = profile.Details.Substring(targetLength);
                    targetDetails = true;
                }
                else
                {
                    details = profile.Details.Substring(sourceLength);
                }
                if (profile.LargeImage.StartsWith("target;"))
                {
                    largeImage = profile.LargeImage.Substring(targetLength);
                    targetLargeImage = true;
                }
                else
                {
                    largeImage = profile.LargeImage.Substring(sourceLength);
                }
                if(profile.LargeText.StartsWith("target;"))
                {
                    largeText = profile.LargeText.Substring(targetLength);
                    targetLargeText = true;
                }
                else
                {
                    largeText = profile.LargeText.Substring(sourceLength);
                }
                if (profile.SmallImage.StartsWith("target;"))
                {
                    smallImage = profile.SmallImage.Substring(targetLength);
                    targetSmallImage = true;
                }
                else
                {
                    smallImage = profile.SmallImage.Substring(sourceLength);
                }
                if (profile.SmallText.StartsWith("target;"))
                {
                    smallText = profile.SmallText.Substring(targetLength);
                    targetSmallText = true;
                }
                else
                {
                    smallText = profile.SmallText.Substring(sourceLength);
                }
                audible = profile.Audible;
            }

            tbxProfileName.Text = profileName;
            tbxSourceDomain.Text = sourceDomain;
            tbxTargetDomain.Text = targetDomain;
            cbxTypes.SelectedIndex = typeIndex;
            tbxName.Text = name;
            tbxState.Text = state;
            chkTargetState.Checked = targetState;
            tbxDetails.Text = details;
            chkTargetDetails.Checked = targetDetails;
            tbxLargeImage.Text = largeImage;
            chkTargetLargeImage.Checked = targetLargeImage;
            tbxLargeText.Text = largeText;
            chkTargetLargeText.Checked = targetLargeText;
            tbxSmallImage.Text = smallImage;
            chkTargetSmallImage.Checked = targetSmallImage;
            tbxSmallText.Text = smallText;
            chkTargetSmallText.Checked = targetSmallText;
            chkAudible.Checked = audible;
        }

        private void handleFieldEnableMode()
        {
            bool enabled = (insertMode || updateMode);

            cbxProfiles.Enabled = !enabled;
            btnAdd.Enabled = !enabled;
            btnUpdate.Enabled = !enabled;
            btnDelete.Enabled = !enabled;

            tbxProfileName.Enabled = enabled;
            tbxSourceDomain.Enabled = enabled;
            tbxTargetDomain.Enabled = enabled;
            cbxTypes.Enabled = enabled;
            tbxName.Enabled = enabled;
            tbxState.Enabled = enabled;
            chkTargetState.Enabled = enabled;
            tbxDetails.Enabled = enabled;
            chkTargetDetails.Enabled = enabled;
            tbxLargeImage.Enabled = enabled;
            chkTargetLargeImage.Enabled = enabled;
            tbxLargeText.Enabled = enabled;
            chkTargetLargeText.Enabled = enabled;
            tbxSmallImage.Enabled = enabled;
            chkTargetSmallImage.Enabled = enabled;
            tbxSmallText.Enabled = enabled;
            chkTargetSmallText.Enabled = enabled;
            chkAudible.Enabled = enabled;

            btnSave.Enabled = enabled;
            btnCancel.Enabled = enabled;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            insertMode = true;
            cbxProfiles.SelectedIndex = -1;
            fillOptionsGroupBox(null);
            handleFieldEnableMode();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateMode = true;
            handleFieldEnableMode();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            const string title = "Delete Profile";
            const string message = "Do you really want to delete the selected profile?";
            DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(result == DialogResult.Yes)
            {
                int dbResult = -1;
                var profile = cbxProfiles.SelectedItem as Profile;
                if(profile != null)
                {
                    dbResult = modSQL.deleteProfile(profile.ProfileId);
                }
                if(dbResult > 0)
                {
                    fetchAllProfiles();
                }
                else
                {
                    modUtil.throwError("Profile couldn't be deleted");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile(
                (cbxProfiles.SelectedItem != null ? ((Profile)cbxProfiles.SelectedItem).ProfileId: 0),
                tbxProfileName.Text,
                tbxSourceDomain.Text,
                tbxTargetDomain.Text,
                (cbxTypes.SelectedItem != null ? ((IActivityType)cbxTypes.SelectedItem).Type : (int)ActivityType.Playing),
                tbxName.Text,
                (chkTargetState.Checked ? "target;" : "source;")+tbxState.Text,
                (chkTargetDetails.Checked ? "target;" : "source;") + tbxDetails.Text,
                (chkTargetLargeImage.Checked ? "target;" : "source;") + tbxLargeImage.Text,
                (chkTargetLargeText.Checked ? "target;" : "source;") + tbxLargeText.Text,
                (chkTargetSmallImage.Checked ? "target;" : "source;") + tbxSmallImage.Text,
                (chkTargetSmallText.Checked ? "target;" : "source;") + tbxSmallText.Text,
                chkAudible.Checked
            );
            if (insertMode)
            {
                int result = modSQL.insertProfile(profile);
                if(result > 0)
                {
                    fetchAllProfiles();
                    insertMode = false;
                    handleFieldEnableMode();
                }
                else
                {
                    modUtil.throwError("New Profile couldn't be saved. Please try again!");
                }
            }
            else if (updateMode)
            {
                int result = modSQL.updateProfile(profile);
                if(result > 0)
                {
                    int profileId = profile.ProfileId;
                    fetchAllProfiles();
                    updateMode = false;
                    handleFieldEnableMode();
                    for (int i = 0; i < cbxProfiles.Items.Count; i++)
                    {
                        if (((Profile)cbxProfiles.Items[i]).ProfileId == profileId)
                        {
                            cbxProfiles.SelectedIndex = i;
                            cbxProfiles_SelectionChangeCommitted((ComboBox)cbxProfiles, e);
                            break;
                        }
                    }
                }
                else
                {
                    modUtil.throwError("Existing Profile couldn't be updated. Please try again!");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            insertMode = false;
            updateMode = false;

            fillOptionsGroupBox(null);
            handleFieldEnableMode();
            cbxProfiles_SelectionChangeCommitted(cbxProfiles.SelectedItem, e);
        }
    }
}
