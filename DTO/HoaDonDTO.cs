using FastFoodManagement.BLL;
using FastFoodManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodManagement
{
    public class HoaDonDTO
    {

        public int MaHD { get; set; }
        public string TenNV { get; set; }
        public string ThoiGianVao { get; set; }
        public int TongTien { get; set; }
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
