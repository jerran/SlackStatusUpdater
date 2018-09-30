namespace SlackStatusUpdater
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.tboApiToken = new System.Windows.Forms.TextBox();
            this.dgWifi = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tboDefaultIcon = new System.Windows.Forms.TextBox();
            this.tboDefaultMessage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboAutoStart = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgWifi)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Legacy Api Token:";
            // 
            // tboApiToken
            // 
            this.tboApiToken.Location = new System.Drawing.Point(115, 6);
            this.tboApiToken.Name = "tboApiToken";
            this.tboApiToken.Size = new System.Drawing.Size(607, 20);
            this.tboApiToken.TabIndex = 1;
            // 
            // dgWifi
            // 
            this.dgWifi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgWifi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgWifi.Location = new System.Drawing.Point(12, 56);
            this.dgWifi.Name = "dgWifi";
            this.dgWifi.Size = new System.Drawing.Size(710, 153);
            this.dgWifi.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(646, 276);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Wifi Profiles:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(565, 276);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tboDefaultIcon
            // 
            this.tboDefaultIcon.Location = new System.Drawing.Point(95, 238);
            this.tboDefaultIcon.Name = "tboDefaultIcon";
            this.tboDefaultIcon.Size = new System.Drawing.Size(161, 20);
            this.tboDefaultIcon.TabIndex = 6;
            // 
            // tboDefaultMessage
            // 
            this.tboDefaultMessage.Location = new System.Drawing.Point(262, 238);
            this.tboDefaultMessage.Name = "tboDefaultMessage";
            this.tboDefaultMessage.Size = new System.Drawing.Size(161, 20);
            this.tboDefaultMessage.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Default Status:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(92, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Emoji";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(259, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Text";
            // 
            // cboAutoStart
            // 
            this.cboAutoStart.AutoSize = true;
            this.cboAutoStart.Location = new System.Drawing.Point(510, 240);
            this.cboAutoStart.Name = "cboAutoStart";
            this.cboAutoStart.Size = new System.Drawing.Size(212, 17);
            this.cboAutoStart.TabIndex = 12;
            this.cboAutoStart.Text = "Start automatically on Windows start up";
            this.cboAutoStart.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(495, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(226, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Press DEL on your keyboard to delete a profile";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 311);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboAutoStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tboDefaultMessage);
            this.Controls.Add(this.tboDefaultIcon);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgWifi);
            this.Controls.Add(this.tboApiToken);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.dgWifi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tboApiToken;
        private System.Windows.Forms.DataGridView dgWifi;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tboDefaultIcon;
        private System.Windows.Forms.TextBox tboDefaultMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cboAutoStart;
        private System.Windows.Forms.Label label6;
    }
}