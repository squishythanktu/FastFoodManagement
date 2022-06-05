﻿using FastFoodManagement.DTO;
using FastFoodManagement.VIEW;
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
        demoPBL3 db = new demoPBL3();

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
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            if (username == "" && password == "")
            {
                MessageBox.Show("Bạn chưa nhập thông tin đăng nhập!",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            else
            {
                Account temp = db.Accounts.Where(x => x.Username == username && x.PassWord == password).FirstOrDefault();
                if (temp != null)
                {
                    NhanVien nv = db.NhanViens.Where(p => p.MaAcc == temp.MaAcc).FirstOrDefault();
                    Order ord = new Order(nv);
                    ord.Show();
                    this.Hide();
                    ord.Dangxuat += Order_Dangxuat;
                }
                else
                {
                    txtPassword.Text = "";
                    MessageBox.Show("Thông tin đăng nhập không hợp lệ!",
                                    "Warning",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }
            }
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

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
        private void lklbChangePass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePassword passwordform = new ChangePassword();
            passwordform.Show();
            passwordform.d = new ChangePassword.MyDel(isChange);
        }
        public void isChange(bool check)
        {

        }
    }
}
