namespace BaiTapLonWeb.Models.CinemaModels
{
    public class ShowTime
    {
        public string maSuatChieu { get; set; }
        public TimeSpan? GioBatDau { get; set; }

        public TimeSpan? GioKetThuc { get; set; }

        public DateTime? NgayChieu { get; set; }

        public string? tenPhongChieu { get; set; }

        public string tenRap { get; set; }
    }
}
