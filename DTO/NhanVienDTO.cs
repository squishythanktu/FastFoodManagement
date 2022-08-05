using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodManagement
{
    public class NhanVienDTO
    {
        private string _MaNV;
        private string _MatKhau;
        private string _Ten;
        private string _Tuoi;
        private string _DiaChi;
        private string _SDT;

        [DisplayName("Mã nhân viên")]
        public string MaNV { get => _MaNV; set => _MaNV = value; }
        [DisplayName("Mật khẩu")]
        public string MatKhau { get => _MatKhau; set => _MatKhau = value; }
        [DisplayName("Tên nhân viên")]
        public string Ten { get => _Ten; set => _Ten = value; }
        [DisplayName("Tuổi ")]
        public string Tuoi { get => _Tuoi; set => _Tuoi = value; }

        [DisplayName("Địa chỉ")]
        public string DiaChi { get => _DiaChi; set => _DiaChi = value; }
        [DisplayName("Số điện thoại")]
        public string SDT { get => _SDT; set => _SDT = value; }
    }
}
