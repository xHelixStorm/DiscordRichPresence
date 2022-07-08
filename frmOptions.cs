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

namespace DiscordRichPresence
{
    public partial class frmOptions : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private static readonly string FILENAME = "./conf.cfg";
        private static Encryption? encryption;
        public frmOptions()
        {
            InitializeComponent();

            hlpProvider.SetShowHelp(nudPort, true);
            hlpProvider.SetHelpString(nudPort, "Port for the internal webservice which receives events from the browser extension.");

            if(encryption == null)
            {
                encryption = modSQL.GetEncryption();
                if (encryption == null)
                {
                    var aes = Aes.Create();
                    if (aes != null)
                    {
                        encryption = new Encryption(aes.Key, aes.IV);
                        modSQL.InsertEncryption(encryption);
                    }
                    else
                    {
                        logger.Fatal("Encryption keys couldn't be generated. Application shutdown!");
                        throw new Exception("Encryption keys couldn't be generated. Application shutdown!");
                    }
                }
            }
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            logger.Info("Initialize Form frmOptions");
            try
            {
                if (!File.Exists(FILENAME))
                {
                    nudPort.Value = 0;
                }
                else
                {
                    string fileContent = modUtil.Decrypt(File.ReadAllBytes(FILENAME), encryption.Key, encryption.IV);
                    string[] options = fileContent.Split(";");

                    nudPort.Value = Convert.ToInt32(options[0]);
                }
            } catch(Exception ex)
            {
                logger.Fatal(ex, "Error on fetching the configuration. Application shutdown!");
                Application.Exit();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(nudPort.Value+";");
            try
            {
                File.WriteAllBytes(FILENAME, modUtil.Encrypt(sb.ToString(), encryption.Key, encryption.IV));
                this.Close();
            } catch(Exception ex)
            {
                logger.Fatal(ex, "Error on saving the configuration. Application shutdown!");
                Application.Exit();
            }
        }

        private void nudPort_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnOK_Click(sender, e);
            }
        }
    }
}
