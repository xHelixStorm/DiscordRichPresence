using DiscordRichPresence.modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DiscordRichPresence.constructors
{
    public class AppConf
    {
        private static readonly string confFileName = Application.StartupPath + "conf.cfg";
        private static readonly string confContent = 
        @"<?xml version=""1.0"" encoding=""utf-8"" ?>
        <configuration>
            <appSettings>
                <Port>{port}</Port>
                <DiscordClientId>{discordClientId}</DiscordClientId>
                <AutoStart>{autoStart}</AutoStart>
                <AutoStartWebservice>{autoStartWebservice}</AutoStartWebservice>
            </appSettings>
        </configuration>";

        private int port = 0;
        private long discordClientId = 0;
        private bool autoStart = false;
        private bool autoStartWebservice = false;

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
            if (File.Exists(confFileName))
            {
                Encryption encryption = Encryption();
                string fileContent = modUtil.Decrypt(File.ReadAllBytes(confFileName), encryption.Key, encryption.IV);
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
                                AutoStartWebservice = el.Value == "1";
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

            Encryption encryption = Encryption();
            File.WriteAllBytes(confFileName, modUtil.Encrypt(xml, encryption.Key, encryption.IV));
            return this;
        }

        public override string ToString()
        {
            return "{\"Port\": " + port + ", \"DiscordClientId\": " + discordClientId + ", \"AutoStart\": " + autoStart + ", \"AutoStartWebservice\": " + autoStartWebservice + "}".Normalize();
        }
    }
}
