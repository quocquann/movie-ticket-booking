using System;
using System.Collections.Generic;

namespace BaiTapLonWeb.Models;

public partial class TheLoai
{
    public string MaTheLoai { get; set; } = null!;

    public string? TenTheLoai { get; set; }

    public virtual ICollection<Phim> MaPhims { get; } = new List<Phim>();
}
