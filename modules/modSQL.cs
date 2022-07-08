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
        private static bool fileCheck = false;

        const string SQLCONNECTION = "Data Source=DiscordRichPresence.db;";

        private static SqliteConnection? createConnection()
        {
            bool createMode = false;
            if(!fileCheck)
            {
                if (!File.Exists("./DiscordRichPresence.db"))
                {
                    createMode = true;
                }
                fileCheck = true;
            }
            SqliteConnection con = new SqliteConnection(SQLCONNECTION);
            try
            {
                con.Open();
                if (createMode)
                {
                    createTables(con);
                }
                return con;
            }
            catch (Exception e)
            {
                logger.Error(e, "Database connection couldn't be established");
                con.Close();
                return null;
            }
        }

        public static void createTables(SqliteConnection con)
        {
            logger.Debug("SQL method createTables called");
            if (con == null) return;

            var command = con.CreateCommand();
            command.CommandText = "CREATE TABLE `profiles` (`profile_id` INTEGER not null primary key autoincrement, `profile_name` VARCHAR(255) not null, `source_url` VARCHAR(255) not null, `target_url` VARCHAR(255) null, `type` INTEGER null DEFAULT '0', `name` VARCHAR(255) null, `state` VARCHAR(255) null, `details` VARCHAR(255) null, `large_image` VARCHAR(255) null, `large_text` VARCHAR(255) null, `small_image` VARCHAR(255) null, `small_text` VARCHAR(255) null, `audible` BOOLEAN null, `created_at` datetime not null default CURRENT_TIMESTAMP)";
            logger.Trace("Execute query: {0}", command.CommandText);

            try
            {
                command.ExecuteNonQuery();
            } catch(SqliteException e)
            {
                logger.Error(e, "DB action coldn't be executed");
            }
        }

        public static bool testDBConnection()
        {
            logger.Debug("SQL method testDBConnection called");
            SqliteConnection con = createConnection();
            if (con != null) { return true; }
            return false;
        }

        public static List<Profile>? fetchAllProfiles()
        {
            logger.Debug("SQL method fetchAllProfiles called");
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
                        reader.GetInt32(4),
                        reader.GetString(5),
                        reader.GetString(6),
                        reader.GetString(7),
                        reader.GetString(8),
                        reader.GetString(9),
                        reader.GetString(10),
                        reader.GetString(11),
                        reader.GetBoolean(12)
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

        public static int deleteProfile(int profileId)
        {
            logger.Debug("SQL method deleteProfile called");
            var con = createConnection();
            if (con == null) return -1;

            var command = con.CreateCommand();
            command.CommandText = "DELETE FROM profiles WHERE profile_id = $profile_id";
            command.Parameters.AddWithValue("$profile_id", profileId);
            logger.Trace("Execute query: {0}", command.CommandText);
            logger.Trace("Parameters passed: {0}", profileId);

            try
            {
                return command.ExecuteNonQuery();
            } catch(SqliteException e)
            {
                logger.Error(e, "DB action couldn't be executed");
                return -1;
            }
        }

        public static int insertProfile(Profile profile)
        {
            logger.Debug("SQL method insertProfile called");
            var con = createConnection();
            if (con == null) return -1;

            var command = con.CreateCommand();
            command.CommandText = @"INSERT INTO profiles (profile_name, source_url, target_url, type, name, state, details, large_image, large_text, small_image, small_text, audible) VALUES($profile_name, $source_url, $target_url, $type, $name, $state, $details, $large_image, $large_text, $small_image, $small_text, $audible)";
            command.Parameters.AddWithValue("$profile_name", profile.ProfileName);
            command.Parameters.AddWithValue("$source_url", profile.SourceUrl);
            command.Parameters.AddWithValue("$target_url", profile.TargetUrl);
            command.Parameters.AddWithValue("$type", profile.Type);
            command.Parameters.AddWithValue("$name", profile.Name);
            command.Parameters.AddWithValue("$state", profile.State);
            command.Parameters.AddWithValue("$details", profile.Details);
            command.Parameters.AddWithValue("$large_image", profile.LargeImage);
            command.Parameters.AddWithValue("$large_text", profile.LargeText);
            command.Parameters.AddWithValue("$small_image", profile.SmallImage);
            command.Parameters.AddWithValue("$small_text", profile.SmallText);
            command.Parameters.AddWithValue("$audible", profile.Audible);
            logger.Trace("Execute query: {0}", command.CommandText);
            logger.Trace("Parameters passed: {0}", profile.ToString2());
            
            try
            {
                return command.ExecuteNonQuery();
            } catch(SqliteException e)
            {
                logger.Error(e, "DB action couldn't be executed");
                return -1;
            }
        }

        public static int updateProfile(Profile profile)
        {
            logger.Debug("SQL method updateProfile called");
            var con = createConnection();
            if (con == null) return -1;

            var command = con.CreateCommand();
            command.CommandText = "UPDATE profiles SET profile_name = $profile_name, source_url = $source_url, target_url = $target_url, type = $type, name = $name, state = $state, details = $details, large_image = $large_image, large_text = $large_text, small_image = $small_image, small_text = $small_text, audible = $audible WHERE profile_id = $profile_id";
            command.Parameters.AddWithValue("$profile_id", profile.ProfileId);
            command.Parameters.AddWithValue("$profile_name", profile.ProfileName);
            command.Parameters.AddWithValue("$source_url", profile.SourceUrl);
            command.Parameters.AddWithValue("$target_url", profile.TargetUrl);
            command.Parameters.AddWithValue("$type", profile.Type);
            command.Parameters.AddWithValue("$name", profile.Name);
            command.Parameters.AddWithValue("$state", profile.State);
            command.Parameters.AddWithValue("$details", profile.Details);
            command.Parameters.AddWithValue("$large_image", profile.LargeImage);
            command.Parameters.AddWithValue("$large_text", profile.LargeText);
            command.Parameters.AddWithValue("$small_image", profile.SmallImage);
            command.Parameters.AddWithValue("$small_text", profile.SmallText);
            command.Parameters.AddWithValue("$audible", profile.Audible);
            logger.Trace("Execute query: {0}", command.CommandText);
            logger.Trace("Parameters passed: {0}", profile.ToString2());

            try
            {
                return command.ExecuteNonQuery();
            } catch(SqliteException e)
            {
                logger.Error(e, "DB action couldn't be executed");
                return -1;
            }
        }
    }
}
