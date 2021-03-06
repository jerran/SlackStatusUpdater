﻿using SlackStatusUpdater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SlackStatusUpdater
{
    /// <summary>
    /// Class for guiding the update process
    /// </summary>
    public static class UpdateProcess
    {
        private static Timer _timer;

        private static Status _previousStatus;

        /// <summary>
        /// Start process
        /// </summary>
        public static void Start()
        {
            // Execute update process once when application starts
            Execute();

            // Set timer interval for how often to check for changes that might require a status
            // update
            _timer = new Timer(120000);
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();

        }

        /// <summary>
        /// Timer elapsed event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Execute the update process
            Execute();
        }

        /// <summary>
        /// Executes status update process
        /// </summary>
        private static void Execute()
        {
            // Get connected SSIDs
            var wifiNames = NetworkCheck.GetWifiConnectionSSIDs();

            // Find out the corresponding status to be set
            var statusToSet = StatusProfileService.GetStatus(wifiNames);

            // Null check and compare status to previous status. Update if changed.
            if (statusToSet != null && !statusToSet.Equals(_previousStatus))
            {
                var success = SlackStatusService.SetSlackStatus(statusToSet);
                if (success)
                    _previousStatus = statusToSet;
            }

        }

    }
}
