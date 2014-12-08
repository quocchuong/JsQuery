namespace SQLMiner
{
    partial class frmChangePass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangePass));
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.txtConfirmNewPassword = new wmgCMS.WaterMarkTextBox();
            this.txtNewPassword = new wmgCMS.WaterMarkTextBox();
            this.txtCurrentPassword = new wmgCMS.WaterMarkTextBox();
            this.SuspendLayout();
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(143, 117);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(75, 23);
            this.btnChangePassword.TabIndex = 3;
            this.btnChangePassword.Text = "Update";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // txtConfirmNewPassword
            // 
            this.txtConfirmNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtConfirmNewPassword.Location = new System.Drawing.Point(12, 82);
            this.txtConfirmNewPassword.Name = "txtConfirmNewPassword";
            this.txtConfirmNewPassword.PasswordChar = '*';
            this.txtConfirmNewPassword.Size = new System.Drawing.Size(206, 20);
            this.txtConfirmNewPassword.TabIndex = 2;
            this.txtConfirmNewPassword.WaterMarkColor = System.Drawing.Color.Gray;
            this.txtConfirmNewPassword.WaterMarkText = "Confirm New Password";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtNewPassword.Location = new System.Drawing.Point(12, 47);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(206, 20);
            this.txtNewPassword.TabIndex = 1;
            this.txtNewPassword.WaterMarkColor = System.Drawing.Color.Gray;
            this.txtNewPassword.WaterMarkText = "New Password";
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtCurrentPassword.Location = new System.Drawing.Point(12, 12);
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.PasswordChar = '*';
            this.txtCurrentPassword.Size = new System.Drawing.Size(206, 20);
            this.txtCurrentPassword.TabIndex = 0;
            this.txtCurrentPassword.WaterMarkColor = System.Drawing.Color.Gray;
            this.txtCurrentPassword.WaterMarkText = "Current Password";
            // 
            // frmChangePass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 154);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.txtConfirmNewPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.txtCurrentPassword);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(246, 192);
            this.MinimumSize = new System.Drawing.Size(246, 192);
            this.Name = "frmChangePass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private wmgCMS.WaterMarkTextBox txtCurrentPassword;
        private wmgCMS.WaterMarkTextBox txtNewPassword;
        private wmgCMS.WaterMarkTextBox txtConfirmNewPassword;
        private System.Windows.Forms.Button btnChangePassword;
    }
}