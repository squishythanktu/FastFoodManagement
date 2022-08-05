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


        public int DemBan()
        {
            return db.Bans.Where(p=>p.IsDelete == false).Count();
        }

        public string[] getAllTableName()
        {
            return db.Bans.Where(p => p.IsDelete == false).Select(p => p.TenBan).ToArray();
        }

        public bool CheckTrangThaiBan(string tenban)
        {
            foreach (Ban item in db.Bans)
            {
                if (item.TenBan == tenban && item.TrangThai == true)
                {
                    return true;
                }
            }
            return false;
        }

        public List<BanDTO> GetAllTable()
        {
            return db.Bans.Where(p => p.IsDelete == false)
                .Select(p => new BanDTO()
                {
                    TenBan = p.TenBan,
                    MaBan = p.MaBan,
                    TrangThai = p.TrangThai,
                }).ToList();
        }

        public void AddHoaDon(int idBan, int maNv)
        {
            db.HoaDons.Add(new HoaDon
            {
                ThoiGianVao = DateTime.Now,
                MaBan = idBan,
                MaNV = maNv,
                IsPaid = false,
                
            });
            SetTrangThaiBan(idBan, true);
            db.SaveChanges();
        }

        public int FindIdHoaDonOfBan(int idBan)
        {
            if (db.HoaDons.Any())
            {
                var idHoaDon = db.HoaDons.FirstOrDefault(x => x.MaBan == idBan && x.IsPaid == false);
                
                if(idHoaDon == null) return -1;
                return idHoaDon.MaHD;
            }
            return -1;
        }

        public void AddHoaDonChiTiet(HoaDonChiTiet hoaDonChiTiet)
        {
            var sanPhamTangSoLuong = db.HoaDonChiTiets.FirstOrDefault(x => x.MaSP == hoaDonChiTiet.MaSP && hoaDonChiTiet.MaHD == x.MaHD);
            if (sanPhamTangSoLuong != null)
            {
                sanPhamTangSoLuong.SoLuong += hoaDonChiTiet.SoLuong;
                db.SaveChanges();
                return;
            }
            if (db.HoaDons.FirstOrDefault(x => x.MaHD == hoaDonChiTiet.MaHD) != null || !(db.HoaDons.FirstOrDefault(x => x.MaHD == hoaDonChiTiet.MaHD).IsPaid))
            {
                db.HoaDonChiTiets.Add(hoaDonChiTiet);
                db.SaveChanges();
            }
        }

        public List<HoaDonChiTietDTO> GetAllHDCTByIdHoaDon(int idHoaDon)
        {
            return db.HoaDonChiTiets.Where(p => p.MaHD == idHoaDon && p.HoaDon.IsPaid == false).Select(p => new HoaDonChiTietDTO
            {
                TenSP = p.SanPham.TenSP,
                SL = p.SoLuong,
                DonGia = p.GiaTien,
                ThanhTien = p.SoLuong * p.GiaTien,
                MaHDCT = p.MaHDCT,
                MaSP = p.MaSP
            }).ToList();
        }

        public bool CheckTrangThaiBanWithHoaDon(int idBan)
        {
            var hoaDonWithIdBan = db.HoaDons.FirstOrDefault(x => x.MaBan == idBan);
            if(hoaDonWithIdBan == null) return true;
            if (db.HoaDons.FirstOrDefault(x => x.IsPaid == false && x.MaBan == idBan) != null) return false;
            return true;
        }

        public void ThanhToanHoaDon(int idHoaDonOfBan, int tongTien)
        {
            var hoaDon = db.HoaDons.FirstOrDefault(x => x.MaHD == idHoaDonOfBan);
            hoaDon.IsPaid = true;
            hoaDon.TongTien = tongTien;
            db.SaveChanges();
        }

        public void SetTrangThaiBan(int idBan, bool trangThai)
        {
            db.Bans.FirstOrDefault(ban => ban.MaBan == idBan).TrangThai = trangThai;
            db.SaveChanges();
        }

        public void DeleteHoaDonChiTiet(int idBan)
        {
            var deleteHDCT = db.HoaDonChiTiets.Where(hdct => hdct.HoaDon.MaBan == idBan && hdct.HoaDon.IsPaid == false).ToList();
            db.HoaDonChiTiets.RemoveRange(deleteHDCT.ToArray());
            DeleteHoaDon(idBan);
            db.SaveChanges();
            
        }

        public void DeleteHoaDon(int idBan)
        {
            var listHoaDon = db.HoaDons.Where(hd => hd.MaBan == idBan && hd.IsPaid == false).ToList();
            db.HoaDons.RemoveRange(listHoaDon.ToArray());
        }

        public void ChuyenBan(int idHoaDon, int idBanDaChuyen, int idBanChuaChuyen)
        {
            db.HoaDons.FirstOrDefault(hoadon => hoadon.MaHD == idHoaDon).MaBan = idBanDaChuyen;
            db.Bans.FirstOrDefault(ban => ban.MaBan == idBanDaChuyen).TrangThai = true;
            db.Bans.FirstOrDefault(ban => ban.MaBan == idBanChuaChuyen).TrangThai = false;
            db.SaveChanges();
        }

        public void DeleteOneHoaDonChiTiet(int idHDCT)
        {
            var deleteHDCT = db.HoaDonChiTiets.FirstOrDefault(p => p.MaHDCT == idHDCT);
            db.HoaDonChiTiets.Remove(deleteHDCT);
            db.SaveChanges();
        }
    }
}
