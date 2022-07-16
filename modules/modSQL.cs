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

        private static readonly string SQLCONNECTION = "Data Source=" + Application.StartupPath + "DiscordRichPresence.db;";

        private static SqliteConnection? CreateConnection()
        {
            SqliteConnection con = new SqliteConnection(SQLCONNECTION);
            try
            {
                con.Open();
                if (con != null && !fileCheck)
                {
                    fileCheck = true;
                    CreateTables(con);
                }
                return con;
            }
            catch (Exception e)
            {
                logger.Error(e, "Database connection couldn't be established");
                return null;
            }
        }

        public static void CreateTables(SqliteConnection con)
        {
            logger.Debug("SQL method CreateTables called");
            if (con == null) return;

            try
            {
                var command = con.CreateCommand();
                command.CommandText = "CREATE TABLE IF NOT EXISTS `profiles` (`profile_id` INTEGER not null primary key autoincrement, `profile_name` VARCHAR(255) not null, `source_url` VARCHAR(255) not null, `target_url` VARCHAR(255) null, `type` INTEGER null DEFAULT '0', `name` VARCHAR(255) null, `state` VARCHAR(255) null, `details` VARCHAR(255) null, `large_image` VARCHAR(255) null, `large_text` VARCHAR(255) null, `small_image` VARCHAR(255) null, `small_text` VARCHAR(255) null, `key` VARCHAR(255) null, `audible` BOOLEAN null, `created_at` datetime not null default CURRENT_TIMESTAMP)";
                logger.Trace("Execute query: {0}", command.CommandText);

                command.ExecuteNonQuery();

                command = con.CreateCommand();
                command.CommandText = "CREATE TABLE IF NOT EXISTS `encryption` (`key` VARCHAR(255) not null PRIMARY KEY, `iv` VARCHAR(255) not null)";
                logger.Trace("Execute query: {0}", command.CommandText);

                command = con.CreateCommand();
                command.CommandText = "CREATE TABLE IF NOT EXISTS `key_presets` (`key` VARCHAR(255) not null PRIMARY KEY, `profile_id` INTEGER not null, `profile_name` VARCHAR(255) not null, `source_url` VARCHAR(255) not null, `target_url` VARCHAR(255) null, `type` INTEGER null DEFAULT '0', `name` VARCHAR(255) null, `state` VARCHAR(255) null, `details` VARCHAR(255) null, `large_image` VARCHAR(255) null, `large_text` VARCHAR(255) null, `small_image` VARCHAR(255) null, `small_text` VARCHAR(255) null, `audible` BOOLEAN null)";
                logger.Trace("Execute query: {0}", command.CommandText);

                command.ExecuteNonQuery();
            } catch(SqliteException e)
            {
                logger.Fatal(e, "Database tables couldn't be created. Application shutdown!");
                throw (new Exception("Database tables couldn't be created. Application shutdown!"));
            } finally 
            { 
                con.Close(); 
            }
        }

        public static bool TestDBConnection()
        {
            logger.Debug("SQL method TestDBConnection called");
            SqliteConnection con = CreateConnection();
            if (con != null) 
            {
                con.Close();
                return true; 
            }
            return false;
        }

        public static List<Profile>? FetchAllProfiles()
        {
            logger.Debug("SQL method FetchAllProfiles called");
            var con = CreateConnection();
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
                        reader.GetString(12),
                        reader.GetBoolean(13)
                    );
                    logger.Trace("Obtained DB values: {0}", profile.ToString2);
                    profiles.Add(profile);
                }
                reader.Close();
            } catch(SqliteException e)
            {
                logger.Error(e, "DB action couldn't be executed");
                return null;
            } finally
            {
                con.Close();
            }
            return profiles;
        }

        public static Profile? GetProfile(int profileId)
        {
            logger.Debug("SQL method GetProfile called");
            var con = CreateConnection();
            if (con == null) return null;

            var command = con.CreateCommand();
            command.CommandText = "SELECT * FROM profiles WHERE profile_id = $profile_id";
            command.Parameters.AddWithValue("$profile_id", profileId);
            logger.Trace("Execute query: {0}", command.CommandText);
            logger.Trace("Parameters passed: {0}", profileId);

            SqliteDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                if (reader.Read())
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
                        reader.GetString(12),
                        reader.GetBoolean(13)
                    );
                    logger.Trace("Obtained DB values: {0}", profile.ToString2);
                    return profile;
                }
                reader.Close();
            }
            catch (SqliteException e)
            {
                logger.Error(e, "DB action couldn't be executed");
                return null;
            }
            finally
            {
                con.Close();
            }
            return null;
        }

        public static int DeleteProfile(int profileId)
        {
            logger.Debug("SQL method DeleteProfile called");
            var con = CreateConnection();
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
            } finally
            {
                con.Close();
            }
        }

        public static int InsertProfile(Profile profile)
        {
            logger.Debug("SQL method InsertProfile called");
            var con = CreateConnection();
            if (con == null) return -1;

            var command = con.CreateCommand();
            command.CommandText = @"INSERT INTO profiles (profile_name, source_url, target_url, type, name, state, details, large_image, large_text, small_image, small_text, key, audible) VALUES($profile_name, $source_url, $target_url, $type, $name, $state, $details, $large_image, $large_text, $small_image, $small_text, $key, $audible)";
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
            command.Parameters.AddWithValue("$key", profile.Key);
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
            } finally
            {
                con.Close();
            }
        }

        public static int UpdateProfile(Profile profile)
        {
            logger.Debug("SQL method UpdateProfile called");
            var con = CreateConnection();
            if (con == null) return -1;

            var command = con.CreateCommand();
            command.CommandText = "UPDATE profiles SET profile_name = $profile_name, source_url = $source_url, target_url = $target_url, type = $type, name = $name, state = $state, details = $details, large_image = $large_image, large_text = $large_text, small_image = $small_image, small_text = $small_text, key = $key, audible = $audible WHERE profile_id = $profile_id";
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
            command.Parameters.AddWithValue("$key", profile.Key);
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
            } finally
            {
                con.Close();
            }
        }

        public static Encryption? GetEncryption()
        {
            logger.Debug("SQL method GetEncryption called");
            var con = CreateConnection();
            if (con == null) return null;

            var command = con.CreateCommand();
            command.CommandText = "SELECT * FROM encryption";
            logger.Trace("Execute query: {0}", command.CommandText);

            try
            {
                SqliteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Encryption encryption = new Encryption(Convert.FromBase64String(reader.GetString(0)), Convert.FromBase64String(reader.GetString(1)));
                    logger.Trace("Values obtained: {0}", encryption.ToString());
                    return encryption;
                }
            } catch(SqliteException e)
            {
                logger.Error("DB action couldn't be executed");
                return null;
            } finally
            {
                con.Close();
            }
            return null;
        }

        public static int InsertEncryption(Encryption encryption)
        {
            logger.Debug("SQL method InsertEncryption called");
            var con = CreateConnection();
            if (con == null) return -1;

            var command = con.CreateCommand();
            command.CommandText = "INSERT INTO encryption (key, iv) VALUES($key, $iv)";
            command.Parameters.AddWithValue("$key", Convert.ToBase64String(encryption.Key));
            command.Parameters.AddWithValue("$iv", Convert.ToBase64String(encryption.IV));
            logger.Trace("Execute query: {0}", command.CommandText);
            logger.Trace("Parameters passed: {0}", encryption.ToString());

            try
            {
                return command.ExecuteNonQuery();
            } catch(SqliteException e)
            {
                logger.Error(e, "DB action couldn't be executed");
                return -1;
            } finally
            {
                con.Close();
            }
        }

        public static int InsertKeyPreset(Profile profile)
        {
            logger.Debug("SQL method InsertKeyPreset called");
            var con = CreateConnection();
            if (con == null) return -1;

            var command = con.CreateCommand();
            command.CommandText = @"INSERT OR REPLACE INTO key_presets (key, profile_id, profile_name, source_url, target_url, type, name, state, details, large_image, large_text, small_image, small_text, audible) VALUES($key, $profile_id, $profile_name, $source_url, $target_url, $type, $name, $state, $details, $large_image, $large_text, $small_image, $small_text, $audible)";
            command.Parameters.AddWithValue("$key", profile.Key);
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
            }
            catch (SqliteException e)
            {
                logger.Error(e, "DB action couldn't be executed");
                return -1;
            }
            finally
            {
                con.Close();
            }
        }

        public static int DeleteKeyPreset(int profile_id)
        {
            logger.Debug("SQL method DeleteKeyPreset called");
            var con = CreateConnection();
            if (con == null) return -1;

            var command = con.CreateCommand();
            command.CommandText = @"DELETE FROM key_presets WHERE profile_id = $profile_id";
            command.Parameters.AddWithValue("$profile_id", profile_id);
            logger.Trace("Execute query: {0}", command.CommandText);
            logger.Trace("Parameters passed: {0}", profile_id);

            try
            {
                return command.ExecuteNonQuery();
            }
            catch (SqliteException e)
            {
                logger.Error(e, "DB action couldn't be executed");
                return -1;
            }
            finally
            {
                con.Close();
            }
        }

        public static Profile? GetKeyPreset(string key)
        {
            logger.Debug("SQL method GetKeyPreset called");
            var con = CreateConnection();
            if (con == null) return null;

            var command = con.CreateCommand();
            command.CommandText = "SELECT * FROM key_presets WHERE key = $key";
            command.Parameters.AddWithValue("$key", key);
            logger.Trace("Execute query: {0}", command.CommandText);
            logger.Trace("Parameters passed: {0}", key);

            SqliteDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Profile profile = new Profile(
                        reader.GetInt32(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4),
                        reader.GetInt32(5),
                        reader.GetString(6),
                        reader.GetString(7),
                        reader.GetString(8),
                        reader.GetString(9),
                        reader.GetString(10),
                        reader.GetString(11),
                        reader.GetString(12),
                        reader.GetString(0),
                        reader.GetBoolean(13)
                    );
                    logger.Trace("Obtained DB values: {0}", profile.ToString2);
                    return profile;
                }
                reader.Close();
            }
            catch (SqliteException e)
            {
                logger.Error(e, "DB action couldn't be executed");
                return null;
            }
            finally
            {
                con.Close();
            }
            return null;
        }
    }
}
