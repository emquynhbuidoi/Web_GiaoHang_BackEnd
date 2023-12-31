﻿// <auto-generated />
using System;
using FullStackAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FullStackAPI.Migrations
{
    [DbContext(typeof(FullStackDbContext))]
    partial class FullStackDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FullStackAPI.Models.ChucVu", b =>
                {
                    b.Property<int>("MaCV")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaCV"));

                    b.Property<string>("TenCV")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaCV");

                    b.ToTable("chucVus");
                });

            modelBuilder.Entity("FullStackAPI.Models.DonGiao", b =>
                {
                    b.Property<int>("MaDG")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaDG"));

                    b.Property<string>("DiaChiGiao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiaChiNhan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("KhoangCach")
                        .HasColumnType("real");

                    b.Property<int>("MaKH")
                        .HasColumnType("int");

                    b.Property<int?>("MaKM")
                        .HasColumnType("int");

                    b.Property<int?>("MaKho")
                        .HasColumnType("int");

                    b.Property<int>("MaPTGH")
                        .HasColumnType("int");

                    b.Property<int>("MaPTTT")
                        .HasColumnType("int");

                    b.Property<int>("MaPTVC")
                        .HasColumnType("int");

                    b.Property<int?>("MaTX")
                        .HasColumnType("int");

                    b.Property<string>("NgayDatGiao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NgayGiaoHang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDTNguoiGui")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDTNguoiNhan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenNguoiGui")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenNguoiNhan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("TongTien")
                        .HasColumnType("real");

                    b.Property<string>("TrangThaiDG")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("khachHangMaKH")
                        .HasColumnType("int");

                    b.Property<int?>("khoMaKho")
                        .HasColumnType("int");

                    b.Property<int?>("khuyenMaiMaKM")
                        .HasColumnType("int");

                    b.Property<int>("phuongThucGHMaPTGH")
                        .HasColumnType("int");

                    b.Property<int>("phuongThucTTMaPTTT")
                        .HasColumnType("int");

                    b.Property<int>("phuongThucVCMaPTVC")
                        .HasColumnType("int");

                    b.Property<int?>("taiXeMaTX")
                        .HasColumnType("int");

                    b.HasKey("MaDG");

                    b.HasIndex("khachHangMaKH");

                    b.HasIndex("khoMaKho");

                    b.HasIndex("khuyenMaiMaKM");

                    b.HasIndex("phuongThucGHMaPTGH");

                    b.HasIndex("phuongThucTTMaPTTT");

                    b.HasIndex("phuongThucVCMaPTVC");

                    b.HasIndex("taiXeMaTX");

                    b.ToTable("donGiaos");
                });

            modelBuilder.Entity("FullStackAPI.Models.KhachHang", b =>
                {
                    b.Property<int>("MaKH")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaKH"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("taiKhoanMaTK")
                        .HasColumnType("int");

                    b.HasKey("MaKH");

                    b.HasIndex("taiKhoanMaTK");

                    b.ToTable("khachHangs");
                });

            modelBuilder.Entity("FullStackAPI.Models.Kho", b =>
                {
                    b.Property<int>("MaKho")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaKho"));

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenKho")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaKho");

                    b.ToTable("khos");
                });

            modelBuilder.Entity("FullStackAPI.Models.KhuyenMai", b =>
                {
                    b.Property<int>("MaKM")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaKM"));

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("MucTienApDung")
                        .HasColumnType("real");

                    b.Property<string>("NgayApDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NgayKetThuc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PhanTramKM")
                        .HasColumnType("real");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("MaKM");

                    b.ToTable("khuyenMais");
                });

            modelBuilder.Entity("FullStackAPI.Models.LoTrinh", b =>
                {
                    b.Property<int>("MaLT")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaLT"));

                    b.Property<string>("DiaChiGiao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiaChiNhan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaKH")
                        .HasColumnType("int");

                    b.Property<int>("khachHangMaKH")
                        .HasColumnType("int");

                    b.HasKey("MaLT");

                    b.HasIndex("khachHangMaKH");

                    b.ToTable("loTrinhs");
                });

            modelBuilder.Entity("FullStackAPI.Models.NhanVien", b =>
                {
                    b.Property<int>("MaNV")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaNV"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MaKho")
                        .HasColumnType("int");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("khoMaKho")
                        .HasColumnType("int");

                    b.Property<int>("taiKhoanMaTK")
                        .HasColumnType("int");

                    b.HasKey("MaNV");

                    b.HasIndex("khoMaKho");

                    b.HasIndex("taiKhoanMaTK");

                    b.ToTable("nhanViens");
                });

            modelBuilder.Entity("FullStackAPI.Models.PhieuXuatNhap", b =>
                {
                    b.Property<int>("MaPhieu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaPhieu"));

                    b.Property<int>("LaPhieuXuat")
                        .HasColumnType("int");

                    b.Property<int>("MaDG")
                        .HasColumnType("int");

                    b.Property<int>("MaKho")
                        .HasColumnType("int");

                    b.Property<string>("NgayTao")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("donGiaoMaDG")
                        .HasColumnType("int");

                    b.Property<int>("khoMaKho")
                        .HasColumnType("int");

                    b.HasKey("MaPhieu");

                    b.HasIndex("donGiaoMaDG");

                    b.HasIndex("khoMaKho");

                    b.ToTable("phieuXuatNhaps");
                });

            modelBuilder.Entity("FullStackAPI.Models.PhuongThucGH", b =>
                {
                    b.Property<int>("MaPTGH")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaPTGH"));

                    b.Property<string>("TenPTGH")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaPTGH");

                    b.ToTable("phuongThucGHs");
                });

            modelBuilder.Entity("FullStackAPI.Models.PhuongThucTT", b =>
                {
                    b.Property<int>("MaPTTT")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaPTTT"));

                    b.Property<string>("TenPTTT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaPTTT");

                    b.ToTable("phuongThucTTs");
                });

            modelBuilder.Entity("FullStackAPI.Models.PhuongThucVC", b =>
                {
                    b.Property<int>("MaPTVC")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaPTVC"));

                    b.Property<float>("DonGia")
                        .HasColumnType("real");

                    b.Property<string>("TenPTVC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaPTVC");

                    b.ToTable("phuongThucVCs");
                });

            modelBuilder.Entity("FullStackAPI.Models.TaiKhoan", b =>
                {
                    b.Property<int>("MaTK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaTK"));

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GioiTinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaCV")
                        .HasColumnType("int");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NgaySinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrangThaiTK")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("chucVuMaCV")
                        .HasColumnType("int");

                    b.HasKey("MaTK");

                    b.HasIndex("chucVuMaCV");

                    b.ToTable("taiKhoans");
                });

            modelBuilder.Entity("FullStackAPI.Models.TaiXe", b =>
                {
                    b.Property<int>("MaTX")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaTX"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaBangLai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaPTVC")
                        .HasColumnType("int");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SLHD")
                        .HasColumnType("int");

                    b.Property<string>("TenPhuongTien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("phuongThucVCMaPTVC")
                        .HasColumnType("int");

                    b.Property<int>("taiKhoanMaTK")
                        .HasColumnType("int");

                    b.HasKey("MaTX");

                    b.HasIndex("phuongThucVCMaPTVC");

                    b.HasIndex("taiKhoanMaTK");

                    b.ToTable("taiXes");
                });

            modelBuilder.Entity("FullStackAPI.Models.DonGiao", b =>
                {
                    b.HasOne("FullStackAPI.Models.KhachHang", "khachHang")
                        .WithMany()
                        .HasForeignKey("khachHangMaKH")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FullStackAPI.Models.Kho", "kho")
                        .WithMany()
                        .HasForeignKey("khoMaKho");

                    b.HasOne("FullStackAPI.Models.KhuyenMai", "khuyenMai")
                        .WithMany()
                        .HasForeignKey("khuyenMaiMaKM");

                    b.HasOne("FullStackAPI.Models.PhuongThucGH", "phuongThucGH")
                        .WithMany()
                        .HasForeignKey("phuongThucGHMaPTGH")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FullStackAPI.Models.PhuongThucTT", "phuongThucTT")
                        .WithMany()
                        .HasForeignKey("phuongThucTTMaPTTT")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FullStackAPI.Models.PhuongThucVC", "phuongThucVC")
                        .WithMany()
                        .HasForeignKey("phuongThucVCMaPTVC")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FullStackAPI.Models.TaiXe", "taiXe")
                        .WithMany()
                        .HasForeignKey("taiXeMaTX");

                    b.Navigation("khachHang");

                    b.Navigation("kho");

                    b.Navigation("khuyenMai");

                    b.Navigation("phuongThucGH");

                    b.Navigation("phuongThucTT");

                    b.Navigation("phuongThucVC");

                    b.Navigation("taiXe");
                });

            modelBuilder.Entity("FullStackAPI.Models.KhachHang", b =>
                {
                    b.HasOne("FullStackAPI.Models.TaiKhoan", "taiKhoan")
                        .WithMany()
                        .HasForeignKey("taiKhoanMaTK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("taiKhoan");
                });

            modelBuilder.Entity("FullStackAPI.Models.LoTrinh", b =>
                {
                    b.HasOne("FullStackAPI.Models.KhachHang", "khachHang")
                        .WithMany()
                        .HasForeignKey("khachHangMaKH")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("khachHang");
                });

            modelBuilder.Entity("FullStackAPI.Models.NhanVien", b =>
                {
                    b.HasOne("FullStackAPI.Models.Kho", "kho")
                        .WithMany()
                        .HasForeignKey("khoMaKho");

                    b.HasOne("FullStackAPI.Models.TaiKhoan", "taiKhoan")
                        .WithMany()
                        .HasForeignKey("taiKhoanMaTK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("kho");

                    b.Navigation("taiKhoan");
                });

            modelBuilder.Entity("FullStackAPI.Models.PhieuXuatNhap", b =>
                {
                    b.HasOne("FullStackAPI.Models.DonGiao", "donGiao")
                        .WithMany()
                        .HasForeignKey("donGiaoMaDG")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FullStackAPI.Models.Kho", "kho")
                        .WithMany()
                        .HasForeignKey("khoMaKho")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("donGiao");

                    b.Navigation("kho");
                });

            modelBuilder.Entity("FullStackAPI.Models.TaiKhoan", b =>
                {
                    b.HasOne("FullStackAPI.Models.ChucVu", "chucVu")
                        .WithMany()
                        .HasForeignKey("chucVuMaCV")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("chucVu");
                });

            modelBuilder.Entity("FullStackAPI.Models.TaiXe", b =>
                {
                    b.HasOne("FullStackAPI.Models.PhuongThucVC", "phuongThucVC")
                        .WithMany()
                        .HasForeignKey("phuongThucVCMaPTVC")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FullStackAPI.Models.TaiKhoan", "taiKhoan")
                        .WithMany()
                        .HasForeignKey("taiKhoanMaTK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("phuongThucVC");

                    b.Navigation("taiKhoan");
                });
#pragma warning restore 612, 618
        }
    }
}
