using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using johnLib;
using JMinerData;

namespace SQLMiner
{
    public partial class frmNewAccount : Form
    {
        login LoginForm;

        public frmNewAccount(login loginForm)
        {
            InitializeComponent();            
            LoginForm = loginForm;
        }

        private void frmNewAccount_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //reset user and id and close this window
            txtYourName.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";            

            //hide the control panel and show login form
            this.Hide();
            LoginForm.Show();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            //check this user and username and password
            if (txtYourName.Text == "" || txtUsername.Text == "" || txtPassword.Text == "" || txtConfirmPassword.Text == "")
            {
                MessageBox.Show("Please fill in all details");
            }
            else
            { 
                //check user in system, if exist then show message
                userObj newUser = new userObj();
                DataTable foundUser = newUser.searchUser("", "", SecurityUtils.RemoveSQLInjection(txtUsername.Text), "", "", "");

                if (foundUser.Rows.Count > 0)
                {
                    MessageBox.Show("This Username exists in the system already, please choose other username!");

                    txtUsername.Text = "";
                    txtUsername.Focus();
                }
                else
                {
                    if (txtPassword.Text != txtConfirmPassword.Text)
                    {
                        MessageBox.Show("Your Confirm Password is not the same with your Password!");

                        txtPassword.Text = "";
                        txtConfirmPassword.Text = "";

                        txtPassword.Focus();
                    }
                    else
                    { 
                        //insert new user
                        string toInsertUsername = SecurityUtils.RemoveSQLInjection(txtUsername.Text);
                        string toInsertPassword = SecurityUtils.Encrypt(SecurityUtils.RemoveSQLInjection(txtPassword.Text));
                        string toInsertName = SecurityUtils.RemoveSQLInjection(txtYourName.Text);
                        bool insertGood = newUser.insert(toInsertUsername, toInsertPassword, "", "", toInsertName);

                        //confirm
                        if (insertGood)
                        {
                            MessageBox.Show("Your account has been created! Click OK to return to Login Box.");

                            //reset user and id and close this window
                            txtYourName.Text = "";
                            txtUsername.Text = "";
                            txtPassword.Text = "";
                            txtConfirmPassword.Text = "";

                            //hide the control panel and show login form
                            this.Hide();
                            LoginForm.Show();
                        }
                    }                   
                }
            }
        }
    }
}
