using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZulipStatusUpdater
{
    public static class Constants
    {
        public static readonly string NAME_OF_APP = "ZulipStatusUpdater";


    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static RunIcon runicon;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            runicon = new RunIcon();
            // Start automatic status updates process
            UpdateProcess.Start();
            // Make sure the application runs!
            Application.Run(Program.runicon);


        }
    }
}
