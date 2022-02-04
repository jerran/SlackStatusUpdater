using RestSharp;
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
        public static bool SetZulipStatus(Status status)
        {
            //ZulipAPI.ZulipServer Zerv = new ZulipAPI.ZulipServer(SettingsManager.GetSettings().ZulipRealm);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            //Dictionary< string, string> data)

            var formData = new List<KeyValuePair<string, string>>() {
                new KeyValuePair<string, string>("status_text", status.Text),
                new KeyValuePair<string, string>("emoji_name", status.Emoji),
                /*new KeyValuePair<string, string>("emoji_code", "1f697"),*/
                /*new KeyValuePair<string, string>("reaction_type", "unicode_emoji"),*/
                new KeyValuePair<string, string>("reaction_type", (status.IsRealmEmoji ? "realm_emoji":"unicode_emoji"))
            };


            //var client = new RestClient("https://jli.zulipchat.com/api/v1/users/me/status");
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


            //return response.StatusCode == System.Net.HttpStatusCode.OK;
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
            

            /* Get user status endpoint not implemented... 
             * 

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

        }

    }
}
