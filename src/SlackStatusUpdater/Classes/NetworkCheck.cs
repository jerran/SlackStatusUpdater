using NativeWifi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZulipStatusUpdater
{
    /// <summary>
    /// Class for checking wifi connections
    /// </summary>
    public static class NetworkCheck
    {
        /// <summary>
        /// WlanClient
        /// </summary>
        private static WlanClient _wlan = new WlanClient();

        /// <summary>
        /// Get connected wifi names
        /// </summary>
        /// <returns>List of connected wifi names</returns>
        public static List<string> GetWifiConnectionSSIDs()
        {
            List<String> connectedSsids = new List<string>();

            foreach (WlanClient.WlanInterface wlanInterface in _wlan.Interfaces)
            {
                try
                {
                    Wlan.Dot11Ssid ssid = wlanInterface.CurrentConnection.wlanAssociationAttributes.dot11Ssid;
                    connectedSsids.Add(new String(Encoding.ASCII.GetChars(ssid.SSID, 0, (int)ssid.SSIDLength)));
                }
                catch (Exception)
                {
                    // Wlan interface properties throw exceptions in certain states. Ignore these.
                }
            }

            return connectedSsids;
        }
    }
}
