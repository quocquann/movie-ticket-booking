using System;
using System.Collections.Generic;

namespace BaiTapLonWeb.Models;

public partial class DonHang
{
    public string MaKh { get; set; } = null!;

    public string MaSuatChieu { get; set; } = null!;

    public DateTime? ThoiGian { get; set; }

    public int? SoLuongVe { get; set; }

    public int? TongTien { get; set; }

    public virtual KhachHang MaKhNavigation { get; set; } = null!;

    public virtual SuatChieu MaSuatChieuNavigation { get; set; } = null!;
}
