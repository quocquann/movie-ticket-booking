using BaiTapLonWeb.Models;

namespace BaiTapLonWeb.ViewModels
{
    public class PhimViewData
    {
        public List<Phim> phimSapChieu { get; set; }
        public List<Phim> phamDangChieu { get; set; }


        public PhimViewData(List<Phim> phimSapChieu, List<Phim> phimDangChieu)
        {
            this.phamDangChieu = phimDangChieu;
            this.phimSapChieu = phimSapChieu;
        }

    }
}
