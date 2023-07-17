using System;
using System.Collections.Generic;

namespace BaiTapLonWeb.Models;

public partial class RapChieu
{
    public string MaRapChieu { get; set; } = null!;

    public string? TenRapChieu { get; set; }

    public string? DiaChi { get; set; }

    public virtual ICollection<PhongChieu> PhongChieus { get; } = new List<PhongChieu>();
}
