using RestSharp;
using SlackStatusUpdater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackStatusUpdater
{
    /// <summary>
    /// Class for setting slack status
    /// </summary>
    public static class StatusSetter
    {
        /// <summary>
        /// Set slack status
        /// </summary>
        /// <param name="status">Status to set</param>
        /// <returns>Status setting success</returns>
        public static bool SetSlackStatus(Status status)
        {
            var tokenString = SettingsManager.GetSettings().LegacyApiToken;

            var client = new RestClient("https://slack.com/api/");

            var request = new RestRequest(Method.POST);

            request.Resource = "users.profile.set";
            request.AddHeader("Content-Type", "application/json");
            // Slack API wants string "Bearer " in front of token
            request.AddHeader("Authorization", "Bearer " + tokenString);
            request.RequestFormat = DataFormat.Json;

            request.AddBody(
                new
                {
                    profile = new
                    {
                        status_text = status.Text,
                        status_emoji = status.Emoji
                    }
                }
                );

            var response = client.Execute(request);

            return response.StatusCode == System.Net.HttpStatusCode.OK;

        }
    }
}
