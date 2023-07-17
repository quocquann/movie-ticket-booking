using System;
using System.Collections.Generic;

namespace BaiTapLonWeb.Models;

public partial class KhachHang
{
    public string MaKh { get; set; } = null!;

    public string? TenKh { get; set; }

    public string? TenDangNhap { get; set; }

    public string? MatKhau { get; set; }

    public string? SoDienThoai { get; set; }

    public virtual ICollection<DonHang> DonHangs { get; } = new List<DonHang>();
}
