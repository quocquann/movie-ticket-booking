using System;
using System.Collections.Generic;

namespace BaiTapLonWeb.Models;

public partial class Ghe
{
    public string MaGhe { get; set; } = null!;

    public string? TenGhe { get; set; }

    public string? MaPhongChieu { get; set; }

    public virtual PhongChieu? MaPhongChieuNavigation { get; set; }

    public virtual ICollection<TrangThaiGhe> TrangThaiGhes { get; } = new List<TrangThaiGhe>();
}
