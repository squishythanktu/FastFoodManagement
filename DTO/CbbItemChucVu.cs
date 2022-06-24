using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodManagement.DTO
{
    internal class CbbItemChucVu
    {
        public int MaCV { get; set; }
        public string TenCV { get; set; }
        public override string ToString()
        {
            return TenCV;
        }
    }
}
