using FullStackAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


namespace FullStackAPI.Data
{
    public class FullStackDbContext: DbContext
    {
        public FullStackDbContext(DbContextOptions opt):base(opt)
        {

        }

        public DbSet<KhachHang> khachHangs { get; set; }
        public DbSet<Kho> khos { get; set; }
        public DbSet<NhanVien> nhanViens { get; set; }
        public DbSet<TaiXe> taiXes { get; set; }
        public DbSet<TaiKhoan> taiKhoans { get; set; }
        public DbSet<PhieuXuatNhap> phieuXuatNhaps { get; set; }
        public DbSet<DonGiao> donGiaos { get; set; }
        public DbSet<KhuyenMai> khuyenMais { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhieuXuatNhap>()
                .Property(e => e.NgayTao)
                .HasDefaultValueSql("GETDATE()");
        }
        public DbSet<LoTrinh> loTrinhs { get; set; }
        public DbSet<PhuongThucGH> phuongThucGHs { get; set; }
        public DbSet<PhuongThucVC> phuongThucVCs { get; set; }
        public DbSet<PhuongThucTT> phuongThucTTs { get; set; }
    }
}
