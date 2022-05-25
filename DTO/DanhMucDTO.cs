using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodManagement.DTO
{
    public class DanhMucDTO
    {
        private int _MaDM;
        private string _TenDM;
        public int MaDM { get => _MaDM; set => _MaDM = value; }
        public string TenDM { get => _TenDM; set => _TenDM = value; }
        public override string ToString()
        {
            return _TenDM;
        }
    }
}
