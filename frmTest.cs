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
    public partial class frmTest : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private static Discord.Discord? discord = null;
        private bool sdkTestTerminate = false;

        public frmTest()
        {
            InitializeComponent();
        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            logger.Debug("Initialize form frmTest");
        }

        private void frmTest_Shown(object sender, EventArgs e)
        {
            AppConf appConf = modUtil.GetAppConf();
            if(appConf.DiscordClientId == 0)
            {
                modUtil.throwError("Please provide a Discord OAuth2 client id before testing the rich presence!");
                this.Close();
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            sdkTestTerminate = false;
            if(discord == null)
            {
                discord = new Discord.Discord(modUtil.GetAppConf().DiscordClientId, (UInt64)Discord.CreateFlags.Default);

                #if DEBUG
                discord.SetLogHook(Discord.LogLevel.Debug, (level, message) =>
                {
                    switch (level)
                    {
                        case Discord.LogLevel.Debug: { logger.Debug(message); break; }
                        case Discord.LogLevel.Info: { logger.Info(message); break; }
                        case Discord.LogLevel.Warn: { logger.Warn(message); break; }
                        case Discord.LogLevel.Error: { logger.Error(message); break; }
                    }
                });
                #else
                discord.SetLogHook(Discord.LogLevel.Info, (level, message) =>
                {
                    switch (level)
                    {
                        case Discord.LogLevel.Debug: { logger.Debug(message); break; }
                        case Discord.LogLevel.Info: { logger.Info(message); break; }
                        case Discord.LogLevel.Warn: { logger.Warn(message); break; }
                        case Discord.LogLevel.Error: { logger.Error(message); break; }
                    }
                });
                #endif

                UpdateActivity();

                Task.Run(() =>
                {
                    var lobbyManager = discord.GetLobbyManager();
                    try
                    {
                        while (!sdkTestTerminate)
                        {
                            discord.RunCallbacks();
                            lobbyManager.FlushNetwork();
                            Thread.Sleep(1000 / 60);
                        }
                    }
                    finally
                    {
                        discord.Dispose();
                        discord = null;
                    }
                });
            }
            else
            {
                UpdateActivity();
            }
            btnEnd.Enabled = true;
        }

        private void UpdateActivity()
        {
            var activityManager = discord?.GetActivityManager();
            var activity = new Discord.Activity
            {
                State = tbxState.Text,
                Details = tbxDetails.Text,
                Timestamps =
                {
                    Start = DateTimeOffset.Now.ToUnixTimeSeconds(),
                    End = chkAudible.Checked ? DateTimeOffset.Now.AddMinutes(10).ToUnixTimeSeconds() : 0
                },
                Assets =
                {
                    LargeImage = tbxLargeImage.Text,
                    LargeText = tbxLargeText.Text,
                    SmallImage = tbxSmallImage.Text,
                    SmallText = tbxSmallText.Text,
                },
                Instance = true
            };

            activityManager?.UpdateActivity(activity, result =>
            {
                logger.Info("Update Activity {0}", result);
            });
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            if(discord != null)
            {
                discord.GetActivityManager().ClearActivity((result) =>
                {
                    sdkTestTerminate = true;
                });
            }
            btnEnd.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            btnEnd_Click(sender, e);
            this.Close();
        }
    }
}
