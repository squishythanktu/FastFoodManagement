using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodManagement.DTO
{
    public class DanhMucDTO
    {
        private int _MaDM;
        private string _TenDM;
        [DisplayName("Mã danh mục")]
        public int MaDM { get => _MaDM; set => _MaDM = value; }
        [DisplayName("Tên danh mục")]
        public string TenDM { get => _TenDM; set => _TenDM = value; }
        public override string ToString()
        {
            return _TenDM;
        }
    }
}
