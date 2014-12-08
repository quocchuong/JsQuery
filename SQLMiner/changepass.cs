using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using johnLib;
using JMinerData;

namespace SQLMiner
{
    public partial class frmChangePass : Form
    {
        string CurrentUserID;

        public frmChangePass(string userID)
        {
            InitializeComponent();
            CurrentUserID = userID;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            userObj thisUser = new userObj(CurrentUserID);

            if (txtCurrentPassword.Text == "" || txtCurrentPassword.Text == "" || txtConfirmNewPassword.Text == "")
            {
                MessageBox.Show("Please fill all fields!");
            }
            else
            {
                if (thisUser.Password != SecurityUtils.Encrypt(SecurityUtils.RemoveSQLInjection(txtCurrentPassword.Text)))
                {
                    MessageBox.Show("Incorrect Current Password");
                }
                else
                {
                    if (SecurityUtils.RemoveSQLInjection(txtNewPassword.Text) != SecurityUtils.RemoveSQLInjection(txtConfirmNewPassword.Text))
                    {
                        MessageBox.Show("New password and confirm new password are not the same");
                    }
                    else
                    { 
                        //update password
                        thisUser.Password = SecurityUtils.Encrypt(SecurityUtils.RemoveSQLInjection(txtNewPassword.Text));
                        bool updatePasswored = thisUser.update();

                        if (updatePasswored)
                        {
                            MessageBox.Show("Password updated Successfully");
                            this.Hide();
                        }
                    }
                }
            }
        }
    }
}
