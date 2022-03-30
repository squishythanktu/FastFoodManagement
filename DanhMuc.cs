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


        public string MaDM { get => _MaDM; set => _MaDM = value; }
        public string TenDM { get => _TenDM; set => _TenDM = value; }
        public Dictionary<string, FastFood> DsSP { get => dsSP; set => dsSP = value; }


        public override string ToString()
        {
            return "{MaDM, -10}{TenDM, -10}";
        }
        public void themSP(FastFood Sp)
        {
            if( dsSP.ContainsKey(Sp.MaSP) == false)
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
