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
            List<DanhMucDTO> danhMucs = new List<DanhMucDTO>();
            foreach (DanhMuc dm in db.DanhMucs.ToList<DTO.DanhMuc>())
            {
                DanhMucDTO danhMuc = new DanhMucDTO();
                danhMuc.MaDM = dm.MaDM;
                danhMuc.TenDM = dm.TenDM;
                danhMucs.Add(danhMuc);
            }
            return danhMucs;
        }

        public void AddDanhMuc(string nameDanhMuc)
        {
            DanhMuc danhMuc = new DanhMuc();
            danhMuc.TenDM = nameDanhMuc;
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
                db.DanhMucs.Remove(deleteCategory);
                db.SaveChanges();
            }
        }
        public List<DanhMucDTO> SearchDanhMuc(string textSearch)
        {
            List<DanhMucDTO> danhMucDTOs = new List<DanhMucDTO>();
            foreach (DanhMuc i in db.DanhMucs.Where(p => SqlFunctions.PatIndex("%" + textSearch + "%", p.TenDM) > 0))
            {
                DanhMucDTO danhMucDTO = new DanhMucDTO();
                danhMucDTO.MaDM = i.MaDM;
                danhMucDTO.TenDM = i.TenDM;
                danhMucDTOs.Add(danhMucDTO);
            }
            return danhMucDTOs;
        }
    }
}
