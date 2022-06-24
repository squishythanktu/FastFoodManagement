using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodManagement.DTO
{
    internal class AccountDTO
    {
        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string ChucVu { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public AccountDTO Clone(NhanVien nv)
        {
            return new AccountDTO()
            {
                MaNV = nv.MaNV,
                TenNV = nv.TenNV,
                DiaChi = nv.DiaChi,
                SDT = nv.SDT,
                ChucVu = nv.ChucVu == 0 ? "Quản lý" : "Nhân viên",
                Username = nv.Account.Username,
                Password = nv.Account.PassWord,
            };
        }
    }
}
