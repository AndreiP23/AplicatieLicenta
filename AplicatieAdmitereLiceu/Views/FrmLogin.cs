using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using LicentaNou2.Util;
using LicentaNou2.Views.Interfaces;
using pocketbase.net;

    
namespace LicentaNou2.Views
{
    public partial class FrmLogin : BaseView, ILoginView
    {
        public bool Authorized { get; set; } = false;
        public Guna2TextBox TxtUsername { get => txtUsername; set => txtUsername = value; }
        public Guna2TextBox TxtPassword { get => txtPassword; set => txtPassword = value; }
        public Pocketbase _poketbase { get; set; }
        public FrmLogin()
        {
            InitializeComponent();
            _poketbase = new Pocketbase("http://127.0.0.1:8090");
        }

        private async void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                var userName = txtUsername.Text.Trim();
                var passworrd = txtPassword.Text.Trim();
                var Records = await _poketbase.Collections("users").GetFullList();
                var test = await _poketbase.Collections("users").AuthWithPassword(userName, passworrd);

                if (test != null && Records.Contains($"\"username\":\"{userName}\""))
                {
                    Authorized = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("Va rugam sa introduceti un utilizator valid", "Info");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("A aparut o eroare in validarea credentialelor. Va rugam, reincercati si validati selectia.", "Eroare");
            }
        }
    }
}
