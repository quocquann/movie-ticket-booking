using System;
using System.Collections.Generic;

namespace BaiTapLonWeb.Models;

public partial class TrangThaiGhe
{
    public string MaGhe { get; set; } = null!;

    public string MaSuatChieu { get; set; } = null!;

    public int? TrangThai { get; set; }

    public virtual Ghe MaGheNavigation { get; set; } = null!;

    public virtual SuatChieu MaSuatChieuNavigation { get; set; } = null!;
}
