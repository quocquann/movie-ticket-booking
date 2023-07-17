using System.Collections;

namespace BaiTapLonWeb.Models.CinemaModels
{
    public class Bill
    {
        public string tenPhim { get; set; }
        public string ngayChieu { get; set; }
        public string gioBatDau { get; set; }
        //public List<string> danhSachGhe { get; set; }
        //public int soLuong { get; set; }
        public int donGiaPhim { get; set; }  
        public string rapChieu { get; set; }
        //public DateTime thoiGianDatVe { get; set; }
        public string phongChieu { get; set; }
    }
}
