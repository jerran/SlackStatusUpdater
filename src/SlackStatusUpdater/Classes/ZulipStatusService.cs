﻿using RestSharp;
using RestSharp.Authenticators;
using ZulipStatusUpdater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using NetTools;
using ZulipStatusUpdater.Classes;

namespace ZulipStatusUpdater
{
    /// <summary>
    /// Class for setting slack status
    /// </summary>
    public static class ZulipStatusService
    {
        /// <summary>
        /// Set zulip status with the API
        /// </summary>
        /// <param name="status">Status to set</param>
        /// <returns>Status setting success</returns>
        public static bool SetZulipStatus(Status status, string localIP)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            var formData = new List<KeyValuePair<string, string>>() {
                new KeyValuePair<string, string>("status_text", (status.SendIP ? status.Text +" "+  localIP: status.Text)),
                new KeyValuePair<string, string>("emoji_name", status.Emoji),
                /*new KeyValuePair<string, string>("emoji_code", "1f697"),*/
                /*new KeyValuePair<string, string>("reaction_type", "unicode_emoji"),*/
                new KeyValuePair<string, string>("reaction_type",(GetRealmEmojis().Contains(status.Emoji) ? "realm_emoji":"unicode_emoji"))
            };


            var client = new RestClient(SettingsManager.GetSettings().ZulipRealm +"/api/v1/users/me/status");
            client.Authenticator = new HttpBasicAuthenticator(SettingsManager.GetSettings().ZulipEmail, SettingsManager.GetSettings().ZulipApikey);

            var request = new RestRequest(Method.POST);

            request.RequestFormat = DataFormat.Json;
            foreach (var p in formData)
            {
                request.AddParameter(p.Key, p.Value);
            }

            var response = client.Execute(request);

            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        /// <summary>
        /// Get zulip status from the API
        /// </summary>
        /// <returns>The current slack status</returns>
        public static Status GetZulipStatus()
        {


            /* Get user status endpoint not implemented... 
             * 
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            var client = new RestClient(SettingsManager.GetSettings().ZulipRealm + "/api/v1/users/me/status");

            var request = new RestRequest(Method.POST);



            var tokenString = SettingsManager.GetSettings().LegacyApiToken;

            var client = new RestClient("https://slack.com/api/");

            var request = new RestRequest(Method.GET);

            request.Resource = "users.profile.get";
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Authorization", "Bearer " + tokenString);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return null;

            dynamic content = Newtonsoft.Json.Linq.JObject.Parse(response.Content);

            string emoji = content["profile"]["status_emoji"] ?? "";
            string text = content["profile"]["status_text"] ?? "";

            var status = new Status() { Text = text, Emoji = emoji };

            return status;
            */
            var status = new Status() {  };

            return status;
        }

        /// <summary>
        /// Get zulip Apikey
        /// </summary>
        /// <returns>Sets the API-key in the settings</returns>
        public static bool GetZulipApiKey(string Password)
        {

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            var username = SettingsManager.GetSettings().ZulipEmail;

            var client = new RestClient(SettingsManager.GetSettings().ZulipRealm + "/api/v1/fetch_api_key");
            client.UserAgent = "ZulipStatusUpdater";

            var formData = new List<KeyValuePair<string, string>>() {
                new KeyValuePair<string, string>("username", SettingsManager.GetSettings().ZulipEmail),
                new KeyValuePair<string, string>("password", Password),
            };


            var request = new RestRequest(Method.POST);

            request.RequestFormat = DataFormat.Json;
            foreach (var p in formData)
            {
                request.AddParameter(p.Key, p.Value);
            }


            var response = client.Execute(request);

            
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return false;

            dynamic content = Newtonsoft.Json.Linq.JObject.Parse(response.Content);

            var settings = SettingsManager.GetSettings();

            settings.ZulipApikey = content["api_key"] ?? "";

            SettingsManager.ApplySettings(settings);

            if (content["result"] == "success") return true;
            else return false;
            

        }

        /// <summary>
        /// Get zulip realm emojis
        /// </summary>
        /// <returns>list of realm emojis</returns>
        public static List<string> GetRealmEmojis()
        {
            List<string> ListOfRealmEmojis = new List<string>(0);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            var username = SettingsManager.GetSettings().ZulipEmail;

            var client = new RestClient(SettingsManager.GetSettings().ZulipRealm + "/api/v1/realm/emoji");
            client.UserAgent = "ZulipStatusUpdater";

            client.Authenticator = new HttpBasicAuthenticator(SettingsManager.GetSettings().ZulipEmail, SettingsManager.GetSettings().ZulipApikey);
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return new List<string>(0);

            dynamic content = Newtonsoft.Json.Linq.JObject.Parse(response.Content);
            foreach (var field in content.emoji)
            {
                foreach(var emoji in field)
                {
                    if(emoji.deactivated == "false")
                    {
                        ListOfRealmEmojis.Add((string)emoji.name);
                        
                    }
                }
            }
            if (content["result"] == "success") return ListOfRealmEmojis;
           else return new List<string>(0);


        }

        /// <summary>
        /// Get Custom profile fields
        /// </summary>
        /// <returns>list of custom profile fields</returns>
        public static List<string> GetCustomProfileFields()
        {
            List<string> ListOfProfileFields = new List<string>(0);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            var username = SettingsManager.GetSettings().ZulipEmail;

            var client = new RestClient(SettingsManager.GetSettings().ZulipRealm + "/api/v1/realm/profile_fields");
            client.UserAgent = "ZulipStatusUpdater";

            client.Authenticator = new HttpBasicAuthenticator(SettingsManager.GetSettings().ZulipEmail, SettingsManager.GetSettings().ZulipApikey);
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return new List<string>(0);

            dynamic content = Newtonsoft.Json.Linq.JObject.Parse(response.Content);
            foreach (var fields in content.custom_fields)
            {
                foreach (var field in fields)
                {
                       // ListOfProfileFields.Add((string)field.name);

                }
            }
            if (content["result"] == "success") return ListOfProfileFields;
            else return new List<string>(0);


        }


        /// <summary>
        /// Get API key by SSO
        /// </summary>
        /// <returns>Sets the API-key in the settings by SSO</returns>
        //https://chat.zulip.org/#narrow/stream/16-desktop/topic/desktop.20app.20OAuth/near/803919
        // Create secret: 0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef
        // open browser with this url and secret: 
        //https://org.zulipchat.com/accounts/login/google/?mobile_flow_otp=0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef
        // The user needs to copy key to application
        // The app decrypts the key by XORing otp_encrypted_api_key with mobile_flow_otp to get the API key.
        //
        // How the desktop-client does it: 
        // https://github.com/zulip/zulip-mobile/blob/49ed2ef5de3892edf7bb28fbe01271903913bb3d/src/start/webAuth.js
        //
        // How the server responds 
        // https://github.com/zulip/zulip/blob/f4d2d199e249f9c6437a952c201cb0d163eb9069/zerver/lib/mobile_auth_otp.py

        public static byte[] GoogleSSOLogin() {

            var randomGenerator = System.Security.Cryptography.RandomNumberGenerator.Create();

            byte[] randomBytes = new byte[32];
            randomGenerator.GetBytes(randomBytes,0,32);

            string randomString = BitConverter.ToString(randomBytes).Replace("-", "");

            var settings = SettingsManager.GetSettings();

            string target = settings.ZulipRealm + "/accounts/login/google/?mobile_flow_otp=";
            target += randomString;

            System.Diagnostics.Process.Start(target);

            return randomBytes;
        }


        public static string DecryptAPIkeySSO(string encryptedAPIkey, byte[] otp)
        {
            byte[] array = Tools.StringToByteArray(encryptedAPIkey);
            byte[] xored = Tools.exclusiveOR(otp, array);
            string APIkey = System.Text.Encoding.ASCII.GetString(xored);
            return APIkey;
        }

    }
}
