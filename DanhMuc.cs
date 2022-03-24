using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodManagement
{
    public class DanhMuc
    {
        private string _MaDM;
        private string _TenDM;
        private Dictionary<string, FastFood> dsSP = new Dictionary<string, FastFood>();
        public string MaDM { get; set; }
        public string TenDM { get; set; }
        public override string ToString()
        {
            return $"{MaDM, -10}{TenDM, -10}";
        }
        public void themSP(FastFood Sp)
        {
            if(dsSP.ContainsKey(Sp.MaSP) == false)
                dsSP.Add(Sp.MaSP, Sp);
            //code thêm
        }
        public Dictionary<string, FastFood> getdsSP
        {
            get { return this.dsSP; }
            set { this.dsSP = value; }
        }
    }
}
