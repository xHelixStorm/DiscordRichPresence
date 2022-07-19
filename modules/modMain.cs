using DiscordRichPresence.constructors;
using DiscordRichPresence.enums;
using NLog;

namespace DiscordRichPresence.modules
{
    internal static class modMain
    {
        /// <summary>
        ///  The main entry point for the application.
        ///  Create Rich presences for Discord.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //Create all required directories
            CreateDirectories();
            //initialize Logger configuration
            InitializeNLog();
            Logger logger = LogManager.GetCurrentClassLogger();

            if (!modSQL.TestDBConnection())
            {
                logger.Fatal("Terminate application due to database error");
                Application.Exit();
                return;
            }

            //Load configuration of this application
            if(LoadAppConfig(logger))
            {
                logger.Info("Initialize application start up");
                ApplicationConfiguration.Initialize();
                bool minimize = args.Where(arg => arg.StartsWith("/startup")).Any();
                Application.Run(new frmMain(minimize));
            }
            else
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Create directories on start up
        /// </summary>
        private static void CreateDirectories()
        {
            foreach (string path in modUtil.GetFolders().GetPaths())
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
        }

        /// <summary>
        /// Method for the initialization of NLog
        /// </summary>
        private static void InitializeNLog()
        {
            var config = new NLog.Config.LoggingConfiguration();
            const string layout = "${pad:padding=5:inner=${level:uppercase=true}} ${longdate} ${logger} Thread ${threadid} - ${message} ${exception:format=toString,Data}";
            var logFile = new NLog.Targets.FileTarget("logfile") { FileName = modUtil.GetFolders().GetPath(Folder.LOG)+"DiscordRichPresence.log" };
            var logConsole = new NLog.Targets.ConsoleTarget("logconsole");

            logFile.Layout = layout;
            logConsole.Layout = layout;

            logFile.ArchiveOldFileOnStartup = true;
            logFile.MaxArchiveDays = 30;
            logFile.MaxArchiveFiles = 10;
            logFile.ArchiveAboveSize = 10240000;

            #if DEBUG
                config.AddRule(LogLevel.Trace, LogLevel.Fatal, logConsole);
                config.AddRule(LogLevel.Trace, LogLevel.Fatal, logFile);
            #else
                config.AddRule(LogLevel.Info, LogLevel.Fatal, logConsole);
                config.AddRule(LogLevel.Info, LogLevel.Fatal, logFile);
            #endif
            NLog.LogManager.Configuration = config;
        }

        private static bool LoadAppConfig(Logger logger)
        {
            try
            {
                modUtil.SetAppConf(new AppConf().Load());
            } catch(Exception e)
            {
                logger.Fatal(e, "Configuration couldn't be loaded. Application shutdown!");
                return false;
            }
            return true;
        }
    }
}