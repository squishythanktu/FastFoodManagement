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
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.Show();
            this.Hide();
            order.Dangxuat += order_Dangxuat;
          
        }
        private void btnEsc_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void order_Dangxuat(object sender, EventArgs e)
        {
            (sender as Order).isThoat = false;
            (sender as Order).Close();
            this.Show();
        }

      

        
    }
}
