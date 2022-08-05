using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodManagement
{
    public class SanPhamDTO
    {
        private int _MaSP;
        private string _TenSP;
        private double _Gia;
        private string _TenDM;
        [DisplayName("Mã sản phẩm")]
        public int MaSP { get => _MaSP; set => _MaSP = value; }
        [DisplayName("Tên sản phẩm")]

        public string TenSP { get => _TenSP; set => _TenSP = value; }
        [DisplayName("Giá tiền")]

        public double Gia { get => _Gia; set => _Gia = value; }
        [DisplayName("Tên danh mục")]

        public string TenDM { get => _TenDM; set => _TenDM = value; }
    }
}
