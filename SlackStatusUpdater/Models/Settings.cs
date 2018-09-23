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

        [XmlIgnore]
        public bool AutoStart { get; set; }

        [XmlElement("default-status")]
        public Status DefaultStatus { get; set; }

        [XmlElement("wifi-config")]
        public List<StatusConfiguration> StatusConfigs { get; set; }

    }
}