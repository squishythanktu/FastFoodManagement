using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodManagement.DTO
{
    public class HoaDonChiTietDTO
    {
        public int MaHDCT { get; set; }
        public int MaSP { get; set; }
        [DisplayName("Tên sản phẩm")]
        public string TenSP { get; set; }
        public int SL { get; set; }
        [DisplayName("Đơn giá")]
        public int DonGia { get; set; }
        [DisplayName("Thành tiền")]
        public int ThanhTien { get; set; }
    }
}
