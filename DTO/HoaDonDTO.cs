using FastFoodManagement.BLL;
using FastFoodManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodManagement
{
    public class HoaDonDTO
    {

        [DisplayName("Mã hóa đơn")]
        public int MaHD { get; set; }
        [DisplayName("Tên nhân viên")]
        public string TenNV { get; set; }
        [DisplayName("Thời gian vào")]
        public string ThoiGianVao { get; set; }
        [DisplayName("Tổng tiền")]
        public int TongTien { get; set; }
        [DisplayName("Tên Bàn")]
        public string TenBan { get; set; }

        public HoaDonDTO Clone(HoaDon hoaDon)
        {
            return new HoaDonDTO()
            {
                MaHD = hoaDon.MaHD,
                TenNV = hoaDon.NhanVien.TenNV,
                ThoiGianVao = hoaDon.ThoiGianVao.ToString(),
                TongTien = hoaDon.TongTien,
                TenBan = hoaDon.Ban.TenBan,
            };
        }

        
    }
}
