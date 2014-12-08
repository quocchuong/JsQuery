using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JMinerData;
using johnLib;

namespace SQLMiner
{
    public partial class login : Form
    {
        userObj newuser;

        public login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string encryptedPassword = SecurityUtils.Encrypt(SecurityUtils.RemoveSQLInjection(txtPassword.Text));

                newuser = new userObj(SecurityUtils.RemoveSQLInjection(txtUsername.Text), encryptedPassword);

                //if username = "" --> invalid password
                if (newuser.UserID != null)
                {
                    //open the Owner panel
                    frmMain newPanel = new frmMain(newuser.UserID, this);
                    newPanel.Show();

                    //hide this login panel
                    this.Hide();

                    //clear text
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                }
                else
                {
                    //message box say username and password invalid
                    MessageBox.Show("Oops! Your Username or Password is Invalid. Please Try Again!", "Invalid Login");
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                string mess = ex.Message;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                //open create new account form            
                frmNewAccount newPanel = new frmNewAccount(this);
                newPanel.Show();

                //hide this login panel
                this.Hide();

                //clear text
                txtUsername.Text = "";
                txtPassword.Text = "";
            }
            catch(Exception ex)
            {
                string mess = ex.Message;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnLogin_Click(this, EventArgs.Empty);
            }
        }
    }
}
