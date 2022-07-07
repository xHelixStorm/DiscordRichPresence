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
            command.CommandText = @"INSERT INTO profiles (profile_name, source_domain, target_domain, type, name, state, details, large_image, large_text, small_image, small_text, audible)
                VALUES($profile_name, $source_domain, $target_domain, $type, $name, $state, $details, $large_image, $large_text, $small_image, $small_text, $audible)";
            command.Parameters.AddWithValue("$profile_name", profile.ProfileName);
            command.Parameters.AddWithValue("$source_domain", profile.SourceDomain);
            command.Parameters.AddWithValue("$target_domain", profile.TargetDomain);
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
            command.CommandText = @"
                UPDATE profiles SET 
                    profile_name = $profile_name,
                    source_domain = $source_domain,
                    target_domain = $target_domain,
                    type = $type,
                    name = $name,
                    state = $state,
                    details = $details,
                    large_image = $large_image,
                    large_text = $large_text,
                    small_image = $small_image, 
                    small_text = $small_text,
                    audible = $audible
                WHERE profile_id = $profile_id";
            command.Parameters.AddWithValue("$profile_id", profile.ProfileId);
            command.Parameters.AddWithValue("$profile_name", profile.ProfileName);
            command.Parameters.AddWithValue("$source_domain", profile.SourceDomain);
            command.Parameters.AddWithValue("$target_domain", profile.TargetDomain);
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
