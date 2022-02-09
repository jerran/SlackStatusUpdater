//using NativeWifi;
using ManagedNativeWifi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
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

        public static string GetCurrentIP()
        {
            string localIP;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect(SettingsManager.GetSettings().local_server, 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
            }
            return localIP;
        }
    }
}
