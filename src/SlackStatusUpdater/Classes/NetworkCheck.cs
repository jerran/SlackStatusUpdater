//using NativeWifi;
using ManagedNativeWifi;
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
        //private static WlanClient _wlan = new WlanClient();

        /// <summary>
        /// Get connected wifi names
        /// </summary>
        /// <returns>List of connected wifi names</returns>
        public static List<string> GetWifiConnectionSSIDs()
        {
            List<String> connectedSsids = new List<string>();
            

            foreach (NetworkIdentifier ssid in NativeWifi.EnumerateAvailableNetworkSsids())
            {
                //connectedSsids.Add(new String(ssid.ToString()));
                connectedSsids.Add(ssid.ToString());

            }



          

            return connectedSsids;
        }
    }
}
