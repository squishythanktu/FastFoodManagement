using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodManagement.DTO
{
    public class BanDTO
    {
        private int _MaBan;
        private string _TenBan;
        private bool _TrangThai;
        [DisplayName("Mã bàn")]
        public int MaBan { get => _MaBan; set => _MaBan = value; }
        [DisplayName("Tên bàn")]
        public string TenBan { get => _TenBan; set => _TenBan = value; }
        [DisplayName("Trạng thái")]
        public bool TrangThai { get => _TrangThai; set => _TrangThai = value; }
    }
}
