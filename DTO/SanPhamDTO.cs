using System;
using System.Collections.Generic;
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

        public int MaSP { get => _MaSP; set => _MaSP = value; }
        public string TenSP { get => _TenSP; set => _TenSP = value; }
        public double Gia { get => _Gia; set => _Gia = value; }
        public string TenDM { get => _TenDM; set => _TenDM = value; }
    }
}
