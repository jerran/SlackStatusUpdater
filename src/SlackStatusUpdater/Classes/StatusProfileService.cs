﻿using SlackStatusUpdater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackStatusUpdater
{
    /// <summary>
    /// Class for interpreting the status to set based on the list of connected wifis
    /// </summary>
    public static class StatusProfileService
    {
        /// <summary>
        /// Return the status to set based on the list of connected wifis
        /// </summary>
        /// <param name="wifiNames">List of connected wifis</param>
        /// <returns>Status to be set</returns>
        public static Status GetStatus(List<string> wifiNames)
        {
            var settings = SettingsManager.GetSettings();

            Status status = settings.DefaultStatus;

            foreach (StatusProfile profile in settings.StatusProfiles)
            {
                if (wifiNames.Contains(profile.WifiName))
                    status = profile.Status;
            }

            return status;
        }
    }
}
