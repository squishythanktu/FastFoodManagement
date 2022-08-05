
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
            private set { }
        }

        public List<SanPhamDTO> GetAllSanPham()
        {
            return db.SanPhams.Where(p => p.IsDelete == false).Select(p => new SanPhamDTO()
            { MaSP = p.MaSP, TenSP = p.TenSP, Gia = p.GiaSP, TenDM = p.DanhMuc.TenDM }).ToList();
            
        }

        public void AddSanPham(SanPham sanPham)
        {
            sanPham.IsDelete = false;
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
                deleteFood.IsDelete = true;
                db.SaveChanges();
            }
        }
        public List<SanPhamDTO> SearchSanPham(string textSearch)
        {
            return db.SanPhams.Where(p => p.IsDelete == false && p.TenSP.Contains(textSearch)).Select(p => new SanPhamDTO()
            {
                MaSP = p.MaSP,
                TenSP = p.TenSP,
                Gia = p.GiaSP,
                TenDM = p.DanhMuc.TenDM,
            }).ToList();
        }
        
    }
}
