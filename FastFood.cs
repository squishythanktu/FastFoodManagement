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

        public string MaSP { get; set; }
        public string TenSP { get; set;}
        public int Gia { get; set;}
        public bool TrangThai { get; set;}
        public DanhMuc DM { get; set; }
        public override string ToString()
        {
            return $"{MaSP, -10}{TenSP, -10}{Gia, -10}{TrangThai, -10}{DM, -10}";
        }

    }
}
