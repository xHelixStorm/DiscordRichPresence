using DiscordRichPresence.enums;
using DiscordRichPresence.modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

namespace DiscordRichPresence.constructors
{
    public class AppConf
    {
        private static readonly string confFileName = "conf.cfg";
        private static readonly string confContent = 
        @"<?xml version=""1.0"" encoding=""utf-8"" ?>
        <configuration>
            <appSettings>
                <Port>{port}</Port>
                <DiscordClientId>{discordClientId}</DiscordClientId>
                <AutoStart>{autoStart}</AutoStart>
                <AutoStartWebservice>{autoStartWebservice}</AutoStartWebservice>
                <Imgur>
                    <ClientId>{clientIdImgur}</ClientId>
                    <ClientSecret>{clientSecretImgur}</ClientSecret>
                    <AccessToken>{accessTokenImgur}</AccessToken>
                    <RefreshToken>{refreshTokenImgur}</RefreshToken>
                    <Expires>{expiresImgur}</Expires>
                </Imgur>
            </appSettings>
        </configuration>";

        private int port = 0;
        private long discordClientId = 0;
        private bool autoStart = false;
        private bool autoStartWebservice = false;
        private Imgur imgur = new Imgur();

        public AppConf()
        {
            //default values are applied
        }

        public AppConf(int port, long discordClientId, bool autoStart, bool autoStartWebservice)
        {
            this.port = port;
            this.discordClientId = discordClientId;
            this.autoStart = autoStart;
            this.autoStartWebservice = autoStartWebservice;
        }

        public int Port
        {
            get { return port; }
            set { port = value; }
        }

        public long DiscordClientId
        {
            get { return discordClientId; }
            set { discordClientId = value; }
        }

        public bool AutoStart
        {
            get { return autoStart; }
            set { autoStart = value; }
        }

        public bool AutoStartWebservice 
        {
            get { return autoStartWebservice; }
            set { autoStartWebservice = value; }
        }

        public Imgur Imgur
        {
            get { return imgur; }
            set { imgur = value; }
        }

        private Encryption Encryption()
        {
            Encryption encryption = modSQL.GetEncryption();
            if (encryption == null)
            {
                var aes = Aes.Create();
                if (aes != null)
                {
                    encryption = new Encryption(aes.Key, aes.IV);
                    modSQL.InsertEncryption(encryption);
                }
                else
                {
                    throw new Exception("Encryption keys couldn't be generated. Application shutdown!");
                }
            }
            return encryption;
        }

        public AppConf Load()
        {
            string config = modUtil.GetFolders().GetPath(Folder.CONFIG) + confFileName;
            if (File.Exists(config))
            {
                Encryption encryption = Encryption();
                string fileContent = modUtil.Decrypt(File.ReadAllBytes(config), encryption.Key, encryption.IV);
                XDocument doc = XDocument.Parse(fileContent);
                XElement configuration = doc.Element("configuration");
                if (configuration != null)
                {
                    XElement appSettings = configuration.Element("appSettings");
                    if (appSettings != null)
                    {
                        foreach (var el in appSettings.Elements())
                        {
                            if (el.Name == "Port")
                                port = Convert.ToInt32(el.Value);
                            else if (el.Name == "DiscordClientId")
                                discordClientId = Convert.ToInt64(el.Value);
                            else if (el.Name == "AutoStart")
                                autoStart = el.Value == "1";
                            else if (el.Name == "AutoStartWebservice")
                                autoStartWebservice = el.Value == "1";
                            else if(el.Name == "Imgur")
                            {
                                foreach(var subEl in el.Elements())
                                {
                                    if (subEl.Name == "ClientId")
                                        imgur.ClientId = subEl.Value;
                                    else if (subEl.Name == "ClientSecret")
                                        imgur.ClientSecret = subEl.Value;
                                    else if (subEl.Name == "AccessToken")
                                        imgur.AccessToken = subEl.Value;
                                    else if (subEl.Name == "RefreshToken")
                                        imgur.RefreshToken = subEl.Value;
                                    else if (subEl.Name == "Expires")
                                        imgur.Expires = Int64.Parse(subEl.Value);
                                }
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid configuration file");
                    }
                }
                else
                {
                    throw new Exception("Invalid configuration file");
                }
            }
            return this;
        }

        public AppConf Save()
        {
            string xml = confContent;
            xml = xml.Replace("{port}", port + "");
            xml = xml.Replace("{discordClientId}", discordClientId + "");
            xml = xml.Replace("{autoStart}", autoStart ? "1" : "0");
            xml = xml.Replace("{autoStartWebservice}", autoStartWebservice ? "1" : "0");

            //Imgur
            xml = xml.Replace("{clientIdImgur}", imgur.ClientId);
            xml = xml.Replace("{clientSecretImgur}", imgur.ClientSecret);
            xml = xml.Replace("{accessTokenImgur}", imgur.AccessToken);
            xml = xml.Replace("{refreshTokenImgur}", imgur.RefreshToken);
            xml = xml.Replace("{expiresImgur}", imgur.Expires+"");

            Encryption encryption = Encryption();
            File.WriteAllBytes(modUtil.GetFolders().GetPath(Folder.CONFIG) + confFileName, modUtil.Encrypt(xml, encryption.Key, encryption.IV));
            return this;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this).Normalize();
        }
    }
}
