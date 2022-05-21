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
    public partial class Order : Form
    {
        public bool isThoat = true;
        public Order()
        {
            InitializeComponent();
           
        }
        public event EventHandler Dangxuat;

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (isThoat)
            {
                if (MessageBox.Show("Ban co muon thoat khong?", "Thoat chuong trinh", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    Application.Exit();
                else return;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Dangxuat(this, new EventArgs());
        }
        private void btnHome_Click_1(object sender, EventArgs e)
        {
            panelHome.Visible = true;
            panelOrder.Visible = false;
            panelFood.Visible = false;
            panelCategory.Visible = false;
            panelTable.Visible = false;
            panelAccout.Visible = false;
        }


        private void btnOrder_Click_1(object sender, EventArgs e)
        {
            panelOrder.Visible = true;
            panelHome.Visible=false;
            panelFood.Visible = false;
            panelCategory.Visible = false;
            panelTable.Visible = false;
            panelAccout.Visible = false;
        }

        private void btnFood_Click_1(object sender, EventArgs e)
        {
            panelFood.Visible =true;
            panelHome.Visible = false;
            panelOrder.Visible = false;
            panelCategory.Visible=false;
            panelTable.Visible=false;
            panelAccout.Visible = false;
        }
        private void btnDanhmuc_Click(object sender, EventArgs e)
        {
            panelCategory.Visible = true;
            panelHome.Visible = false;
            panelOrder.Visible = false;
            panelFood.Visible = false;
            panelTable.Visible = false;
            panelAccout.Visible = false;
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            panelTable.Visible = true;
            panelHome.Visible = false;
            panelOrder.Visible = false;
            panelFood.Visible = false;
            panelCategory.Visible = false;
            panelAccout.Visible = false;
        }

        private void btnAccout_Click(object sender, EventArgs e)
        {
            panelAccout.Visible = true;
            panelHome.Visible = false;
            panelOrder.Visible = false;
            panelFood.Visible = false;
            panelCategory.Visible = false;
            panelTable.Visible = false;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        
    }
}
