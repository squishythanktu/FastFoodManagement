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
        public Order()
        {
            InitializeComponent();
            home1.BringToFront();
        }

        private void btnEsc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            home1.BringToFront();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            order_user1.BringToFront();
        }

        
    }
}
