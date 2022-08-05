using FastFoodManagement.BLL;
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
    public partial class Bill : Form
    {
        public int maHD { get; set; }
        public Bill(int maHD)
        {
            InitializeComponent();
            this.maHD = maHD;
            LoadDgvBill(maHD);
        }

        private void LoadDgvBill(int maHD)
        {
            dgvShowBill.DataSource = HoaDonBLL.Instance.GetHDCTTheoMaHD(maHD);
            int total = 0;
            foreach(DataGridViewRow dr in dgvShowBill.Rows)
            {
                total += Convert.ToInt32(dr.Cells["ThanhTien"].Value);
            }    
            labelTotal.Text += total.ToString();
            dgvShowBill.Columns["MaHDCT"].Visible = false;
            dgvShowBill.Columns["MaSP"].Visible = false;
            var hoadon = HoaDonBLL.Instance.GetHDByMaHD(maHD);
            lbMaHD.Text += hoadon.MaHD;
            lbBan.Text += hoadon.Ban.TenBan;
            lbNgay.Text += hoadon.ThoiGianVao.ToString("MM/dd/yyyy");
            lbBanHang.Text += hoadon.NhanVien.TenNV;
            dgvShowBill.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvShowBill.DefaultCellStyle.SelectionForeColor = Color.Black;
        }
    }
}
