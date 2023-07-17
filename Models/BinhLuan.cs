using System;
using System.Collections.Generic;

namespace BaiTapLonWeb.Models;

public partial class BinhLuan
{
    public string MaKh { get; set; } = null!;

    public string MaPhim { get; set; } = null!;

    public string? BinhLuan1 { get; set; }

    public virtual Phim MaPhimNavigation { get; set; } = null!;
}
