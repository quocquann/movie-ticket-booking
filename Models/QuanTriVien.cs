using System;
using System.Collections.Generic;

namespace BaiTapLonWeb.Models;

public partial class QuanTriVien
{
    public string MaQuanTriVien { get; set; } = null!;

    public string? TenTaiKhoan { get; set; }

    public string? MatKhau { get; set; }
}
