using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DiscordRichPresence.constructors
{
    public class Imgur
    {
        private string clientId = "";
        private string clientSecret = "";
        private string accessToken = "";
        private string refreshToken = "";
        private long expires = 0;

        public Imgur()
        {
            //use default values
        }

        public Imgur(string clientId, string clientSecret, string accessToken, string refreshToken, long expires)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            this.accessToken = accessToken;
            this.refreshToken = refreshToken;
            this.expires = expires;
        }

        public string ClientId
        {
            get { return this.clientId; }
            set { this.clientId = value; }
        }

        public string ClientSecret
        {
            get { return this.clientSecret; }
            set { this.clientSecret = value; }
        }

        public string AccessToken
        {
            get { return this.accessToken; }
            set { this.accessToken = value; }
        }

        public string RefreshToken
        {
            get { return this.refreshToken; }
            set { this.refreshToken = value; }
        }

        public long Expires
        {
            get { return this.expires; }
            set { this.expires = value; }
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this).Normalize();
        }
    }
}
