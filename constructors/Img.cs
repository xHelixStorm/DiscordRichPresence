using DiscordRichPresence.modules;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DiscordRichPresence.constructors
{
    public class Img
    {
        private string imageId;
        private string url;
        private string key;
        private Album album;

        public Img(string imageId, string url, string key, Album album)
        {
            this.imageId = imageId;
            this.url = url;
            this.key = key;
            this.album = album;
        }

        public string ImageId
        {
            get { return imageId; }
        }

        public string Url
        {
            get { return url; }
        }

        public string Key
        {
            get { return key; }
        }

        public Album Album
        {
            get { return album; }
            set { album = value; }
        }

        public override string ToString()
        {
            return "{\"ImageId\": " + imageId + ", \"Url\": " + url + ", \"Key\": " + key + ", \"Album\": " + album + "}".Normalize();
        }

        public async Task ImageDelete()
        {
            album.ValidateToken();
            var appConf = modUtil.GetAppConf();

            var request = new HttpRequestMessage(HttpMethod.Delete, "https://api.imgur.com/3/image/" + imageId);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", appConf.Imgur.AccessToken);

            await Task.Run(async () =>
            {
                var response = await modUtil.GetHttpClient().SendAsync(request);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            });

            modSQL.DeleteImage(imageId);
        }

        public void UploadImage(string path)
        {
            album.ValidateToken();
            var appConf = modUtil.GetAppConf();

            var request = new MultipartFormDataContent();
            var fileStreamContent = new StreamContent(File.OpenRead(path));

            fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("image/" + Regex.Match(path, @"[\w]*$").ToString().ToLower());
            request.Add(fileStreamContent, "image", Regex.Match(path, @"[\w\d\.:*?""<>]*\.[\w\d]{2,5}$").ToString());
            request.Add(new StringContent(album.AlbumId), "album");

            var task = Task.Run(async () =>
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", appConf.Imgur.AccessToken);
                var response = await client.PostAsync("https://api.imgur.com/3/image", request);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            });
            task.Wait();

            JObject json = JObject.Parse(task.Result);
            json = (JObject)json.GetValue("data");
            imageId = (string)json.GetValue("id");
            url = (string)json.GetValue("link");

            modSQL.InsertImage(this);
        }
    }
}
