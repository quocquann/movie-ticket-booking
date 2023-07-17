namespace BaiTapLonWeb.Models.CinemaModels
{
    public class Movie
    {
        public string MaPhim { get; set; } = null!;

        public string? TenPhim { get; set; }

        public string? MoTa { get; set; }

        public string? DaoDien { get; set; }

        public int? ThoiLuong { get; set; }

        public DateTime? ThoiGianKhoiChieu { get; set; }

        public string? Anh { get; set; }

        public decimal? DonGia { get; set; }

    }
}
