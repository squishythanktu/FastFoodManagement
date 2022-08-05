using FastFoodManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodManagement.BLL
{
    public class DanhMucBLL
    {
        demoPBL3 db = new demoPBL3();
        private static DanhMucBLL _Instance;
        public static DanhMucBLL Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new DanhMucBLL();
                return _Instance;
            }
            private set {}
        }

        public List<DanhMucDTO> GetAllDanhMuc()
        {
            return db.DanhMucs.Where(p => p.IsDelete == false).Select(p => new DanhMucDTO()
            {
                MaDM = p.MaDM,
                TenDM = p.TenDM,
            }).ToList();
        }

        public void AddDanhMuc(string nameDanhMuc)
        {
            DanhMuc danhMuc = new DanhMuc();
            danhMuc.TenDM = nameDanhMuc;
            danhMuc.IsDelete = false;
            db.DanhMucs.Add(danhMuc);
            db.SaveChanges();
        }

        public void UpdateDanhMuc(DanhMuc dm)
        {
            var dmChange = db.DanhMucs.Where(p => p.MaDM == dm.MaDM).FirstOrDefault();
            dmChange.TenDM = dm.TenDM;
            db.SaveChanges();
        }

        public void DeleteDanhMuc(int idCategory)
        {
            var deleteCategory = db.DanhMucs.Find(idCategory);
            if (deleteCategory != null)
            {
                deleteCategory.IsDelete = true;
                db.SaveChanges();
            }
        }
        public List<DanhMucDTO> SearchDanhMuc(string textSearch)
        {
            return db.DanhMucs.Where(p => p.IsDelete == false && p.TenDM.Contains(textSearch))
                .Select(p => new DanhMucDTO()
                {
                    MaDM = p.MaDM,
                    TenDM = p.TenDM,
                }).ToList();
        }
    }
}
