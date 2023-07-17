using BaiTapLonWeb.Models;
using BaiTapLonWeb.Models.CinemaModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BaiTapLonWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhimApiController : ControllerBase
    {

        BanVeXemPhimContext db = new BanVeXemPhimContext();

        [Route("suatchieu")]
        [HttpGet]
        public List<ShowTime> GetSuatChieu(string maPhim, string ngayChieu) //, DateTime ngayChieu string maPhim
        {
            string[] nc = ngayChieu.Split("/");
            //string showDate = nc[2] + "/" + nc[1] + "/" + nc[0] + " " + "00:00:00";
            DateTime showDate = new DateTime(int.Parse(nc[2]), int.Parse(nc[0]), int.Parse(nc[1]));
            List<ShowTime> lstSuatChieu = (from x in db.SuatChieus
                                           where x.MaPhim == maPhim && x.NgayChieu.Value.Equals(showDate)
                                           select new ShowTime
                                           {
                                               maSuatChieu = x.MaSuatChieu,
                                               GioBatDau = x.GioBatDau,
                                               GioKetThuc = x.GioKetThuc,
                                               NgayChieu = x.NgayChieu,
                                               tenPhongChieu = (from y in db.PhongChieus where x.MaPhongChieu == y.MaPhongChieu select y.TenPhongChieu).First(),
                                               tenRap = (from r in db.RapChieus where r.MaRapChieu == (from p in db.PhongChieus where x.MaPhongChieu == p.MaPhongChieu select p.MaRapChieu).First() select r.TenRapChieu).First()
                                           }).ToList() as List<ShowTime>;


            //var sc = db.SuatChieus.Where(x => x.MaPhim == maPhim).ToList().Where(s => s.NgayChieu.Value.ToString("MM/dd/yyyy").Equals(ngayChieu));
            //List<SuatChieu> lstSuathieu = sc.OrderBy(x => x.NgayChieu).OrderBy(x => x.GioBatDau).ToList();
            return lstSuatChieu;
        }

        [Route("trangthaighe")]
        [HttpGet]
        public List<SeatStatus> getTrangThaiGhe(string maSuatChieu)
        {
            string maPhong = db.SuatChieus.Find(maSuatChieu).MaPhongChieu;
            var maGhes = db.Ghes.Where(x => x.MaPhongChieu == maPhong).Select(x => x.MaGhe).ToList();
            List<SeatStatus> trangThaiGhes = new List<SeatStatus>();
            foreach (var maGhe in maGhes)
            {
                SeatStatus trangThaiGhe = (from x in db.TrangThaiGhes
                                           where x.MaGhe == maGhe && x.MaSuatChieu == maSuatChieu
                                           select new SeatStatus
                                           {
                                               maGhe = x.MaGhe,
                                               maSuatChiau = x.MaSuatChieu,
                                               trangThai = (int)x.TrangThai,
                                               tenGhe = (from y in db.Ghes where y.MaGhe == maGhe select y.TenGhe).First()
                                           }).First();
                //SeatStatus trangThaiGhe = db.TrangThaiGhes.Select.Find(maGhe, maSuatChieu);
                trangThaiGhes.Add(trangThaiGhe);
            }
            return trangThaiGhes;
        }

        [Route("thongtinhoadon")]
        [HttpGet]
        public Bill thongTinHoaDon(string maSuatChieu)
        {
            var suatChieu = db.SuatChieus.Find(maSuatChieu);
            var tenPhim = db.Phims.Find(suatChieu.MaPhim).TenPhim;
            var ngayChieu = suatChieu.NgayChieu.ToString();
            var gioBatDau = suatChieu.GioBatDau.ToString();
            var gioKetThuc = suatChieu.GioKetThuc;
            var maRap = db.PhongChieus.Find(suatChieu.MaPhongChieu).MaRapChieu;
            var tenRap = db.RapChieus.Find(maRap).TenRapChieu;
            var tenPhongChieu = db.PhongChieus.Find(suatChieu.MaPhongChieu).TenPhongChieu;

            var donGiaPhim = db.Phims.Find(suatChieu.MaPhim).DonGia;
            Bill bill = new Bill();
            bill.tenPhim = tenPhim;
            bill.ngayChieu = ngayChieu;
            bill.gioBatDau = gioBatDau;
            bill.rapChieu = tenRap;
            bill.phongChieu = tenPhongChieu;
            bill.donGiaPhim = (int)donGiaPhim;
            return bill;
        }


        //[Route("phimtheotheloai")]
        //[HttpGet]
        //public List<Phim> getPhimTheoTheLoai()
        //{
        //    return db.Phims.ToList();
        //}

        [HttpPost]
        public bool themHoaDon(string maKh, string maSuatChieu, DateTime thoiGian, int soLuongVe, int tongTien)
        {
            try
            {
                DonHang donHang = new DonHang();
                donHang.MaKh = maKh;
                donHang.MaSuatChieu = maSuatChieu;
                donHang.ThoiGian = thoiGian;
                donHang.SoLuongVe = soLuongVe;
                donHang.TongTien = tongTien;
                db.DonHangs.Add(donHang);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpPut]
        public bool suaTrangThaiGhe(string maGhe, string maSuatChieu)
        {
            try
            {
                var maGhes = maGhe.Trim().Split(",");
                foreach (var item in maGhes)
                {
                    TrangThaiGhe trangThaiGhe = db.TrangThaiGhes.Find(item, maSuatChieu);
                    if (trangThaiGhe == null)
                    {
                        return false;
                    }
                    trangThaiGhe.TrangThai = 2;
                    db.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        [Route("getalltheloai")]
        [HttpGet]
        public List<TheLoai> getTheLoai()
        {
            return db.TheLoais.ToList();
        }

        [Route("getphimtheotheloai")]
        [HttpGet]
        public List<Movie> getPhimTheoTheLoai(string? maTheLoai)
        {
            var phimDangChieu = db.Phims.Where(x => x.ThoiGianKhoiChieu < DateTime.Today && x.ThoiGianKhoiChieu.Value.AddDays(10) > DateTime.Today);
            List<Movie> phims = (from p in phimDangChieu
                                 select new Movie
                                 {
                                     MaPhim = p.MaPhim,
                                     TenPhim = p.TenPhim,
                                     MoTa = p.MoTa,
                                     DaoDien = p.DaoDien,
                                     ThoiLuong = p.ThoiLuong,
                                     ThoiGianKhoiChieu = p.ThoiGianKhoiChieu,
                                     Anh = p.Anh,
                                     DonGia = p.DonGia
                                 }).ToList();
            if (maTheLoai != null)
            {
                //using (var context = new BanVeXemPhimContext())
                //{
                phims = (from p in phimDangChieu
                         where p.MaTheLoais.Any(tl => tl.MaTheLoai == maTheLoai)
                         select new Movie
                         {
                             MaPhim = p.MaPhim,
                             TenPhim = p.TenPhim,
                             MoTa = p.MoTa,
                             DaoDien = p.DaoDien,
                             ThoiLuong = p.ThoiLuong,
                             ThoiGianKhoiChieu = p.ThoiGianKhoiChieu,
                             Anh = p.Anh,
                             DonGia = p.DonGia
                         }).ToList();
                //}
            }
            return phims;
        }




        [Route("phim")]
        [HttpGet]
        public List<Phim> getHoaDon()
        {
            return db.Phims.ToList();
        }


        [Route("Vote")]
        [HttpPut]
        public bool Vote(string maPhim, int diemVote)
        {
            var phim = db.Phims.Find(maPhim);
            phim.DiemVote = (phim.DiemVote * phim.SoLuongVote + diemVote) / (phim.SoLuongVote + 1);
            phim.SoLuongVote = phim.SoLuongVote + 1;
            db.SaveChanges();
            return true;
        }

        [Route("BinhLuan")]
        [HttpPost]
        public bool BinhLuan(string maPhim, string maKH, string cmt)
        {
            var binhLuan = new BinhLuan();
            binhLuan.MaPhim = maPhim;
            binhLuan.MaKh = maKH;
            binhLuan.BinhLuan1 = cmt;
            db.Add(binhLuan);
            db.SaveChanges();
            return true;

        }

        [Route("getBinhLuan")]
        [HttpGet]
        public List<String> getBinhLuan(string maPhim)
        {
            return db.BinhLuans.Where(x => x.MaPhim == maPhim).Select(x => x.BinhLuan1).ToList();
        }

    }
}
