using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ZulipStatusUpdater.Classes
{
    public static class ActivityMonitor
    {
        //taken from http://joelabrahamsson.com/detecting-mouse-and-keyboard-input-with-net/

            [DllImport("User32.dll")]
            private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

            public static DateTime GetLastInputTime()
            {
                var lastInputInfo = new LASTINPUTINFO();
                lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);

                GetLastInputInfo(ref lastInputInfo);

                return DateTime.Now.AddMilliseconds(-(Environment.TickCount - lastInputInfo.dwTime));
            }

            [StructLayout(LayoutKind.Sequential)]
            internal struct LASTINPUTINFO
            {
                public uint cbSize;
                public uint dwTime;
            }
        

    }
}
