using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;

namespace WebDav
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void showPass_CheckedChanged(object sender, EventArgs e)
        {
            ShowPassword(edtPassword,!edtPassword.UseSystemPasswordChar);
        }

        private void ShowPassword(TextBox EditPass, bool value)
        {
            EditPass.UseSystemPasswordChar = value;
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            Connection(edtEmail.Text, edtPassword.Text);
        }

        private void Connection(string UserName, string Password)
        {
            DataUser User = new DataUser();
            if (User.CheckIntConnect())
            {
                ReqRes Act = new ReqRes();
                string UrlServer = "https://webdav.yandex.ru";
                HttpWebRequest Request = Act.MakeRequest(UrlServer, "", UserName, Password);
                if (Request != null)
                {
                    Request.Accept = "*/*";
                    Request.Headers.Add("Depth: 1");
                    Request.Method = "PROPFIND";
                    Act.GetResponse(Request);
                    {
                        MainForm Main = new MainForm(UrlServer, UserName, Password, this);
                        Main.Show();
                        this.Hide();
                    }
                }
            }
        }
         
        private void EditKey(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                e.KeyChar = '\0';
        }
    }
}
