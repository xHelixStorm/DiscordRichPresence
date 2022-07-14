using DiscordRichPresence.constructors;
using DiscordRichPresence.enums;
using DiscordRichPresence.modules;
using Microsoft.Win32;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        private bool autoMinimize = false;

        public frmMain(bool minimize)
        {
            InitializeComponent();
            autoMinimize = minimize;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            logger.Info("Initialize Form frmMain");
            //initialize combo box for the activity type selections
            InitializeActivityTypes();
            //Initialize help provider
            InitializeHelpProvider();
            //Fetch all existing Profiles
            fetchAllProfiles();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            //Minimize application to system tray if the startup parameter was used
            if (autoMinimize)
            {
                btnMinimize_Click(sender, e);
            }
            else
            {
                this.ShowInTaskbar = true;
                this.WindowState = FormWindowState.Normal;
            }
            AppConf appConf = modUtil.GetAppConf();
            if (appConf.AutoStartWebservice)
            {
                btnStart_Click(sender, e);
            }
        }

        private void fetchAllProfiles()
        {
            cbxProfiles.Items.Clear();
            var profiles = modSQL.FetchAllProfiles();
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
            FillOptionsGroupBox(null);
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            cbxProfiles.Focus();
        }

        private void InitializeActivityTypes()
        {
            foreach(ActivityType activityType in Enum.GetValues(typeof(ActivityType))){
                IActivityType activity = new IActivityType(activityType);
                cbxTypes.Items.Add(activity);
            }
        }

        private void InitializeHelpProvider()
        {
            hlpProvider.SetShowHelp(cbxProfiles, true);
            hlpProvider.SetShowHelp(btnAdd, true);
            hlpProvider.SetShowHelp(btnUpdate, true);
            hlpProvider.SetShowHelp(btnDelete, true);
            hlpProvider.SetShowHelp(btnMinimize, true);
            hlpProvider.SetShowHelp(btnOptions, true);
            hlpProvider.SetShowHelp(btnStart, true);
            hlpProvider.SetShowHelp(btnEnd, true);
            hlpProvider.SetShowHelp(tbxProfileName, true);
            hlpProvider.SetShowHelp(tbxSourceUrl, true);
            hlpProvider.SetShowHelp(tbxTargetUrl, true);
            hlpProvider.SetShowHelp(cbxTypes, true);
            hlpProvider.SetShowHelp(tbxName, true);
            hlpProvider.SetShowHelp(tbxState, true);
            hlpProvider.SetShowHelp(chkTargetState, true);
            hlpProvider.SetShowHelp(tbxDetails, true);
            hlpProvider.SetShowHelp(chkTargetDetails, true);
            hlpProvider.SetShowHelp(tbxLargeImage, true);
            hlpProvider.SetShowHelp(chkTargetLargeImage, true);
            hlpProvider.SetShowHelp(tbxLargeText, true);
            hlpProvider.SetShowHelp(chkTargetLargeText, true);
            hlpProvider.SetShowHelp(tbxSmallImage, true);
            hlpProvider.SetShowHelp(chkTargetSmallImage, true);
            hlpProvider.SetShowHelp(tbxSmallText, true);
            hlpProvider.SetShowHelp(chkTargetSmallText, true);
            hlpProvider.SetShowHelp(chkAudible, true);
            hlpProvider.SetShowHelp(btnSave, true);
            hlpProvider.SetShowHelp(btnCancel, true);
            hlpProvider.SetShowHelp(tbxPort, true);
            hlpProvider.SetShowHelp(btnTest, true);


            hlpProvider.SetHelpString(cbxProfiles, "Select a registered profile to view the details or to enable additional buttons to either update or remove the selected profile.");
            hlpProvider.SetHelpString(btnAdd, "Activate all components inside the Options group box for the creation of a new profile.");
            hlpProvider.SetHelpString(btnUpdate, "Activate all components inside the Options group box to update a selected profile.");
            hlpProvider.SetHelpString(btnDelete, "Delete a selected profile. Before the deletion, a message prompt appears to confirm the choice.");
            hlpProvider.SetHelpString(btnMinimize, "Minimize application to the system tray.");
            hlpProvider.SetHelpString(btnOptions, "Open the options page.");
            hlpProvider.SetHelpString(btnStart, "Initialize the rest api webserver to receive events from the browser extension;");
            hlpProvider.SetHelpString(btnEnd, "Terminate the rest api webserver and stop from receiving events.");
            hlpProvider.SetHelpString(tbxProfileName, "Required field which has to contain the name of the profile that has to be created or updated.");
            hlpProvider.SetHelpString(tbxSourceUrl, "Required field which has to contain the url of the website where events have to be collected.\nThe format of the url has to contain the full domain name, while sub domains can be written directly or combined with a regex requests.\n\nExamples of valid urls:\n\n- https://google.com\n- https://discord.com/developers/docs\n- https://discord.com/{::regex:^.*$::}");
            hlpProvider.SetHelpString(tbxTargetUrl, "Optional field which has to contain the url of the website where the source url is redirected to.\nThe format of the url has to contain the full domain name, while sub domains can be written directly or combined with a regex requests.\n\nExamples of valid urls:\n\n- https://google.com\n- https://discord.com/developers/docs\n- https://discord.com/{::regex:^.*$::}");
            hlpProvider.SetHelpString(cbxTypes, "Combo box for the type of activity. The activity types are to be combined with the Name field.\n\n- Playing: 'Playing {name}'\n- Streaming: 'Streaming {name}'\n- Listening: 'Listening to {name}'\n- Watching: 'Watching {name}'\n- Custom: '{name}'\n- Competing: 'Competing in {name}'\n\nNote: Streaming is only supported with Twitch and YouTube.");
            hlpProvider.SetHelpString(tbxName, "Required field which works together with the activity types combo box for the status display on Discord. For example 'Playing {name}'.");
            hlpProvider.SetHelpString(tbxState, "Optional field that will fill the state spot for the activity display on Discord. Content of this field can be combined with various expressions.\n\n- Regex: '{::regex:[\\d\\w]*::}'\n- Url: '{::url::}' or '{::url:{::regex:[\\d]*$::}::}'\n- HTML Location: '{::location:<div id=\"xyz\">::}' or '{::location:<img class=\"xyz\">:src::}'\n- HTML Click Location: '{::click:<a>;up;<div>;down;<img>:src::}'\n\nNote: for 'click' and 'location' the regex can be used with the parentheses to filter for attributes with specific names.");
            hlpProvider.SetHelpString(chkTargetState, "When selected, values will be taken from the target website. Else, it will be taken from the source website.");
            hlpProvider.SetHelpString(tbxDetails, "Optional field that will fill the details spot for the activity display on Discord. Content of this field can be combined with various expressions.\n\n- Regex: '{::regex:[\\d\\w]*::}'\n- Url: '{::url::}' or '{::url:{::regex:[\\d]*$::}::}'\n- HTML Location: '{::location:<div id=\"xyz\">::}' or '{::location:<img class=\"xyz\">:src::}'\n- HTML Click Location: '{::click:<a>;up;<div>;down;<img>:src::}'\n\nNote: for 'click' and 'location' the regex can be used with the parentheses to filter for attributes with specific names.");
            hlpProvider.SetHelpString(chkTargetDetails, "When selected, values will be taken from the target website. Else, it will be taken from the source website.");
            hlpProvider.SetHelpString(tbxLargeImage, "Optional field that will fill the large image spot for the activity display on Discord. Content of this field can be combined with various expressions.\n\n- Regex: '{::regex:[\\d\\w]*::}'\n- HTML Location: '{::location:<img class=\"xyz\">:src::}'\n- HTML Click Location: '{::click:<a>;up;<div>;down;<img>:src::}'\n- Favicon: '{::favicon::}'\n\nNote: for 'click' and 'location' the regex can be used with the parentheses to filter for attributes with specific names.");
            hlpProvider.SetHelpString(chkTargetLargeImage, "When selected, values will be taken from the target website. Else, it will be taken from the source website.");
            hlpProvider.SetHelpString(tbxLargeText, "Optional field that will fill the large text spot for the activity display on Discord. Content of this field can be combined with various expressions.\n\n- Regex: '{::regex:[\\d\\w]*::}'\n- Url: '{::url::}' or '{::url:{::regex:[\\d]*$::}::}'\n- HTML Location: '{::location:<div id=\"xyz\"::}' or '{::location:<img class=\"xyz\">:src::}'\n- HTML Click Location: '{::click:<a>;up;<div>;down;<img>:src::}'\n\nNote: for 'click' and 'location' the regex can be used with the parentheses to filter for attributes with specific names.");
            hlpProvider.SetHelpString(chkTargetLargeText, "When selected, values will be taken from the target website. Else, it will be taken from the source website.");
            hlpProvider.SetHelpString(tbxSmallImage, "Optional field that will fill the small image spot for the activity display on Discord. Content of this field can be combined with various expressions.\n\n- Regex: '{::regex:[\\d\\w]*::}'\n- HTML Location: '{::location:<img class=\"xyz\">:src::}'\n- HTML Click Location: '{::click:<a>;up;<div>;down;<img>:src::}'\n- Favicon: '{::favicon::}'\n\nNote: for 'click' and 'location' the regex can be used with the parentheses to filter for attributes with specific names.");
            hlpProvider.SetHelpString(chkTargetSmallImage, "When selected, values will be taken from the target website. Else, it will be taken from the source website.");
            hlpProvider.SetHelpString(tbxSmallText, "Optional field that will fill the small text spot for the activity display on Discord. Content of this field can be combined with various expressions.\n\n- Regex: '{::regex:[\\d\\w]*::}'\n- Url: '{::url::}' or '{::url:{::regex:[\\d]*$::}::}'\n- HTML Location: '{::location:<div id=\"xyz\">::}' or '{::location:<img class=\"xyz\">:src::}'\n- HTML Click Location: '{::click:<a>;up;<div>;down;<img>:src::}'\n\nNote: for 'click' and 'location' the regex can be used with the parentheses to filter for attributes with specific names.");
            hlpProvider.SetHelpString(chkTargetSmallText, "When selected, values will be taken from the target website. Else, it will be taken from the source website.");
            hlpProvider.SetHelpString(chkAudible, "When selected, events are collected when the browser tab has an audio but works only with values to be collected from the source website. Else, values are collected when the website is visited.");
            hlpProvider.SetHelpString(btnSave, "Save all input by either creating a new profile or by updating an existing one.");
            hlpProvider.SetHelpString(btnCancel, "Undo all not saved changes");
            hlpProvider.SetHelpString(tbxPort, "Display the port that is in use from the webservice.");
            hlpProvider.SetHelpString(btnTest, "Experiment with the displayed fields to display the activity on Discord.");
        }

        private void cbxProfiles_SelectionChangeCommitted(object sender, EventArgs e)
        {
            logger.Debug("SelectionChangeCommitted event thrown for field cbxProfiles");
            ComboBox item = sender as ComboBox;
            if(item != null)
            {
                Profile profile = item.SelectedItem as Profile;
                FillOptionsGroupBox(profile);
                if(profile != null)
                {
                    btnDelete.Enabled = true;
                    btnUpdate.Enabled = true;
                }
                else
                {
                    btnDelete.Enabled = false;
                    btnUpdate.Enabled = false;
                }
            }
            else
            {
                FillOptionsGroupBox(null);
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
            }
        }

        private void FillOptionsGroupBox(Profile? profile)
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
                const string source = "source;";
                const string target = "target;";

                int sourceLength = source.Length;
                int targetLength = target.Length;

                profileName = profile.ProfileName;
                sourceDomain = profile.SourceUrl;
                targetDomain = profile.TargetUrl;
                for (int i = 0; i < cbxTypes.Items.Count; i++)
                {
                    if (((IActivityType)cbxTypes.Items[i]).Type == profile.Type)
                    {
                        typeIndex = i;
                        break;
                    }
                }
                name = profile.Name;
                if(profile.State.StartsWith(target))
                {
                    state = profile.State.Substring(targetLength);
                    targetState = true;
                }
                else
                {
                    state = profile.State.Substring(sourceLength);
                }
                if(profile.Details.StartsWith(target))
                {
                    details = profile.Details.Substring(targetLength);
                    targetDetails = true;
                }
                else
                {
                    details = profile.Details.Substring(sourceLength);
                }
                if (profile.LargeImage.StartsWith(target))
                {
                    largeImage = profile.LargeImage.Substring(targetLength);
                    targetLargeImage = true;
                }
                else
                {
                    largeImage = profile.LargeImage.Substring(sourceLength);
                }
                if(profile.LargeText.StartsWith(target))
                {
                    largeText = profile.LargeText.Substring(targetLength);
                    targetLargeText = true;
                }
                else
                {
                    largeText = profile.LargeText.Substring(sourceLength);
                }
                if (profile.SmallImage.StartsWith(target))
                {
                    smallImage = profile.SmallImage.Substring(targetLength);
                    targetSmallImage = true;
                }
                else
                {
                    smallImage = profile.SmallImage.Substring(sourceLength);
                }
                if (profile.SmallText.StartsWith(target))
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
            tbxSourceUrl.Text = sourceDomain;
            tbxTargetUrl.Text = targetDomain;
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

        private void HandleFieldEnableMode()
        {
            bool enabled = (insertMode || updateMode);

            cbxProfiles.Enabled = !enabled && cbxProfiles.Items.Count > 0;
            btnAdd.Enabled = !enabled;
            btnUpdate.Enabled = !enabled;
            btnDelete.Enabled = !enabled;
            btnMinimize.Enabled = !enabled;
            btnOptions.Enabled = !enabled;

            tbxProfileName.Enabled = enabled;
            tbxSourceUrl.Enabled = enabled;
            tbxTargetUrl.Enabled = enabled;
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
            FillOptionsGroupBox(null);
            HandleFieldEnableMode();
            tbxProfileName.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateMode = true;
            HandleFieldEnableMode();
            tbxProfileName.Focus();
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
                    dbResult = modSQL.DeleteProfile(profile.ProfileId);
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
            const string source = "source;";
            const string target = "target;";

            Profile profile = new Profile(
                (cbxProfiles.SelectedItem != null ? ((Profile)cbxProfiles.SelectedItem).ProfileId: 0),
                tbxProfileName.Text,
                tbxSourceUrl.Text,
                tbxTargetUrl.Text,
                (cbxTypes.SelectedItem != null ? ((IActivityType)cbxTypes.SelectedItem).Type : (int)ActivityType.Playing),
                tbxName.Text,
                (chkTargetState.Checked ? target : source)+tbxState.Text,
                (chkTargetDetails.Checked ? target : source) + tbxDetails.Text,
                (chkTargetLargeImage.Checked ? target : source) + tbxLargeImage.Text,
                (chkTargetLargeText.Checked ? target : source) + tbxLargeText.Text,
                (chkTargetSmallImage.Checked ? target : source) + tbxSmallImage.Text,
                (chkTargetSmallText.Checked ? target : source) + tbxSmallText.Text,
                chkAudible.Checked
            );

            try
            {
                profile.Validate();
            } catch(ValidationException ex)
            {
                logger.Warn(ex, "Fields have failed the validation");
                modUtil.throwError(ex.Message);
                return;
            }

            if (insertMode)
            {
                int result = modSQL.InsertProfile(profile);
                if(result > 0)
                {
                    fetchAllProfiles();
                    insertMode = false;
                    HandleFieldEnableMode();
                    logger.Info("New Profile has been created");
                }
                else
                {
                    modUtil.throwError("New Profile couldn't be saved. Please try again!");
                }
            }
            else if (updateMode)
            {
                int result = modSQL.UpdateProfile(profile);
                if(result > 0)
                {
                    int profileId = profile.ProfileId;
                    fetchAllProfiles();
                    updateMode = false;
                    HandleFieldEnableMode();
                    for (int i = 0; i < cbxProfiles.Items.Count; i++)
                    {
                        if (((Profile)cbxProfiles.Items[i]).ProfileId == profileId)
                        {
                            cbxProfiles.SelectedIndex = i;
                            cbxProfiles_SelectionChangeCommitted((ComboBox)cbxProfiles, e);
                            break;
                        }
                    }
                    logger.Info("Profile with the id {0} has been updated", profileId);
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

            FillOptionsGroupBox(null);
            HandleFieldEnableMode();
            cbxProfiles_SelectionChangeCommitted(cbxProfiles, e);
        }

        private void ntfIcon_DoubleClick(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {

            new frmOptions().ShowDialog();

            AppConf conf = modUtil.GetAppConf();

            //Initialize application auto start
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            if (regKey == null)
            {
                logger.Warn("Auto start path in the registry couldn't be opened");
                return;
            }
            if (conf.AutoStart)
            {
                regKey.SetValue(Application.ProductName, "\"" + Application.ExecutablePath + "\" /startup");
            }
            else
            {
                regKey.DeleteValue(Application.ProductName, false);
            }
            regKey.Close();
        }

        private void tsmOpen_Click(object sender, EventArgs e)
        {
            ntfIcon_DoubleClick(sender, e);
        }

        private void tsmClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnTest.Enabled = false;
            btnStart.Enabled = false;
            tsmRunWebservice.Enabled = false;
            btnEnd.Enabled = true;
            tsmEndWebservice.Enabled = true;
            int port = modWebservice.RunWebservice();
            tbxPort.Text = port.ToString();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            btnTest.Enabled = true;
            btnEnd.Enabled = false;
            tsmEndWebservice.Enabled = false;
            btnStart.Enabled = true;
            tsmRunWebservice.Enabled = true;
            modWebservice.StopWebservice();
            tbxPort.Text = "";
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            new frmTest().ShowDialog();
        }
    }
}
