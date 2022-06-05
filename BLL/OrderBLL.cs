using FastFoodManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastFoodManagement.BLL
{
    public class OrderBLL
    {
        demoPBL3 db = new demoPBL3();
        private static OrderBLL _Instance;
        public static OrderBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new OrderBLL();
                }
                return _Instance;
            }
            private set { }
        }
        

        public int demban()
        {
            return db.Bans.Count();
        }

        public string[] getMangGomCacTenBan()
        {
            string[] result = new string[db.Bans.Count()];
            int i = 0;
            foreach (Ban item in db.Bans)
            {
                result[i] = item.TenBan;
                i++;
            }
            return result;
        }

        public bool checktrangthaiban(string tenban)
        {
            foreach(Ban item in db.Bans)
            {
                if(item.TenBan == tenban && item.TrangThai == true)
                {
                    return true;
                }
                    
            }
            return false;

        }
    }
   
}
