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
        }

        private void InitializeHelpProvider()
        {
            hlpProvider.SetShowHelp(nudPort, true);
            hlpProvider.SetShowHelp(nudDiscordClientId, true);
            hlpProvider.SetShowHelp(chkAutoStart, true);
            hlpProvider.SetShowHelp(chkAutoStartWebservice, true);
            hlpProvider.SetShowHelp(btnOK, true);

            hlpProvider.SetHelpString(nudPort, "Port for the internal webservice which receives events from the browser extension.");
            hlpProvider.SetHelpString(nudDiscordClientId, "Unique number obtained from the Discord developer site after creating an application. The client id is required to use the Discord API to display activities on Discord.");
            hlpProvider.SetHelpString(chkAutoStart, "Automatically start this application on windows start");
            hlpProvider.SetHelpString(chkAutoStartWebservice, "Automatically run the webservice in the background when the application has started.");
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

            try
            {
                appConf.Save();
                modUtil.SetAppConf(appConf);
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
    }
}
