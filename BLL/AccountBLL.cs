   using FastFoodManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodManagement.BLL
{
    internal class AccountBLL
    {
        private static AccountBLL _Instance;
        demoPBL3 db = new demoPBL3();
        public static AccountBLL Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new AccountBLL();
                return _Instance;
            }
            private set { }
        }

        public List<AccountDTO> GetAllAccount()
        {
            return db.NhanViens.Where(p => p.Account.IsDelete == false).Select(p => new AccountDTO()
            {
                MaNV = p.MaNV,
                TenNV = p.TenNV,
                DiaChi = p.DiaChi,
                SDT = p.SDT,
                ChucVu = p.ChucVu == 0 ? "Quản lý" : "Nhân viên",
                Username = p.Account.Username,
                Password = p.Account.PassWord,
            }).ToList();
        }

        public void AddAccount(NhanVien nv)
        {
            nv.Account.IsDelete = false;
            db.NhanViens.Add(nv);
            db.SaveChanges();
        }

        public List<CbbItemChucVu> GetAllChucVu()
        {
            List<CbbItemChucVu> data = new List<CbbItemChucVu>();
            data.AddRange(new CbbItemChucVu[]
            {
                new CbbItemChucVu { MaCV = 0, TenCV = "Quản lý"},
                new CbbItemChucVu { MaCV = 1, TenCV = "Nhân viên"}
            });
            return data;
        }

        public void UpdateAccount(NhanVien nhanVien)
        {
            var nvChange = db.NhanViens.Where(p => p.MaNV == nhanVien.MaNV).FirstOrDefault();
            nvChange.TenNV = nhanVien.TenNV;
            nvChange.DiaChi = nhanVien.DiaChi;
            nvChange.SDT = nhanVien.SDT;
            nvChange.ChucVu = nhanVien.ChucVu;
            nvChange.Account.Username = nhanVien.Account.Username;
            nvChange.Account.PassWord = nhanVien.Account.PassWord;
            db.SaveChanges();
        }

        public void DeleteAccount(int id)
        {
            var deleteNhanVien = db.NhanViens.Find(id);
            var deleteAccount = db.Accounts.Find(id);
            if (deleteNhanVien != null)
            {
                deleteAccount.IsDelete = true;
                db.SaveChanges();
            }
        }

        public List<AccountDTO> SearchAccount(string text)
        {
            return db.NhanViens.Where(p => p.TenNV.Contains(text) && 
                                        p.Account.IsDelete == false)
                                .Select(p => new AccountDTO()
            {
                MaNV = p.MaNV,
                TenNV = p.TenNV,
                DiaChi = p.DiaChi,
                SDT = p.SDT,
                ChucVu = p.ChucVu == 0 ? "Quản lý" : "Nhân viên",
                Username = p.Account.Username,
                Password = p.Account.PassWord,
            }).ToList();
        }


    }
}
