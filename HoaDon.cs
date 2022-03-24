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

        public string MaHD { get ; set; }
        public string MaNV { get ; set; }
        public DateTime ThoiGianVao { get; set; }
        public DateTime ThoiGianRa { get; set; }
        public int TongTien { get; set; }
        public int MaBan { get; set; }
    }
}
