using FastFoodManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodManagement.BLL
{
    internal class HoaDonBLL
    {
        demoPBL3 db = new demoPBL3();
        private static HoaDonBLL _Instance;
        public static HoaDonBLL Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new HoaDonBLL();
                return _Instance;
            }
            private set { }
        }

        public List<HoaDonDTO> GetAllHoaDon()
        {
            List<HoaDonDTO> hoaDons = new List<HoaDonDTO>();
            foreach (var hoaDon in db.HoaDons)
            {
                hoaDons.Add(new HoaDonDTO().Clone(hoaDon));
            }

            return hoaDons;
        }

        public List<HoaDonChiTietDTO> GetHDCTTheoMaHD(int maHD)
        {
            return db.HoaDonChiTiets.Where(p => p.MaHD == maHD).AsEnumerable().Select((p, i) => new HoaDonChiTietDTO()
            {
                TenSP = p.SanPham.TenSP,
                DonGia = p.GiaTien,
                ThanhTien = p.GiaTien*p.SoLuong,
                SL = p.SoLuong,
            }).ToList();
        }
        public HoaDon GetHDByMaHD(int maHD)
        {
            return db.HoaDons.Where(p => p.MaHD == maHD).FirstOrDefault();
        }

        public List<HoaDonDTO> GetFromDateToDate(DateTime dateFrom, DateTime dateTo)
        {
            List<HoaDonDTO> result = new List<HoaDonDTO>();
            foreach (var hoaDon in db.HoaDons)
            {
                if (dateFrom.Date <= hoaDon.ThoiGianVao.Date && hoaDon.ThoiGianVao.Date <= dateTo.Date)
                {
                    var day = hoaDon.ThoiGianVao;
                    result.Add(new HoaDonDTO()
                    {
                        MaHD = hoaDon.MaHD,
                        ThoiGianVao = day.Day.ToString() + "/" + day.Month.ToString() + "/" + day.Year.ToString(),
                        TongTien = hoaDon.TongTien,
                        TenBan = hoaDon.Ban.TenBan,
                        TenNV = hoaDon.NhanVien.TenNV,
                    });
                }
            }
            return result;
        }

        public List<DoanhThuDTO> GetDoanhThuFromDateToDate(DateTime dateFrom, DateTime dateTo)
        {
            List<DoanhThuDTO> result = new List<DoanhThuDTO>();
            foreach (var hoaDon in db.HoaDons)
            {
                if (dateFrom.Date <= hoaDon.ThoiGianVao.Date && hoaDon.ThoiGianVao.Date <= dateTo.Date)
                {
                    var day = hoaDon.ThoiGianVao;
                    result.Add(new DoanhThuDTO()
                    {

                        DateFrom = day.Day.ToString() + "/" + day.Month.ToString(),
                        TongTien = hoaDon.TongTien
                    });
                }
            }
            return result;
        }
    }
}
