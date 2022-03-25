using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodManagement
{
    public class HoaDon
    {
        private string _MaHD;
        private string _MaNV;
        private DateTime _ThoiGianVao;
        private DateTime _ThoiGianRa;
        private int _TongTien;
        private int _MaBan;

        public string MaHD { get => _MaHD; set => _MaHD = value; }
        public string MaNV { get => _MaNV; set => _MaNV = value; }
        public DateTime ThoiGianVao { get => _ThoiGianVao; set => _ThoiGianVao = value; }
        public DateTime ThoiGianRa { get => _ThoiGianRa; set => _ThoiGianRa = value; }
        public int TongTien { get => _TongTien; set => _TongTien = value; }
        public int MaBan { get => _MaBan; set => _MaBan = value; }
    }
}
