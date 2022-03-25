using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodManagement
{
    public class FastFood
    {
        private string _MaSP;
        private string _TenSP;
        private int _Gia;
        private bool _TrangThai;
        private string _DM;

        public string MaSP { get => _MaSP; set => _MaSP = value; }
        public string TenSP { get => _TenSP; set => _TenSP = value; }
        public int Gia { get => _Gia; set => _Gia = value; }
        public bool TrangThai { get => _TrangThai; set => _TrangThai = value; }
        public string DM { get => _DM; set => _DM = value; }

        public override string ToString()
        {
            return $"{MaSP, -10}{TenSP, -10}{Gia, -10}{TrangThai, -10}{DM, -10}";
        }

    }
}
