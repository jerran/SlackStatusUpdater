﻿using SlackStatusUpdater.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlackStatusUpdater
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
            ni.Icon = Resources.slackupdater_icon;
            ni.Visible = true;
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
    }
}
