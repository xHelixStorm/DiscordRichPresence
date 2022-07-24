using DiscordRichPresence.constructors;
using DiscordRichPresence.enums;
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

        private static readonly string SQLCONNECTION = "Data Source=" + modUtil.GetFolders().GetPath(Folder.CONFIG) + "DiscordRichPresence.db;";

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
                command.CommandText = "CREATE TABLE IF NOT EXISTS `profiles` (`profile_id` INTEGER not null primary key autoincrement, `profile_name` VARCHAR(255) not null, `source_url` VARCHAR(255) not null, `target_url` VARCHAR(255) not null, `type` INTEGER not null DEFAULT '0', `name` VARCHAR(255) not null, `state` VARCHAR(255) not null, `details` VARCHAR(255) not null, `large_image` VARCHAR(255) not null, `large_text` VARCHAR(255) not null, `small_image` VARCHAR(255) not null, `small_text` VARCHAR(255) not null, `key` VARCHAR(255) not null, `audible` BOOLEAN not null, `reload` BOOLEAN not null, `created_at` datetime not null default CURRENT_TIMESTAMP)";
                logger.Trace("Execute query: {0}", command.CommandText);

                command.ExecuteNonQuery();

                command = con.CreateCommand();
                command.CommandText = "CREATE TABLE IF NOT EXISTS `encryption` (`key` VARCHAR(255) not null PRIMARY KEY, `iv` VARCHAR(255) not null)";
                logger.Trace("Execute query: {0}", command.CommandText);

                command.ExecuteNonQuery();

                command = con.CreateCommand();
                command.CommandText = "CREATE TABLE IF NOT EXISTS `key_presets` (`key` VARCHAR(255) not null PRIMARY KEY, `profile_id` INTEGER not null, `profile_name` VARCHAR(255) not null, `source_url` VARCHAR(255) not null, `target_url` VARCHAR(255) not null, `type` INTEGER not null DEFAULT '0', `name` VARCHAR(255) not null, `state` VARCHAR(255) not null, `details` VARCHAR(255) not null, `large_image` VARCHAR(255) not null, `large_text` VARCHAR(255) not null, `small_image` VARCHAR(255) not null, `small_text` VARCHAR(255) not null, `audible` BOOLEAN not null, `reload` BOOLEAN not null)";
                logger.Trace("Execute query: {0}", command.CommandText);

                command.ExecuteNonQuery();

                command = con.CreateCommand();
                command.CommandText = "CREATE TABLE IF NOT EXISTS `albums` (`album_id` VARCHAR(255) not null primary key, `name` VARCHAR(255) not null, `default` BOOLEAN not null)";
                logger.Trace("Execute query: {0}", command.CommandText);

                command.ExecuteNonQuery();

                command = con.CreateCommand();
                command.CommandText = "CREATE TABLE IF NOT EXISTS `images` (`image_id` VARCHAR(255) not null primary key, `url` VARCHAR(255) not null, `key` VARCHAR(255) not null, `album_id` VARCHAR(255) not null)";
                logger.Trace("Execute query: {0}", command.CommandText);

                command.ExecuteNonQuery();

                command = con.CreateCommand();
                command.CommandText = "CREATE TABLE IF NOT EXISTS `uploaded_images` (`orig_url` VARCHAR(255) not null primary key, `new_url` VARCHAR(255) not null)";
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
                        reader.GetBoolean(13),
                        reader.GetBoolean(14)
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
                        reader.GetBoolean(13),
                        reader.GetBoolean(14)
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
            command.CommandText = @"INSERT INTO profiles (profile_name, source_url, target_url, type, name, state, details, large_image, large_text, small_image, small_text, key, audible, reload) VALUES($profile_name, $source_url, $target_url, $type, $name, $state, $details, $large_image, $large_text, $small_image, $small_text, $key, $audible, $reload)";
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
            command.Parameters.AddWithValue("$reload", profile.Reload);
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
            command.CommandText = "UPDATE profiles SET profile_name = $profile_name, source_url = $source_url, target_url = $target_url, type = $type, name = $name, state = $state, details = $details, large_image = $large_image, large_text = $large_text, small_image = $small_image, small_text = $small_text, key = $key, audible = $audible, reload = $reload WHERE profile_id = $profile_id";
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
            command.Parameters.AddWithValue("$reload", profile.Reload);
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
            command.CommandText = @"INSERT OR REPLACE INTO key_presets (key, profile_id, profile_name, source_url, target_url, type, name, state, details, large_image, large_text, small_image, small_text, audible, reload) VALUES($key, $profile_id, $profile_name, $source_url, $target_url, $type, $name, $state, $details, $large_image, $large_text, $small_image, $small_text, $audible, $reload)";
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
            command.Parameters.AddWithValue("$reload", profile.Reload);
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
                        reader.GetBoolean(13),
                        reader.GetBoolean(14)
                    );
                    logger.Trace("Obtained DB values: {0}", profile.ToString2());
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

        public static List<Album>? GetAllAlbums()
        {
            logger.Debug("SQL method GetAllAlbums called");
            var con = CreateConnection();
            if (con == null) return null;

            var command = con.CreateCommand();
            command.CommandText = "SELECT * FROM albums";
            logger.Trace("Execute query: {0}", command.CommandText);

            List<Album> albums = new List<Album>();
            SqliteDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Album album = new Album(
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetBoolean(2)
                    );
                    logger.Trace("Obtained DB values: {0}", album.ToString2());
                    albums.Add(album);
                }
                reader.Close();
                return albums;
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
        }

        public static Album? GetDefaultAlbum()
        {
            logger.Debug("SQL method GetDefaultAlbum called");
            var con = CreateConnection();
            if (con == null) return null;

            var command = con.CreateCommand();
            command.CommandText = "SELECT * FROM albums WHERE `default` = 1";
            logger.Trace("Execute query: {0}", command.CommandText);

            try
            {
                SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Album album = new Album(
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetBoolean(2)
                    );
                    logger.Trace("Obtained DB values: {0}", album.ToString2());
                    return album;
                }
                reader.Close();
                return null;
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
        }

        public static List<Img>? GetAlbumImages(string albumId)
        {
            logger.Debug("SQL method GetAlbumImages called");
            var con = CreateConnection();
            if (con == null) return null;

            var command = con.CreateCommand();
            if(albumId.Length == 0)
            {
                command.CommandText = "SELECT a.album_id, a.name, a.`default`, b.image_id, b.url, b.key FROM albums a INNER JOIN images b ON a.album_id = b.album_id ORDER BY a.album_id";
                logger.Trace("Execute query: {0}", command.CommandText);
            }
            else
            {
                command.CommandText = "SELECT a.album_id, a.name, a.`default`, b.image_id, b.url, b.key FROM albums a INNER JOIN images b ON a.album_id = b.album_id WHERE a.album_id = $album_id ORDER BY a.album_id";
                command.Parameters.AddWithValue("$album_id", albumId);
                logger.Trace("Execute query: {0}", command.CommandText);
                logger.Trace("Parameters passed {0}, {1}", albumId);
            }

            List<Img> images = new List<Img>();
          
            try
            {
                SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Img img = new Img(
                        reader.GetString(3),
                        reader.GetString(4),
                        reader.GetString(5),
                        new Album(
                            reader.GetString(0),
                            reader.GetString(1),
                            reader.GetBoolean(2)
                        )
                    );
                    logger.Trace("Obtained DB values: {0}", img.ToString());
                    images.Add(img);
                }
                reader.Close();
                return images;
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
        }

        public static int UpdateAlbumDefault(string albumId, bool isDefault)
        {
            logger.Debug("SQL method UpdateAlbumDefault called");
            var con = CreateConnection();
            if (con == null) return -1;

            var command = con.CreateCommand();
            command.CommandText = @"UPDATE albums SET `default` = $default WHERE album_id = $album_id";
            command.Parameters.AddWithValue("$album_id", albumId);
            command.Parameters.AddWithValue("$default", isDefault);
            logger.Trace("Execute query: {0}", command.CommandText);
            logger.Trace("Parameters passed: {0}, {1}", albumId, isDefault);

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

        public static int InsertAlbum(Album album)
        {
            logger.Debug("SQL method InsertAlbum called");
            var con = CreateConnection();
            if (con == null) return -1;

            var command = con.CreateCommand();
            command.CommandText = @"INSERT OR REPLACE INTO albums (album_id, name, `default`) VALUES($album_id, $name, $default)";
            command.Parameters.AddWithValue("$album_id", album.AlbumId);
            command.Parameters.AddWithValue("$name", album.Name);
            command.Parameters.AddWithValue("$default", album.IsDefault);
            logger.Trace("Execute query: {0}", command.CommandText);
            logger.Trace("Parameters passed: {0}", album.ToString2());

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

        public static int DeleteAlbum(string albumId)
        {
            logger.Debug("SQL method DeleteAlbum called");
            var con = CreateConnection();
            if (con == null) return -1;

            var command = con.CreateCommand();
            command.CommandText = @"DELETE FROM albums WHERE album_id = $album_id";
            command.Parameters.AddWithValue("$album_id", albumId);
            logger.Trace("Execute query: {0}", command.CommandText);
            logger.Trace("Parameters passed: {0}", albumId);

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

        public static int InsertImage(Img image)
        {
            logger.Debug("SQL method InsertImage called");
            var con = CreateConnection();
            if (con == null) return -1;

            var command = con.CreateCommand();
            command.CommandText = @"INSERT OR REPLACE INTO images (image_id, url, key, album_id) VALUES($image_id, $url, $key, $album_id)";
            command.Parameters.AddWithValue("$image_id", image.ImageId);
            command.Parameters.AddWithValue("$url", image.Url);
            command.Parameters.AddWithValue("$key", image.Key);
            command.Parameters.AddWithValue("$album_id", image.Album.AlbumId);
            logger.Trace("Execute query: {0}", command.CommandText);
            logger.Trace("Parameters passed: {0}", image.ToString());

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

        public static int DeleteImage(string imageId)
        {
            logger.Debug("SQL method DeleteImage called");
            var con = CreateConnection();
            if (con == null) return -1;

            var command = con.CreateCommand();
            command.CommandText = @"DELETE FROM images WHERE image_id = $image_id";
            command.Parameters.AddWithValue("$image_id", imageId);
            logger.Trace("Execute query: {0}", command.CommandText);
            logger.Trace("Parameters passed: {0}", imageId);

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

        public static int UpdateImageKeyBind(string imageId, string key)
        {
            logger.Debug("SQL method DeleteImage called");
            var con = CreateConnection();
            if (con == null) return -1;

            var command = con.CreateCommand();
            command.CommandText = @"UPDATE images SET key = $key WHERE image_id = $image_id";
            command.Parameters.AddWithValue("$image_id", imageId);
            command.Parameters.AddWithValue("$key", key);
            logger.Trace("Execute query: {0}", command.CommandText);
            logger.Trace("Parameters passed: {0}, {1}", imageId, key);

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

        public static Img? GetImage(string albumId, string imageId)
        {
            logger.Debug("SQL method GetImage called");
            var con = CreateConnection();
            if (con == null) return null;

            var command = con.CreateCommand();
            command.CommandText = "SELECT a.album_id, a.name, a.`default`, b.image_id, b.url, b.key FROM albums a INNER JOIN images b ON a.album_id = b.album_id WHERE a.album_id = $album_id AND b.image_id = $image_id";
            command.Parameters.AddWithValue("$album_id", albumId);
            command.Parameters.AddWithValue("$image_id", imageId);
            logger.Trace("Execute query: {0}", command.CommandText);
            logger.Trace("Parameters passed {0}, {1}", albumId, imageId);

            try
            {
                SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Img img = new Img(
                        reader.GetString(3),
                        reader.GetString(4),
                        reader.GetString(5),
                        new Album(
                            reader.GetString(0),
                            reader.GetString(1),
                            reader.GetBoolean(2)
                        )
                    );
                    logger.Trace("Obtained DB values: {0}", img.ToString());
                    return img;
                }
                reader.Close();
                return null;
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
        }

        public static Img? GetImageByKey(string albumId, string key)
        {
            logger.Debug("SQL method GetImageByKey called");
            var con = CreateConnection();
            if (con == null) return null;

            var command = con.CreateCommand();
            command.CommandText = "SELECT a.album_id, a.name, a.`default`, b.image_id, b.url, b.key FROM albums a INNER JOIN images b ON a.album_id = b.album_id WHERE a.album_id = $album_id AND b.key = $key";
            command.Parameters.AddWithValue("$album_id", albumId);
            command.Parameters.AddWithValue("$key", key);
            logger.Trace("Execute query: {0}", command.CommandText);
            logger.Trace("Parameters passed {0}, {1}", albumId, key);

            try
            {
                SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Img img = new Img(
                        reader.GetString(3),
                        reader.GetString(4),
                        reader.GetString(5),
                        new Album(
                            reader.GetString(0),
                            reader.GetString(1),
                            reader.GetBoolean(2)
                        )
                    );
                    logger.Trace("Obtained DB values: {0}", img.ToString());
                    return img;
                }
                reader.Close();
                return null;
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
        }

        public static bool UploadedImageExists(string url)
        {
            logger.Debug("SQL method UploadedImageExists called");
            var con = CreateConnection();
            if (con == null) return false;

            var command = con.CreateCommand();
            command.CommandText = "SELECT * FROM uploaded_images WHERE orig_url = $orig_url";
            command.Parameters.AddWithValue("$orig_url", url);
            logger.Trace("Execute query: {0}", command.CommandText);
            logger.Trace("Parameters passed {0}, {1}", url);

            try
            {
                SqliteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return true;
                }
                reader.Close();
                return false;
            }
            catch (SqliteException e)
            {
                logger.Error(e, "DB action couldn't be executed");
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static int InsertUploadedImage(string origUrl, string newUrl)
        {
            logger.Debug("SQL method InsertUploadedUrl called");
            var con = CreateConnection();
            if (con == null) return -1;

            var command = con.CreateCommand();
            command.CommandText = @"INSERT INTO uploaded_images (orig_url, new_url) VALUES($orig_url, $new_url)";
            command.Parameters.AddWithValue("$orig_url", origUrl);
            command.Parameters.AddWithValue("$new_url", newUrl);
            logger.Trace("Execute query: {0}", command.CommandText);
            logger.Trace("Parameters passed: {0}, {1}", origUrl, newUrl);

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
    }
}
