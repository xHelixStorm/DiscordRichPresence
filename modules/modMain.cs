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
        static void Main()
        {
            //Create all required directories
            createDirectories();
            //initialize Logger configuration
            initializeNLog();
            Logger logger = LogManager.GetCurrentClassLogger();

            if (!modSQL.testDBConnection())
            {
                logger.Fatal("Terminate application due to database error");
                Application.Exit();
            }

            logger.Info("Initialize application start up");
            ApplicationConfiguration.Initialize();
            Application.Run(new frmMain());
        }

        /// <summary>
        /// Create directories on start up
        /// </summary>
        private static void createDirectories()
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
        private static void initializeNLog()
        {
            var config = new NLog.Config.LoggingConfiguration();
            const string layout = "${pad:padding=5:inner=level:uppercase=true} ${longdate} ${logger} Thread ${threadid} - ${message} ${exception:format=toString,Data}";
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
    }
}