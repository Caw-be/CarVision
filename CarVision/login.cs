﻿using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarVision
{
    public partial class login : Form
    {
        string username = "ADMIN";
        string password = "admin";

        public login()
        {
            InitializeComponent();
            passwordBx.PasswordChar = '●';
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {

            if(usernameBx.Text.ToUpper() == username && passwordBx.Text == password)
            {
                CarVision carvision = new CarVision();
                carvision.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Nesprávné údaje, zkontrolujte a zkuste znovu.");
            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
