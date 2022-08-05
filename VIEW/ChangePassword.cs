using FastFoodManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastFoodManagement.VIEW
{
    public partial class ChangePassword : Form
    {
        NhanVien nv = new NhanVien();
        demoPBL3 db = new demoPBL3();
        public delegate void MyDel(bool check);
        public MyDel d { get; set; }
        public ChangePassword(NhanVien nv = null)
        {
            InitializeComponent();
            this.nv = nv;
            if (nv != null)
                LoadAllCommponent();
        }
        private void LoadAllCommponent()
        {
            Account AccNV = db.Accounts.Where(p => p.MaAcc == nv.MaNV).FirstOrDefault();
            txtUsername.Text = AccNV.Username;
            txtUsername.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnEsc_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //username is identify
            Account AccNV = db.Accounts.Where(p => p.Username == txtUsername.Text).FirstOrDefault();
            if (AccNV != null)
            {
                if (txtCurrentPassword.Text == AccNV.PassWord
                    && txtNewPassword.Text == txtConfirmNewPass.Text
                    && txtNewPassword.Text != txtCurrentPassword.Text)
                {
                    AccNV.PassWord = txtNewPassword.Text;
                    db.SaveChanges();
                    MessageBox.Show("Change password sucsessfully! Please log in again",
                                    "Change password sucsessfully!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    this.Dispose();
                    d(true);
                }
                else
                {
                    if (txtCurrentPassword.Text != AccNV.PassWord)
                    {
                        MessageBox.Show("Current password is incorrect! Please check the information again",
                                    "Current password is incorrect!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                        return;
                    }
                    if (txtNewPassword.Text != txtConfirmNewPass.Text)
                    {
                        errorProvider1.BlinkRate = 500;
                        errorProvider1.SetError(txtConfirmNewPass, "Not match!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Account does not exist! Please check the information again",
                                    "Account does not exist!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                return;
            }
        }

        private void txtConfirmNewPass_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }
    }
}
