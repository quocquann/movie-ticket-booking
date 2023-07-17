using BaiTapLonWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BaiTapLonWeb.Controllers
{
    public class AccessClientController : Controller
    {
        BanVeXemPhimContext DB = new BanVeXemPhimContext();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LoginClient()
        {
            if (HttpContext.Session.GetString("maKH") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult LoginClient(KhachHang khachHang)
        {


            if (HttpContext.Session.GetString("maKH") == null)
            {
                var obj = DB.KhachHangs.Where(x => x.TenDangNhap == khachHang.TenDangNhap && x.MatKhau == khachHang.MatKhau).FirstOrDefault();
                if (obj != null)
                {
                    HttpContext.Session.SetString("maKH", obj.MaKh);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        public IActionResult LogoutClient()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("maKH");
            return RedirectToAction("Index", "Home");
        }

    }
}
