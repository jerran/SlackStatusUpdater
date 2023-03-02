using ZulipStatusUpdater.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZulipStatusUpdater
{
    /// <summary>
    /// Disposable class for handling the system tray icon
    /// </summary>
    class TrayIcon : IDisposable
    {

        /// <summary>
        ///  System tray icon
        /// </summary>
        NotifyIcon ni;

        /// <summary>
        /// Constructor
        /// </summary>
        public TrayIcon()
        {
            // Initialize NotifyIcon
            ni = new NotifyIcon();
            ni.ContextMenuStrip = ContextMenuFactory.Create();
            ni.Icon = Resources.zulipicon;
            ni.Visible = true;
            ni.Click += new System.EventHandler(NotifyIcon_Click);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            // Disappear the system tray icon as soon as the application exits
            ni.Icon = null;
            ni.Visible = false;
            ni.Dispose();
        }

        public void NotifyIcon_Click(object sender, System.EventArgs e)
        {
            UpdateProcess.Execute();
        }

        public void Show_Ballon(string text)
        {
            
            int timeout = 3;
            ToolTipIcon icon = new ToolTipIcon();
            ni.ShowBalloonTip(timeout,text,text,icon);

        }
    }
}
