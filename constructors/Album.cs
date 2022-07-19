using DiscordRichPresence.modules;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DiscordRichPresence.constructors
{
    public class Album
    {
        private string albumId;
        private string name;
        private bool isDefault;

        public Album(string albumId, string name, bool isDefault)
        {
            this.albumId = albumId;
            this.name = name;
            this.isDefault = isDefault;
        }

        public string AlbumId
        {
            get { return albumId; }
        }

        public string Name
        {
            get { return name; }
        }

        public bool IsDefault
        {
            get { return isDefault; }
        }

        public override string ToString()
        {
            return name;
        }

        public string ToString2()
        {
            return JsonSerializer.Serialize(this).Normalize();
        }

        public void ValidateToken()
        {
            AppConf appConf = modUtil.GetAppConf();
            if(appConf.Imgur.Expires < DateTimeOffset.Now.ToUnixTimeMilliseconds())
            {
                JObject json = new JObject();
                json.Add("refresh_token", appConf.Imgur.RefreshToken);
                json.Add("client_id", appConf.Imgur.ClientId);
                json.Add("client_secret", appConf.Imgur.ClientSecret);
                json.Add("grant_type", "refresh_token");

                var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
                var task = Task.Run(async () =>
                {
                    var response = await modUtil.GetHttpClient().PostAsync("https://api.imgur.com/oauth2/token", content);
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsStringAsync();
                });
                task.Wait();
                json = JObject.Parse(task.Result);

                appConf.Imgur.AccessToken = (string)json.GetValue("access_token");
                appConf.Imgur.RefreshToken = (string)json.GetValue("refresh_token");
                appConf.Imgur.Expires = DateTimeOffset.Now.AddDays(2).ToUnixTimeMilliseconds();

                appConf.Save();

                modUtil.SetAppConf(appConf);
            }
        }

        public void CreateAlbum()
        {
            ValidateToken();
            var appConf = modUtil.GetAppConf();

            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.imgur.com/3/album?title="+name);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", appConf.Imgur.AccessToken);

            var task = Task.Run(async () =>
            {
                var response = await modUtil.GetHttpClient().SendAsync(request);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            });
            task.Wait();

            JObject json = JObject.Parse(task.Result);
            json = (JObject)json.GetValue("data");
            albumId = (string)json.GetValue("id");

            if(modSQL.InsertAlbum(this) == -1)
            {
                throw new Exception("Album couldn't be saved!");
            }
        }

        public void DeleteAlbum()
        {
            ValidateToken();
            var appConf = modUtil.GetAppConf();

            var request = new HttpRequestMessage(HttpMethod.Delete, "https://api.imgur.com/3/album/" + albumId);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", appConf.Imgur.AccessToken);

            var task = Task.Run(async () =>
            {
                var response = await modUtil.GetHttpClient().SendAsync(request);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            });
            task.Wait();

            modSQL.DeleteAlbum(AlbumId);
        }

        public JArray DownloadAlbum()
        {
            var appConf = modUtil.GetAppConf();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.imgur.com/3/album/" + albumId);
            request.Headers.Authorization = new AuthenticationHeaderValue("Client-ID", appConf.Imgur.ClientId);

            var task = Task.Run(async () =>
            {
                var response = await modUtil.GetHttpClient().SendAsync(request);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            });
            task.Wait();

            JObject json = JObject.Parse(task.Result);
            json = (JObject)json.GetValue("data");
            albumId = (string)json.GetValue("id");
            name = (string)json.GetValue("title");
            if(modSQL.InsertAlbum(this) > 0)
            {
                JArray images = (JArray)json.GetValue("images");
                return images;
            }
            else
            {
                throw new Exception("Album couldn't be created.");
            }
        }
    }
}
