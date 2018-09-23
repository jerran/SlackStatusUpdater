﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using SlackStatusUpdater.Models;

namespace SlackStatusUpdater
{
    /// <summary>
    /// Class for managing application settings
    /// </summary>
    public static class SettingsManager
    {
        /// <summary>
        /// Absolute settings file directory payh
        /// </summary>
        private static string SettingsFileDirectoryPath
        {
            get
            {
                // In roaming AppData
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SlackStatusUpdater");
            }
        }

        /// <summary>
        /// Absolute settings file path
        /// </summary>
        private static string SettingsFilePath
        {
            get
            {
                return Path.Combine(SettingsFileDirectoryPath, @"Settings.xml");
            }
        }

        /// <summary>
        /// Return current settings as object
        /// </summary>
        /// <returns>Current settings</returns>
        public static Settings GetSettings()
        {
            // If settings file doesn't exist, generate it
            if (!File.Exists(SettingsFilePath))
                GenerateDefaultSettingsFile();

            // Read settings from settings file
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Settings));
            Settings settings = new Settings();
            using (TextReader textReader = new StreamReader(SettingsFilePath))
            {
                settings = (Settings)xmlSerializer.Deserialize(textReader);
            }

            // Read autostart setting from registry
            settings.AutoStart = AutoStartManager.AutoStartIsActive();

            return settings;

        }

        /// <summary>
        /// Apply and save new settings
        /// </summary>
        /// <param name="settings">Settings to apply</param>
        public static void ApplySettings(Settings settings)
        {
            // Write to settings file
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Settings));
            using (TextWriter textWriter = new StreamWriter(SettingsFilePath))
            {
                xmlSerializer.Serialize(textWriter, settings);
            }

            // Set autostart setting to registry
            AutoStartManager.SetAutoStart(settings.AutoStart);

        }

        /// <summary>
        /// Generate a default settings file
        /// </summary>
        private static void GenerateDefaultSettingsFile()
        {
            var defaultSettings = new Settings()
            {
                LegacyApiToken = "EXAMPLE123",
                DefaultStatus = new Status()
                {
                    Emoji = ":house:",
                    Text = "Working remotely"
                },
                StatusConfigs = new List<StatusConfiguration>()
                {
                    new StatusConfiguration()
                    {
                        WifiName = "HOME_WIFI",
                        Emoji = ":house:",
                        Text = "At home"
                    },
                    new StatusConfiguration()
                    {
                        WifiName = "OFFICE_WIFI",
                        Emoji = ":computer:",
                        Text = "At the office"
                    }
                }
            };

            if (!Directory.Exists(SettingsFileDirectoryPath))
                Directory.CreateDirectory(SettingsFileDirectoryPath);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Settings));

            using (TextWriter textWriter = new StreamWriter(SettingsFilePath))
            {
                xmlSerializer.Serialize(textWriter, defaultSettings);
            }
        }
    }
}
