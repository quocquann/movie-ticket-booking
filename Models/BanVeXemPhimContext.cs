using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLonWeb.Models;

public partial class BanVeXemPhimContext : DbContext
{
    public BanVeXemPhimContext()
    {
    }

    public BanVeXemPhimContext(DbContextOptions<BanVeXemPhimContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BinhLuan> BinhLuans { get; set; }

    public virtual DbSet<DonHang> DonHangs { get; set; }

    public virtual DbSet<Ghe> Ghes { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<Phim> Phims { get; set; }

    public virtual DbSet<PhongChieu> PhongChieus { get; set; }

    public virtual DbSet<QuanTriVien> QuanTriViens { get; set; }

    public virtual DbSet<RapChieu> RapChieus { get; set; }

    public virtual DbSet<SuatChieu> SuatChieus { get; set; }

    public virtual DbSet<TheLoai> TheLoais { get; set; }

    public virtual DbSet<TrangThaiGhe> TrangThaiGhes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-0TNEQFG\\SQLEXPRESS;Initial Catalog=BanVeXemPhim;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BinhLuan>(entity =>
        {
            entity.HasKey(e => new { e.MaKh, e.MaPhim }).HasName("pk_binhluan");

            entity.ToTable("BinhLuan");

            entity.Property(e => e.MaKh)
                .HasMaxLength(10)
                .HasColumnName("MaKH");
            entity.Property(e => e.MaPhim).HasMaxLength(10);
            entity.Property(e => e.BinhLuan1)
                .HasMaxLength(300)
                .HasColumnName("BinhLuan");

            entity.HasOne(d => d.MaPhimNavigation).WithMany(p => p.BinhLuans)
                .HasForeignKey(d => d.MaPhim)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_bl_p");
        });

        modelBuilder.Entity<DonHang>(entity =>
        {
            entity.HasKey(e => new { e.MaKh, e.MaSuatChieu }).HasName("pk_donhang");

            entity.ToTable("DonHang");

            entity.Property(e => e.MaKh)
                .HasMaxLength(10)
                .HasColumnName("MaKH");
            entity.Property(e => e.MaSuatChieu).HasMaxLength(10);
            entity.Property(e => e.ThoiGian).HasColumnType("datetime");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.MaKh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_khachhang");

            entity.HasOne(d => d.MaSuatChieuNavigation).WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.MaSuatChieu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_suatchieu");
        });

        modelBuilder.Entity<Ghe>(entity =>
        {
            entity.HasKey(e => e.MaGhe).HasName("PK__Ghe__3CD3C67BD7ADF2FF");

            entity.ToTable("Ghe");

            entity.Property(e => e.MaGhe).HasMaxLength(10);
            entity.Property(e => e.MaPhongChieu).HasMaxLength(10);
            entity.Property(e => e.TenGhe).HasMaxLength(10);

            entity.HasOne(d => d.MaPhongChieuNavigation).WithMany(p => p.Ghes)
                .HasForeignKey(d => d.MaPhongChieu)
                .HasConstraintName("fk_maphong_ghe");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("PK__KhachHan__2725CF1E30BD1FCE");

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKh)
                .HasMaxLength(10)
                .HasColumnName("MaKH");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.SoDienThoai).HasMaxLength(10);
            entity.Property(e => e.TenDangNhap)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TenKh)
                .HasMaxLength(30)
                .HasColumnName("TenKH");
        });

        modelBuilder.Entity<Phim>(entity =>
        {
            entity.HasKey(e => e.MaPhim).HasName("PK__Phim__4AC03DE3CB93FBCB");

            entity.ToTable("Phim");

            entity.Property(e => e.MaPhim).HasMaxLength(10);
            entity.Property(e => e.Anh).HasMaxLength(100);
            entity.Property(e => e.DaoDien).HasMaxLength(30);
            entity.Property(e => e.DonGia).HasColumnType("money");
            entity.Property(e => e.TenPhim).HasMaxLength(50);
            entity.Property(e => e.ThoiGianKhoiChieu).HasColumnType("date");
        });

        modelBuilder.Entity<PhongChieu>(entity =>
        {
            entity.HasKey(e => e.MaPhongChieu).HasName("PK__PhongChi__121FC6E2F3089A1F");

            entity.ToTable("PhongChieu");

            entity.Property(e => e.MaPhongChieu).HasMaxLength(10);
            entity.Property(e => e.MaRapChieu).HasMaxLength(10);
            entity.Property(e => e.TenPhongChieu).HasMaxLength(50);

            entity.HasOne(d => d.MaRapChieuNavigation).WithMany(p => p.PhongChieus)
                .HasForeignKey(d => d.MaRapChieu)
                .HasConstraintName("fk_phongChieu");
        });

        modelBuilder.Entity<QuanTriVien>(entity =>
        {
            entity.HasKey(e => e.MaQuanTriVien).HasName("PK__QuanTriV__6112BB3BCB9DAD34");

            entity.ToTable("QuanTriVien");

            entity.Property(e => e.MaQuanTriVien).HasMaxLength(10);
            entity.Property(e => e.MatKhau).HasMaxLength(30);
            entity.Property(e => e.TenTaiKhoan).HasMaxLength(30);
        });

        modelBuilder.Entity<RapChieu>(entity =>
        {
            entity.HasKey(e => e.MaRapChieu).HasName("PK__RapChieu__1B2240A19EFC5258");

            entity.ToTable("RapChieu");

            entity.Property(e => e.MaRapChieu).HasMaxLength(10);
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.TenRapChieu).HasMaxLength(30);
        });

        modelBuilder.Entity<SuatChieu>(entity =>
        {
            entity.HasKey(e => e.MaSuatChieu).HasName("PK__SuatChie__CF5984D275C2AA40");

            entity.ToTable("SuatChieu", tb => tb.HasTrigger("themGheSuatChieu"));

            entity.Property(e => e.MaSuatChieu).HasMaxLength(10);
            entity.Property(e => e.MaPhim).HasMaxLength(10);
            entity.Property(e => e.MaPhongChieu).HasMaxLength(10);
            entity.Property(e => e.NgayChieu).HasColumnType("date");

            entity.HasOne(d => d.MaPhimNavigation).WithMany(p => p.SuatChieus)
                .HasForeignKey(d => d.MaPhim)
                .HasConstraintName("fk_sc_maphim");

            entity.HasOne(d => d.MaPhongChieuNavigation).WithMany(p => p.SuatChieus)
                .HasForeignKey(d => d.MaPhongChieu)
                .HasConstraintName("fk_sc_maphongchieu");
        });

        modelBuilder.Entity<TheLoai>(entity =>
        {
            entity.HasKey(e => e.MaTheLoai).HasName("PK__TheLoai__D73FF34A870A339F");

            entity.ToTable("TheLoai");

            entity.Property(e => e.MaTheLoai).HasMaxLength(10);
            entity.Property(e => e.TenTheLoai).HasMaxLength(10);

            entity.HasMany(d => d.MaPhims).WithMany(p => p.MaTheLoais)
                .UsingEntity<Dictionary<string, object>>(
                    "PhimTheLoai",
                    r => r.HasOne<Phim>().WithMany()
                        .HasForeignKey("MaPhim")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_TheLoai_Phim_p"),
                    l => l.HasOne<TheLoai>().WithMany()
                        .HasForeignKey("MaTheLoai")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_TheLoai_Phim_tl"),
                    j =>
                    {
                        j.HasKey("MaTheLoai", "MaPhim").HasName("pk_TheLoai_Phim");
                        j.ToTable("Phim_TheLoai");
                        j.IndexerProperty<string>("MaTheLoai").HasMaxLength(10);
                        j.IndexerProperty<string>("MaPhim").HasMaxLength(10);
                    });
        });

        modelBuilder.Entity<TrangThaiGhe>(entity =>
        {
            entity.HasKey(e => new { e.MaGhe, e.MaSuatChieu }).HasName("pk_TrangThaiGhe");

            entity.ToTable("TrangThaiGhe");

            entity.Property(e => e.MaGhe).HasMaxLength(10);
            entity.Property(e => e.MaSuatChieu).HasMaxLength(10);

            entity.HasOne(d => d.MaGheNavigation).WithMany(p => p.TrangThaiGhes)
                .HasForeignKey(d => d.MaGhe)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ttghe_maghe");

            entity.HasOne(d => d.MaSuatChieuNavigation).WithMany(p => p.TrangThaiGhes)
                .HasForeignKey(d => d.MaSuatChieu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ttghe_maSc");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
