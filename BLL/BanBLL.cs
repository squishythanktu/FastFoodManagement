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
            //List<BanDTO> list = new List<BanDTO>();
            //foreach (Ban ban in db.Bans)
            //{
            //    BanDTO temp = new BanDTO();
            //    temp.MaBan = ban.MaBan;
            //    temp.TenBan = ban.TenBan;
            //    temp.TrangThai = ban.TrangThai;
            //    list.Add(temp);
            //}
            return db.Bans.Select(p => new BanDTO()
            {
                MaBan = p.MaBan,
                TenBan = p.TenBan,
                TrangThai = p.TrangThai,
            }).ToList();
            //return list;
        }
        public void AddBan(string nameBan)
        {
            Ban temp = new Ban();
            temp.TenBan = nameBan;
            temp.TrangThai = false;
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
            //foreach (int i in idBan)
            //{
                var tempBan = db.Bans.Where(p => p.MaBan == idBan).FirstOrDefault();
                if (tempBan != null)
                {
                    db.Bans.Remove(tempBan);
                    db.SaveChanges();
                }
            //}
        }
        public List<BanDTO> SearchBan(string textSearch)
        {
            List<BanDTO> banDTOs = new List<BanDTO>();
            foreach (Ban i in db.Bans.Where(p => SqlFunctions.PatIndex("%" + textSearch + "%", p.TenBan) > 0))
            {
                BanDTO temp = new BanDTO();
                temp.MaBan = i.MaBan;
                temp.TenBan = i.TenBan;
                temp.TrangThai = i.TrangThai;
                banDTOs.Add(temp);
            }
            return banDTOs;
        }

        public List<CBBItemBan> GetAllCBBItemBan()
        {
            List<CBBItemBan> bans = new List<CBBItemBan>();
            foreach (Ban ban in db.Bans)
            {
                CBBItemBan cBBItemBan = new CBBItemBan();
                cBBItemBan.Value = ban.MaBan;
                cBBItemBan.Text = ban.TenBan;
                bans.Add(cBBItemBan);
            }
            return bans;
        }
    }
}
