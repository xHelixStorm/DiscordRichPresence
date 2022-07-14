using Newtonsoft.Json.Linq;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRichPresence.modules
{
    public class modDiscord
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private static Discord.Discord? discord = null;
        private static bool sdkTestTerminate = false;
        private static long unixTimestamp = 0;

        public static bool isActive()
        {
            return discord != null;
        }

        public static void InitializeActivity(JObject profile)
        {
            sdkTestTerminate = false;
            if (discord == null)
            {
                discord = new Discord.Discord(modUtil.GetAppConf().DiscordClientId, (UInt64)Discord.CreateFlags.NoRequireDiscord);

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

                UpdateActivity(profile, true);

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
                UpdateActivity(profile, false);
            }
        }

        private static void UpdateActivity(JObject? profile, bool isNew)
        {
            if (isNew)
            {
                unixTimestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
            }

            var activityManager = discord?.GetActivityManager();
            #pragma warning disable CS8604 // Possible null reference argument.
            #pragma warning disable CS8602 // Dereference of a possibly null reference.
            #pragma warning disable CS8601 // Possible null reference assignment.
            var activity = new Discord.Activity
            {
                Type = (Discord.ActivityType)Int32.Parse((string)profile.GetValue("Type")),
                Name = (string)profile.GetValue("Name"),
                State = (string)profile.GetValue("State"),
                Details = (string)profile.GetValue("Details"),
                Timestamps =
                {
                    Start = unixTimestamp
                },
                Assets =
                {
                    LargeImage = (string)profile.GetValue("LargeImage"),
                    LargeText = (string)profile.GetValue("LargeText"),
                    SmallImage = (string)profile.GetValue("SmallImage"),
                    SmallText = (string)profile.GetValue("SmallText"),
                },
                Instance = true
            };
            #pragma warning restore CS8601 // Possible null reference assignment.
            #pragma warning restore CS8602 // Dereference of a possibly null reference.
            #pragma warning restore CS8604 // Possible null reference argument.

            activityManager?.UpdateActivity(activity, result =>
            {
                logger.Info("Update Activity {0}", result);
            });
        }

        public static void StopActivity()
        {
            if (discord != null)
            {
                discord.GetActivityManager().ClearActivity((result) =>
                {
                    sdkTestTerminate = true;
                });
            }
        }
    }
}
