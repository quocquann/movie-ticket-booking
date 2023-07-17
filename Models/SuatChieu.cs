using System;
using System.Collections.Generic;

namespace BaiTapLonWeb.Models;

public partial class SuatChieu
{
    public string MaSuatChieu { get; set; } = null!;

    public TimeSpan? GioBatDau { get; set; }

    public TimeSpan? GioKetThuc { get; set; }

    public DateTime? NgayChieu { get; set; }

    public string? MaPhim { get; set; }

    public string? MaPhongChieu { get; set; }

    public virtual ICollection<DonHang> DonHangs { get; } = new List<DonHang>();

    public virtual Phim? MaPhimNavigation { get; set; }

    public virtual PhongChieu? MaPhongChieuNavigation { get; set; }

    public virtual ICollection<TrangThaiGhe> TrangThaiGhes { get; } = new List<TrangThaiGhe>();
}
