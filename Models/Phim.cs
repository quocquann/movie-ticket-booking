using System;
using System.Collections.Generic;

namespace BaiTapLonWeb.Models;

public partial class Phim
{
    public string MaPhim { get; set; } = null!;

    public string? TenPhim { get; set; }

    public string? MoTa { get; set; }

    public string? DaoDien { get; set; }

    public int? ThoiLuong { get; set; }

    public DateTime? ThoiGianKhoiChieu { get; set; }

    public string? Anh { get; set; }

    public decimal? DonGia { get; set; }

    public double? DiemVote { get; set; }

    public int? SoLuongVote { get; set; }

    public virtual ICollection<BinhLuan> BinhLuans { get; } = new List<BinhLuan>();

    public virtual ICollection<SuatChieu> SuatChieus { get; } = new List<SuatChieu>();

    public virtual ICollection<TheLoai> MaTheLoais { get; } = new List<TheLoai>();
}
