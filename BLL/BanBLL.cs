using FastFoodManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodManagement.BLL
{
    public class BanBLL
    {
        demoPBL3 db = new demoPBL3();
        private static BanBLL _Instance;
        public static BanBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BanBLL();
                }
                return _Instance;
            }
            private set { }
        }
        public List<BanDTO> GetAllBan()
        {
            return db.Bans.Where(p => p.IsDelete == false).Select(p => new BanDTO()
            {
                MaBan = p.MaBan,
                TenBan = p.TenBan,
                TrangThai = p.TrangThai,
            }).ToList();
        }
        public void AddBan(string nameBan)
        {
            Ban temp = new Ban();
            temp.TenBan = nameBan;
            temp.TrangThai = false;
            temp.IsDelete = false;
            db.Bans.Add(temp);
            db.SaveChanges();
        }
        public void UpdateBan(Ban ban)
        {
            var tempBan = db.Bans.Where(p => p.MaBan == ban.MaBan).FirstOrDefault();
            tempBan.TenBan = ban.TenBan;
            tempBan.TrangThai = ban.TrangThai;
            db.SaveChanges();
        }
        public void DeleteBan(int idBan)
        {
            var tempBan = db.Bans.Where(p => p.MaBan == idBan).FirstOrDefault();
            if (tempBan != null)
            {
                tempBan.IsDelete = true;
                db.SaveChanges();
            }
        }
        public List<BanDTO> SearchBan(string textSearch)
        {
            return db.Bans.Where(p => p.IsDelete == false && 
                                    p.TenBan.Contains(textSearch))
                          .Select(p => new BanDTO
                {
                    TenBan = p.TenBan,
                    TrangThai= p.TrangThai,
                    MaBan = p.MaBan,
                }).ToList();
        }

        public List<CBBItemBan> GetAllCBBItemBan()
        {
            return db.Bans.Where(p => p.IsDelete == false).Select(p => new CBBItemBan
            {
                Text = p.TenBan,
                Value = p.MaBan
            }).ToList();
        }
    }
}
