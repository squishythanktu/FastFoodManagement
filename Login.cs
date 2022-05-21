using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastFoodManagement
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            if (Properties.Settings.Default.username != string.Empty)
            {
                txtUsername.Text = Properties.Settings.Default.username;
                txtPassword.Text = Properties.Settings.Default.password;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.Show();
            this.Hide();
            order.Dangxuat += Order_Dangxuat;
          
        }
        private void btnEsc_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Order_Dangxuat(object sender, EventArgs e)
        {
            (sender as Order).isThoat = false;
            (sender as Order).Close();
            this.Show();
        }

        private void ckbShowHide_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbShowHide.Checked)
            {
                txtPassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ckbRememberMe_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbRememberMe.Checked)
            {
                Properties.Settings.Default.username = txtUsername.Text;
                Properties.Settings.Default.password = txtPassword.Text;
                Properties.Settings.Default.Save();
            }
        }
    }
}
