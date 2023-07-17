using System;
using System.Collections.Generic;

namespace BaiTapLonWeb.Models;

public partial class PhongChieu
{
    public string MaPhongChieu { get; set; } = null!;

    public string? TenPhongChieu { get; set; }

    public int? SucChua { get; set; }

    public string? MaRapChieu { get; set; }

    public virtual ICollection<Ghe> Ghes { get; } = new List<Ghe>();

    public virtual RapChieu? MaRapChieuNavigation { get; set; }

    public virtual ICollection<SuatChieu> SuatChieus { get; } = new List<SuatChieu>();
}
