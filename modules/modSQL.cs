using DiscordRichPresence.constructors;
using Microsoft.Data.Sqlite;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRichPresence.modules
{
    public class modSQL
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private static SqliteConnection? createConnection()
        {
            SqliteConnection con = new SqliteConnection("Data Source=DiscordRichPresence.db;Mode=ReadWrite;");
            try
            {
                con.Open();
                return con;
            }
            catch (Exception e)
            {
                logger.Error(e, "Database connection couldn't be established");
                con.Close();
                return null;
            }
        }

        public static bool testDBConnection()
        {
            logger.Debug("SQL method called");
            SqliteConnection con = createConnection();
            if (con != null) { return true; }
            return false;
        }

        public static List<Profile>? fetchAllProfiles()
        {
            logger.Debug("SQL method called");
            var con = createConnection();
            if (con == null) return null;

            List<Profile> profiles = new List<Profile>();
            var command = con.CreateCommand();
            command.CommandText = "SELECT * FROM profiles ORDER BY name";
            logger.Trace("Execute query: {0}", command.CommandText);

            SqliteDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read()) 
                {
                    Profile profile = new Profile(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4),
                        reader.GetString(5),
                        reader.GetString(6),
                        reader.GetString(7),
                        reader.GetString(8),
                        reader.GetString(9)
                    );
                    logger.Trace("Obtained DB values: {0}", profile.ToString2);
                    profiles.Add(profile);
                }
                reader.Close();
            } catch(SqliteException e)
            {
                logger.Error(e, "DB action couldn't be executed");
                return null;
            }
            return profiles;
        }
    }
}
