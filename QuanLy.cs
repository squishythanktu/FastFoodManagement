using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodManagement
{
    public class QuanLy
    {
        private string _MaQL;
        private string _MatKhau;
        private string _Ten;
        private string _Tuoi;
        private string _DiaChi;
        private string _SDT;

        public string MaQL { get => _MaQL; set => _MaQL = value; }
        public string MatKhau { get => _MatKhau; set => _MatKhau = value; }
        public string Ten { get => _Ten; set => _Ten = value; }
        public string Tuoi { get => _Tuoi; set => _Tuoi = value; }
        public string DiaChi { get => _DiaChi; set => _DiaChi = value; }
        public string SDT { get => _SDT; set => _SDT = value; }
    }
}
