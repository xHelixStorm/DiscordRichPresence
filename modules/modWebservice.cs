using DiscordRichPresence.constructors;
using Newtonsoft.Json.Linq;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace DiscordRichPresence.modules
{
    public class modWebservice
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private static TcpListener? server = null;
        private static bool interrupt = false;

        public static int RunWebservice()
        {
            interrupt = false;
            AppConf appConf = modUtil.GetAppConf();
            server = new TcpListener(IPAddress.Parse("127.0.0.1"), appConf.Port);
            server.Start();

            int port = Convert.ToInt32(server.LocalEndpoint.ToString()?.Split(":")[1]);
            logger.Info("Webservice started with port: {0}", port);

            Task.Run(() =>
            {
                while (true)
                {
                    TcpClient client = null;
                    NetworkStream stream = null;
                    string origin = "";
                    try
                    {
                        client = server.AcceptTcpClient();
                        logger.Debug("Client connected");
                        stream = client.GetStream();

                        while (!stream.DataAvailable) ;
                        while (client.Available < 3) ;

                        byte[] bytes = new byte[client.Available];
                        stream.Read(bytes, 0, bytes.Length);
                        string data = Encoding.UTF8.GetString(bytes);
                        logger.Trace("Retrieved data from socket: {0}", data);

                        if(data.Contains("Origin: "))
                            origin = Regex.Match(data, @"(Origin):\s.*").Value.Trim().Split(": ")[1];
                        if (data.StartsWith("GET"))
                        {
                            var path = Regex.Match(data, @"(GET).*").Value.Split(" ")[1];
                            if(path.Equals("/test"))
                            {
                                Return200(stream, "Test successful", false, origin);
                            }
                            else if (path.Equals("/profiles"))
                            {
                                List<Profile> profiles = modSQL.FetchAllProfiles();
                                string jsonString = JsonSerializer.Serialize(profiles);
                                Return200(stream, jsonString, true, origin);
                            }
                            else if (path.StartsWith("/preset?key="))
                            {
                                var key = path.Split("=")[1];
                                key = HttpUtility.UrlDecode(key, System.Text.Encoding.UTF8);
                                Profile profile = modSQL.GetKeyPreset(key);
                                if(profile != null)
                                {
                                    string jsonString = JsonSerializer.Serialize(profile);
                                    Return200(stream, jsonString, true, origin);
                                }
                                else
                                {
                                    Return404(stream, "Key not found", false, origin);
                                }
                            }
                            else
                            {
                                Return404(stream, "Path '" + path + "' not found", false, origin);
                            }
                        }
                        else if (data.StartsWith("POST"))
                        {
                            string contentType = Regex.Match(data, @"(Content\-Type|content\-type):\s.*").Value;
                            if(contentType.Contains("application/json"))
                            {
                                string body = Regex.Replace(data, @"^[\d\w\s\/&=\.\-:*,;\()\[\]]*(\n)", "");
                                var path = Regex.Match(data, @"(POST).*").Value.Split(" ")[1];
                                if(path.Equals("/activity"))
                                {
                                    var json = JObject.Parse(body);
                                    if (json.ContainsKey("action"))
                                    {
                                        string action = (string)json.GetValue("action");
                                        switch(action)
                                        {
                                            case "update":
                                                if (json.ContainsKey("profile"))
                                                {
                                                    JObject profile = (JObject)json.GetValue("profile");
                                                    if (profile.ContainsKey("Type") && profile.ContainsKey("Name") && 
                                                    profile.ContainsKey("State") && profile.ContainsKey("Details") && 
                                                    profile.ContainsKey("LargeImage") && profile.ContainsKey("LargeText") && 
                                                    profile.ContainsKey("SmallImage") && profile.ContainsKey("SmallText") &&
                                                    profile.ContainsKey("Key"))
                                                    {
                                                        if(appConf.DiscordClientId > 0)
                                                        {
                                                            string key = (string)profile.GetValue("Key");
                                                            string largeImage = (string)profile.GetValue("LargeImage");
                                                            string smallImage = (string)profile.GetValue("SmallImage");

                                                            if (Regex.IsMatch(largeImage, @"\{::album:.*::\}"))
                                                                largeImage = resolveAlbumKey(largeImage, key);
                                                            if (Regex.IsMatch(smallImage, @"\{::album:.*::\}"))
                                                                smallImage = resolveAlbumKey(smallImage, key);

                                                            profile["LargeImage"] = largeImage;
                                                            profile["SmallImage"] = smallImage;

                                                            modDiscord.InitializeActivity(profile);
                                                            Return200(stream, "{\"message\": \"Discord activity set.\"}", true, origin);
                                                        }
                                                        else
                                                        {
                                                            Return400(stream, "{\"message\": \"Discord client id has not been provided.\"}", true, origin);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Return400(stream, "{\"message\": \"A required object value of profile is missing.\"}", true, origin);
                                                    }
                                                }
                                                else
                                                {
                                                    Return400(stream, "{\"message\": \"Profile object is required.\"}", true, origin);
                                                }
                                                break;
                                            case "stop":
                                                modDiscord.StopActivity();
                                                Return200(stream, "{\"message\": \"Discord activity has been stopped.\"}", true, origin);
                                                break;
                                            default:
                                                Return400(stream, "{\"message\": \"Action type invalid.\"}", true, origin);
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        Return400(stream, "{\"message\": \"action type is required.\"}", true, origin);
                                    }
                                }
                                else if (path.Equals("/preset"))
                                {
                                    var json = JObject.Parse(body);
                                    if (json.ContainsKey("action"))
                                    {
                                        string action = (string)json.GetValue("action");
                                        if (action.Equals("save"))
                                        {
                                            if (json.ContainsKey("profile"))
                                            {
                                                json = (JObject)json.GetValue("profile");
                                                if (json.ContainsKey("ProfileId") && json.ContainsKey("ProfileName") && 
                                                    json.ContainsKey("SourceUrl") && json.ContainsKey("TargetUrl") &&
                                                    json.ContainsKey("Type") && json.ContainsKey("Name") &&
                                                    json.ContainsKey("State") && json.ContainsKey("Details") &&
                                                    json.ContainsKey("LargeImage") && json.ContainsKey("LargeText") &&
                                                    json.ContainsKey("SmallImage") && json.ContainsKey("SmallText") && 
                                                    json.ContainsKey("Key") && json.ContainsKey("Audible") && 
                                                    json.ContainsKey("Reload"))
                                                {
                                                    var profile = new Profile(
                                                        (int)json.GetValue("ProfileId"),
                                                        (string)json.GetValue("ProfileName"),
                                                        (string)json.GetValue("SourceUrl"),
                                                        (string)json.GetValue("TargetUrl"),
                                                        (int)json.GetValue("Type"),
                                                        (string)json.GetValue("Name"),
                                                        (string)json.GetValue("State"),
                                                        (string)json.GetValue("Details"),
                                                        (string)json.GetValue("LargeImage"),
                                                        (string)json.GetValue("LargeText"),
                                                        (string)json.GetValue("SmallImage"),
                                                        (string)json.GetValue("SmallText"),
                                                        (string)json.GetValue("Key"),
                                                        (bool)json.GetValue("Audible"),
                                                        (bool)json.GetValue("Reload")
                                                    );

                                                    UploadImage(profile.LargeImage);
                                                    UploadImage(profile.SmallImage);

                                                    if(modSQL.InsertKeyPreset(profile) > 0)
                                                    {
                                                        Return200(stream, "{\"message\": \"Success.\"}", true, origin);
                                                    }
                                                    else
                                                    {
                                                        Return500(stream, "{\"message\": \"An unexpected error occurred.\"}", true, origin);
                                                    }
                                                }
                                                else
                                                {
                                                    Return400(stream, "{\"message\": \"A required object value of profile is missing.\"}", true, origin);
                                                }
                                            }
                                            else
                                            {
                                                Return400(stream, "{\"message\": \"Profile object is required.\"}", true, origin);
                                            }
                                        }
                                        else
                                        {
                                            Return400(stream, "{\"message\": \"Action type invalid.\"}", true, origin);
                                        }
                                    }
                                }
                                else
                                {
                                    Return404(stream, "Path '" + path + "' not found", false, origin);
                                }
                            }
                            else
                            {
                                Return501(stream, "Invalid Content-Type. Only application/json is allowed.", false, origin);
                            }
                        }
                        else
                        {
                            Return501(stream, "The used method is not implemented", false, origin);
                        }
                    } catch(Exception e)
                    {
                        if (interrupt)
                        {
                            logger.Info("Webservice stopped");
                            break;
                        }
                        else
                        {
                            logger.Error(e, "An unexpected error occurred");
                            if (stream != null)
                                Return500(stream, "An unexpected error occurred", false, origin);
                        }
                    }
                    finally
                    {
                        //close to safely deallocate memmory
                        if (stream != null)
                            stream.Close();
                        if (client != null)
                            client.Close();
                    }
                }
            });

            return port;
        }

        private static string resolveAlbumKey(string field, string key)
        {
            field = field.Replace("{::album:", "");
            field = Regex.Replace(field, @"::\}$", "");
            var values = field.Split(":");
            string albumId = "";
            string imageId = "";
            bool keyBind = false;
            for (int i = 0; i < values.Length; i++)
            {
                if (i == 0)
                    albumId = values[i];
                else if (i == 1 && values[i] != "keybind")
                    imageId = values[i];
                else if (i == 1 && values[i] == "keybind")
                    keyBind = true;
                else
                    return "";
            }
            if (imageId.Length > 0)
            {
                var image = modSQL.GetImage(albumId, imageId);
                if (image != null)
                {
                    return image.Url;
                }
                else
                {
                    var images = modSQL.GetAlbumImages(albumId);
                    if (images != null)
                    {
                        var index = new Random().Next(0, images.Count);
                        return images[index].ImageId;
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            else if (keyBind)
            {
                var image = modSQL.GetImageByKey(albumId, key);
                if (image != null)
                {
                    return image.Url;
                }
                else
                {
                    var images = modSQL.GetAlbumImages(albumId);
                    if (images != null)
                    {
                        var index = new Random().Next(0, images.Count);
                        return images[index].Url;
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            else
            {
                var images = modSQL.GetAlbumImages(albumId);
                if (images != null)
                {
                    var index = new Random().Next(0, images.Count);
                    return images[index].Url;
                }
                else
                {
                    return "";
                }
            }
        }

        public async static void UploadImage(string url)
        {
            if (!Regex.IsMatch(url, @"(http|https):\/\/.*\.(png|jpg|gif)")) return;
            if (!modSQL.UploadedImageExists(url))
            {
                Album album = modSQL.GetDefaultAlbum();
                if(album != null)
                {
                    album.ValidateToken();
                    AppConf appConf = modUtil.GetAppConf();

                    var request = new MultipartFormDataContent();

                    request.Add(new StringContent(url), "image");
                    request.Add(new StringContent("url"), "type");
                    request.Add(new StringContent(album.AlbumId), "album");

                    try
                    {
                        var client = new HttpClient();
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", appConf.Imgur.AccessToken);
                        var response = await client.PostAsync("https://api.imgur.com/3/image", request);
                        response.EnsureSuccessStatusCode();
                        JObject json = JObject.Parse(await response.Content.ReadAsStringAsync());

                        json = (JObject)json.GetValue("data");

                        Img img = new Img(
                            (string)json.GetValue("id"),
                            (string)json.GetValue("link"),
                            "",
                            album
                        );

                        modSQL.InsertImage(img);
                        modSQL.InsertUploadedImage(url, img.Url);
                    } catch(Exception ex)
                    {
                        logger.Error(ex, "Image of url {0} couldn't be uploaded to Imgur or couldn't be saved to this application", url);
                    }
                }
            }
        }

        public static void StopWebservice()
        {
            if (server != null)
            {
                interrupt = true;
                server.Stop();
            }
        }

        private static void Return200(NetworkStream stream, string message, bool json, string origin)
        {
            byte[] response = Encoding.UTF8.GetBytes(
                "HTTP/1.1 200 OK\r\n" +
                "Access-Control-Allow-Origin: "+origin+"\r\n" +
                "Server: Discord Rich Presence by xHelixStorm\r\n" +
                "Date: " + DateTime.Now + "\r\n" +
                "Content-Type: " + (json ? "application/json" : "text/plain") + "\r\n" +
                "\r\n" +
                message
            );
            stream.Write(response, 0, response.Length);
        }

        private static void Return400(NetworkStream stream, string message, bool json, string origin)
        {
            byte[] response = Encoding.UTF8.GetBytes(
                "HTTP/1.1 400 Bad Request\r\n" +
                "Access-Control-Allow-Origin: " + origin + "\r\n" +
                "Server: Discord Rich Presence by xHelixStorm\r\n" +
                "Date: " + DateTime.Now + "\r\n" +
                "Content-Type: " + (json ? "application/json" : "text/plain") + "\r\n" +
                "\r\n" +
                message
            );
            stream.Write(response, 0, response.Length);
        }

        private static void Return404(NetworkStream stream, string message, bool json, string origin)
        {
            byte[] response = Encoding.UTF8.GetBytes(
                "HTTP/1.1 404 Not Found\r\n" +
                "Access-Control-Allow-Origin: " + origin + "\r\n" +
                "Server: Discord Rich Presence by xHelixStorm\r\n" +
                "Date: " + DateTime.Now + "\r\n" +
                "Content-Type: " + (json ? "application/json" : "text/plain") + "\r\n" +
                "\r\n" +
                message
            );
            stream.Write(response, 0, response.Length);
        }

        private static void Return500(NetworkStream stream, string message, bool json, string origin)
        {
            byte[] response = Encoding.UTF8.GetBytes(
                "HTTP/1.1 500 Internal Server Error\r\n" +
                "Access-Control-Allow-Origin: " + origin + "\r\n" +
                "Server: Discord Rich Presence by xHelixStorm\r\n" +
                "Date: " + DateTime.Now + "\r\n" +
                "Content-Type: " + (json ? "application/json" : "text/plain") + "\r\n" +
                "\r\n" +
                message
            );
            stream.Write(response, 0, response.Length);
        }

        private static void Return501(NetworkStream stream, string message, bool json, string origin)
        {
            byte[] response = Encoding.UTF8.GetBytes(
                "HTTP/1.1 501 Not Implemented\r\n" +
                "Access-Control-Allow-Origin: " + origin + "\r\n" +
                "Server: Discord Rich Presence by xHelixStorm\r\n" +
                "Date: " + DateTime.Now + "\r\n" +
                "Content-Type: " + (json ? "application/json" : "text/plain") + "\r\n" +
                "\r\n" +
                message
            );
            stream.Write(response, 0, response.Length);
        }
    }
}
