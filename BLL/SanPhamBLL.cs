
using FastFoodManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodManagement.BLL
{
    public class SanPhamBLL
    {
        demoPBL3 db = new demoPBL3();
        private static SanPhamBLL _Instance;
        public static SanPhamBLL Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new SanPhamBLL();
                return _Instance;
            }
            private set {}
        }

        public List<SanPhamDTO> GetAllSanPham()
        {
            //List<SanPhamDTO> sanPhams = new List<SanPhamDTO>();
            //foreach (SanPham sp in db.SanPhams)
            //{
            //    SanPhamDTO sanPham = new SanPhamDTO();
            //    sanPham.MaSP = sp.MaSP;
            //    sanPham.TenSP = sp.TenSP;
            //    sanPham.TenDM = sp.DanhMuc.TenDM;
            //    sanPham.Gia = sp.GiaSP;
            //    sanPhams.Add(sanPham);
            //}
            return db.SanPhams.Select(p => new SanPhamDTO() 
            { MaSP = p.MaSP, TenSP = p.TenSP, Gia = p.GiaSP, TenDM = p.DanhMuc.TenDM }).ToList();
            //return sanPhams;
        }

        public void AddSanPham(SanPham sanPham)
        {
            db.SanPhams.Add(sanPham);
            db.SaveChanges();
        }
        public void UpdateSanPham(SanPham sanPham)
        {
            var spChange = db.SanPhams.Where(p => p.MaSP == sanPham.MaSP).FirstOrDefault();
            spChange.TenSP = sanPham.TenSP;
            spChange.MaDM = sanPham.MaDM;
            spChange.GiaSP = sanPham.GiaSP;
            db.SaveChanges();
        }

        public void DeleteSanPham(int idFood)
        {
            var deleteFood = db.SanPhams.Find(idFood);
            if (deleteFood != null)
            {
                db.SanPhams.Remove(deleteFood);
                db.SaveChanges();
            }
        }
        public List<SanPhamDTO> SearchSanPham (string textSearch)
        {
            List<SanPhamDTO> sanPhamDTOs = new List<SanPhamDTO>();
            foreach(SanPham i in db.SanPhams.Where(p => SqlFunctions.PatIndex("%" + textSearch + "%", p.TenSP) > 0))
            {
                SanPhamDTO sanPhamDTO = new SanPhamDTO();
                sanPhamDTO.MaSP = i.MaSP;
                sanPhamDTO.TenSP = i.TenSP;
                sanPhamDTO.Gia = i.GiaSP;
                sanPhamDTO.TenDM = i.DanhMuc.TenDM;
                sanPhamDTOs.Add(sanPhamDTO);
            }    
            return sanPhamDTOs;
        }
    }
}
