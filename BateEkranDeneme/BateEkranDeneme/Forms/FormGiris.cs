using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BateEkranDeneme.Forms
{
    public partial class FormGiris : Form
    {
        private string dataBase = "Dinamik";
        private string userName = "alican";
        private string password = "123";
       

        public FormGiris()
        {
            InitializeComponent();
            Init_Data();
        }

        #region RememberMe

        private void Init_Data() 
        {
            if (Properties.Settings.Default.UserName != string.Empty) 
            {
                if (Properties.Settings.Default.Remember == true)
                {
                    userNameTxt.Text = Properties.Settings.Default.UserName;
                    passwordTxt.Text = Properties.Settings.Default.Password;
                    comboDataBase.Text = Properties.Settings.Default.Veritabani;
                    chkbxRememberMe.Checked = true;
                }
                else 
                {
                    userNameTxt.Text = Properties.Settings.Default.UserName;

                }
            }
        }

        private void Save_Data() 
        {
            if (chkbxRememberMe.Checked)
            {
                Properties.Settings.Default.UserName = userNameTxt.Text;
                Properties.Settings.Default.Password = passwordTxt.Text;
                Properties.Settings.Default.Veritabani = comboDataBase.Text;
                Properties.Settings.Default.Remember = true;
                Properties.Settings.Default.Save();
            }
            else 
            {
                Properties.Settings.Default.UserName = "";
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.Veritabani = "";
                Properties.Settings.Default.Remember = false;
                Properties.Settings.Default.Save();
            }
        }

        #endregion

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string dataBaseClick = comboDataBase.Text;
            string userNameText = userNameTxt.Text;
            string passwordText = passwordTxt.Text;
            if (dataBaseClick == dataBase && userNameText == userName && passwordText == password)
            {
                Save_Data();
                FormAnaEkran formAnaEkran = new FormAnaEkran(userNameText);
                formAnaEkran.Show();
                this.Hide();
            }
            else 
            {
                MessageBox.Show("Girdiğiniz Bilgiler Hatalı!", "Uyarı",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

 
    

       

        /*
         if (e.KeyCode == Keys.Enter)
            {
                simpleButton1_Click(this, new EventArgs());
            }*/

    }
}
