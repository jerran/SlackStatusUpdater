using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SlackStatusUpdater.Models
{
    /// <summary>
    /// Settings
    /// </summary>
    [XmlRoot("settings")]
    public class Settings
    {
        [XmlElement("legacy-api-token")]
        public string LegacyApiToken { get; set; }

        /// <summary>
        /// Use XmlIgnore attribute to prevent xml serialization. This field will be bound to the
        /// actual autostart key value in the Windows registry and will not be read from or
        /// written to the settings file.
        /// </summary>
        [XmlIgnore]
        public bool AutoStart { get; set; }

        [XmlElement("default-status")]
        public Status DefaultStatus { get; set; }

        [XmlElement("wifi-config")]
        public List<StatusProfile> StatusProfiles { get; set; }

    }
}