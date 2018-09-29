using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlackStatusUpdater
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Make sure tray icon is disposed when application exits
            using (TrayIcon trayIcon = new TrayIcon())
            {
                // Start automatic status updates process
                UpdateProcess.Start();

                // Make sure the application runs!
                Application.Run();
            }
        }
    }
}
