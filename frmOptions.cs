using DiscordRichPresence.constructors;
using DiscordRichPresence.modules;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DiscordRichPresence
{
    public partial class frmOptions : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public frmOptions()
        {
            InitializeComponent();
            InitializeHelpProvider();
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            logger.Info("Initialize Form frmOptions");
            
            AppConf appConf = modUtil.GetAppConf();
            nudPort.Value = appConf.Port;
            nudDiscordClientId.Value = appConf.DiscordClientId;
            chkAutoStart.Checked = appConf.AutoStart;
            chkAutoStartWebservice.Checked = appConf.AutoStartWebservice;

            tbxClientIdImgur.Text = appConf.Imgur.ClientId;
            tbxClientSecretImgur.Text = appConf.Imgur.ClientSecret;
            tbxRefreshTokenImgur.Text = appConf.Imgur.RefreshToken;

            logger.Trace("Configuration obtained from file: {0}", appConf.ToString);
            logger.Info("Configuration loaded.");
        }

        private void InitializeHelpProvider()
        {
            hlpProvider.SetShowHelp(nudPort, true);
            hlpProvider.SetShowHelp(nudDiscordClientId, true);
            hlpProvider.SetShowHelp(chkAutoStart, true);
            hlpProvider.SetShowHelp(chkAutoStartWebservice, true);
            hlpProvider.SetShowHelp(tbxClientIdImgur, true);
            hlpProvider.SetShowHelp(tbxClientSecretImgur, true);
            hlpProvider.SetShowHelp(tbxRefreshTokenImgur, true);
            hlpProvider.SetShowHelp(btnOK, true);

            hlpProvider.SetHelpString(nudPort, "Port for the internal webservice which receives events from the browser extension. If the port stays 0, a random available port will be used.");
            hlpProvider.SetHelpString(nudDiscordClientId, "Unique number obtained from the Discord developer site after creating an application. The client id is required to use the Discord API to display activities on Discord.");
            hlpProvider.SetHelpString(chkAutoStart, "Automatically start this application on windows start");
            hlpProvider.SetHelpString(chkAutoStartWebservice, "Automatically run the webservice in the background when the application has started.");
            hlpProvider.SetHelpString(tbxClientIdImgur, "Client ID required to upload images on Imgur and to create galleries. Obtained after creating an application on the Imgur website.");
            hlpProvider.SetHelpString(tbxClientSecretImgur, "Client ID required to upload images on Imgur and to create galleries. Obtained after creating an application on the Imgur website.");
            hlpProvider.SetHelpString(tbxRefreshTokenImgur, "The Refresh Token is required to create an Access Token after its expiration and with it perform API operations with Imgur.");
            hlpProvider.SetHelpString(btnOK, "Save configuration and close the window.");
        }

        private void HandleKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(sender, e);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            AppConf appConf = modUtil.GetAppConf();
            appConf.Port = (int)nudPort.Value;
            appConf.DiscordClientId = (long)nudDiscordClientId.Value;
            appConf.AutoStart = chkAutoStart.Checked;
            appConf.AutoStartWebservice = chkAutoStartWebservice.Checked;

            appConf.Imgur.ClientId = tbxClientIdImgur.Text;
            appConf.Imgur.ClientSecret = tbxClientSecretImgur.Text;
            appConf.Imgur.RefreshToken = tbxRefreshTokenImgur.Text;

            try
            {
                appConf.Save();
                modUtil.SetAppConf(appConf);
                logger.Trace("New configuration values: {0}", appConf.ToString());
                logger.Info("Configuration saved");
                this.Close();
            } catch(Exception ex)
            {
                logger.Fatal(ex, "Error on saving the configuration. Application shutdown!");
                Application.Exit();
            }
        }

        private void nudPort_KeyDown(object sender, KeyEventArgs e)
        {
            HandleKeyPressed(sender, e);
        }

        private void nudDiscordClientId_KeyDown(object sender, KeyEventArgs e)
        {
            HandleKeyPressed(sender, e);
        }

        private void chkAutoStart_KeyDown(object sender, KeyEventArgs e)
        {
            HandleKeyPressed(sender, e);
        }

        private void chkAutoStartWebservice_KeyDown(object sender, KeyEventArgs e)
        {
            HandleKeyPressed(sender, e);
        }

        private void tbxClientIdImgur_KeyDown(object sender, KeyEventArgs e)
        {
            HandleKeyPressed(sender, e);
        }

        private void tbxClientSecretImgur_KeyDown(object sender, KeyEventArgs e)
        {
            HandleKeyPressed(sender, e);
        }

        private void tbxRefreshTokenImgur_KeyDown(object sender, KeyEventArgs e)
        {
            HandleKeyPressed(sender, e);
        }
    }
}
