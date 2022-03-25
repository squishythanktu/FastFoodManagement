using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodManagement
{
    public class Ban
    {
        private string _MaBan;
        private string _TenBan;
        private string _MaHD;
        private bool _TrangThai;

        public string MaBan { get => _MaBan; set => _MaBan = value; }
        public string TenBan { get => _TenBan; set => _TenBan = value; }
        public string MaHD { get => _MaHD; set => _MaHD = value; }
        public bool TrangThai { get => _TrangThai; set => _TrangThai = value; }
    }
}
