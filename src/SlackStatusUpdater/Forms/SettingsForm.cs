using ZulipStatusUpdater.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZulipStatusUpdater
{
    public partial class SettingsForm : Form
    {
        // Singleton instance field
        private static SettingsForm _instance;

        Settings _settings;

        /// <summary>
        /// Private constructor
        /// </summary>
        private SettingsForm()
        {
            InitializeComponent();

            // Get settings
            _settings = SettingsManager.GetSettings();

            // Bind datagridview to status profiles
            BindingSource bs = new BindingSource();
            bs.DataSource = _settings.StatusProfiles;
            dgWifi.DataSource = bs;

            // Bind other settings form controls to other settings fields.
            // Update data source as soon as data is changed on the form.
            tboApiToken.DataBindings.Add("Text", _settings, "ZulipApikey", false, DataSourceUpdateMode.OnPropertyChanged);
            tboZulipRealmURL.DataBindings.Add("Text", _settings, "ZulipRealm", false, DataSourceUpdateMode.OnPropertyChanged);
            tboDefaultIcon.DataBindings.Add("Text", _settings.DefaultStatus, "Emoji", false, DataSourceUpdateMode.OnPropertyChanged);
            tboDefaultMessage.DataBindings.Add("Text", _settings.DefaultStatus, "Text", false, DataSourceUpdateMode.OnPropertyChanged);
            cboDefaultRealmEmoji.DataBindings.Add("Checked", _settings.DefaultStatus, "IsRealmEmoji", false, DataSourceUpdateMode.OnPropertyChanged);
            cboAutoStart.DataBindings.Add("Checked", _settings, "AutoStart", false, DataSourceUpdateMode.OnPropertyChanged);
            tboZulipUser.DataBindings.Add("Text", _settings, "ZulipEmail", false, DataSourceUpdateMode.OnPropertyChanged);

        }

        /// <summary>
        /// Singleton instance getter
        /// </summary>
        public static SettingsForm GetInstance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new SettingsForm();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Cancel button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Save button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Save changes made to settings
            SettingsManager.ApplySettings(_settings);

            this.Dispose();

        }





        private void btnGetAPIkey_Click(object sender, EventArgs e)
        {

            if (ZulipStatusService.GetZulipApiKey(tboZulipPassword.Text))
            {

                tboApiToken.Text = SettingsManager.GetSettings().ZulipApikey;
                tboZulipPassword.Clear();
                // Save changes made to settings
                //SettingsManager.ApplySettings(_settings);
                //this.Dispose();
            }
            else tboZulipPassword.Clear();
        }

    }
}
