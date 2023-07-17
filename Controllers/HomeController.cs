using Azure;
using BaiTapLonWeb.Models;
using BaiTapLonWeb.Models.Authentication;
using BaiTapLonWeb.Models.CinemaModels;
using BaiTapLonWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using X.PagedList;

namespace BaiTapLonWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        BanVeXemPhimContext db = new BanVeXemPhimContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Phim> phimSapChieu = db.Phims.Where(x => x.ThoiGianKhoiChieu > DateTime.Today).ToList();
            List<Phim> phimDangChieu = db.Phims.Where(x => x.ThoiGianKhoiChieu < DateTime.Today && x.ThoiGianKhoiChieu.Value.AddDays(10) > DateTime.Today).ToList();

            PhimViewData phimViewData = new PhimViewData(phimSapChieu, phimDangChieu);
            return View(phimViewData);
        }

        public IActionResult ChiTietPhim(string maPhim)
        {
            Phim phim = db.Phims.Find(maPhim);
            var theLoais = from p in db.Phims
                           where p.MaPhim == maPhim
                           select p.MaTheLoais.ToList();
            ViewBag.theLoais = theLoais;
            return View(phim);
        }

        public IActionResult DatVe(string maPhim)
        {
            ViewBag.maPhim = maPhim;
            return View();
        }

        [Authentication]
        public IActionResult ChonGhe(string maSuatChieu)
        {
            ViewBag.maSuatChieu = maSuatChieu;
            return View();
        }

        //public IActionResult LichSuMuaVe(string maKH)
        //{
        //    var don
        //    var suatChieu = db.SuatChieus.Find(maSuatChieu);
        //    var tenPhim = db.Phims.Find(suatChieu.MaPhim).TenPhim;
        //    var ngayChieu = suatChieu.NgayChieu.ToString();
        //    var gioBatDau = suatChieu.GioBatDau.ToString();
        //    var gioKetThuc = suatChieu.GioKetThuc;
        //    var maRap = db.PhongChieus.Find(suatChieu.MaPhongChieu).MaRapChieu;
        //    var tenRap = db.RapChieus.Find(maRap).TenRapChieu;
        //    var tenPhongChieu = db.PhongChieus.Find(suatChieu.MaPhongChieu).TenPhongChieu;

        //    var donGiaPhim = db.Phims.Find(suatChieu.MaPhim).DonGia;
        //    Bill bill = new Bill();
        //    bill.tenPhim = tenPhim;
        //    bill.ngayChieu = ngayChieu;
        //    bill.gioBatDau = gioBatDau;
        //    bill.rapChieu = tenRap;
        //    bill.phongChieu = tenPhongChieu;
        //    bill.donGiaPhim = (int)donGiaPhim;
        //    return View(donHangs);
        //}




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}