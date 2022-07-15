﻿using DiscordRichPresence.constructors;
using Newtonsoft.Json.Linq;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
                                                    profile.ContainsKey("SmallImage") && profile.ContainsKey("SmallText"))
                                                    {
                                                        if(appConf.DiscordClientId > 0)
                                                        {
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
