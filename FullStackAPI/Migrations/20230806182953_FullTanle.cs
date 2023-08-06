using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStackAPI.Migrations
{
    /// <inheritdoc />
    public partial class FullTanle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chucVus",
                columns: table => new
                {
                    MaCV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCV = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chucVus", x => x.MaCV);
                });

            migrationBuilder.CreateTable(
                name: "khos",
                columns: table => new
                {
                    MaKho = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khos", x => x.MaKho);
                });

            migrationBuilder.CreateTable(
                name: "khuyenMais",
                columns: table => new
                {
                    MaKM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhanTramKM = table.Column<float>(type: "real", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayApDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayKetThuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    MucTienApDung = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khuyenMais", x => x.MaKM);
                });

            migrationBuilder.CreateTable(
                name: "phuongThucGHs",
                columns: table => new
                {
                    MaPTGH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPTGH = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phuongThucGHs", x => x.MaPTGH);
                });

            migrationBuilder.CreateTable(
                name: "phuongThucTTs",
                columns: table => new
                {
                    MaPTTT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPTTT = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phuongThucTTs", x => x.MaPTTT);
                });

            migrationBuilder.CreateTable(
                name: "phuongThucVCs",
                columns: table => new
                {
                    MaPTVC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPTVC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonGia = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phuongThucVCs", x => x.MaPTVC);
                });

            migrationBuilder.CreateTable(
                name: "taiKhoans",
                columns: table => new
                {
                    MaTK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThaiTK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaCV = table.Column<int>(type: "int", nullable: false),
                    chucVuMaCV = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taiKhoans", x => x.MaTK);
                    table.ForeignKey(
                        name: "FK_taiKhoans_chucVus_chucVuMaCV",
                        column: x => x.chucVuMaCV,
                        principalTable: "chucVus",
                        principalColumn: "MaCV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "khachHangs",
                columns: table => new
                {
                    MaKH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    taiKhoanMaTK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khachHangs", x => x.MaKH);
                    table.ForeignKey(
                        name: "FK_khachHangs_taiKhoans_taiKhoanMaTK",
                        column: x => x.taiKhoanMaTK,
                        principalTable: "taiKhoans",
                        principalColumn: "MaTK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nhanViens",
                columns: table => new
                {
                    MaNV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    taiKhoanMaTK = table.Column<int>(type: "int", nullable: false),
                    MaKho = table.Column<int>(type: "int", nullable: true),
                    khoMaKho = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhanViens", x => x.MaNV);
                    table.ForeignKey(
                        name: "FK_nhanViens_khos_khoMaKho",
                        column: x => x.khoMaKho,
                        principalTable: "khos",
                        principalColumn: "MaKho");
                    table.ForeignKey(
                        name: "FK_nhanViens_taiKhoans_taiKhoanMaTK",
                        column: x => x.taiKhoanMaTK,
                        principalTable: "taiKhoans",
                        principalColumn: "MaTK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "taiXes",
                columns: table => new
                {
                    MaTX = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaBangLai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenPhuongTien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SLHD = table.Column<int>(type: "int", nullable: true),
                    taiKhoanMaTK = table.Column<int>(type: "int", nullable: false),
                    MaPTVC = table.Column<int>(type: "int", nullable: false),
                    phuongThucVCMaPTVC = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taiXes", x => x.MaTX);
                    table.ForeignKey(
                        name: "FK_taiXes_phuongThucVCs_phuongThucVCMaPTVC",
                        column: x => x.phuongThucVCMaPTVC,
                        principalTable: "phuongThucVCs",
                        principalColumn: "MaPTVC",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_taiXes_taiKhoans_taiKhoanMaTK",
                        column: x => x.taiKhoanMaTK,
                        principalTable: "taiKhoans",
                        principalColumn: "MaTK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "loTrinhs",
                columns: table => new
                {
                    MaLT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaChiGiao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChiNhan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaKH = table.Column<int>(type: "int", nullable: false),
                    khachHangMaKH = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loTrinhs", x => x.MaLT);
                    table.ForeignKey(
                        name: "FK_loTrinhs_khachHangs_khachHangMaKH",
                        column: x => x.khachHangMaKH,
                        principalTable: "khachHangs",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "donGiaos",
                columns: table => new
                {
                    MaDG = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrangThaiDG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChiGiao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChiNhan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KhoangCach = table.Column<float>(type: "real", nullable: false),
                    NgayDatGiao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayGiaoHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenNguoiNhan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDTNguoiNhan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenNguoiGui = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDTNguoiGui = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TongTien = table.Column<float>(type: "real", nullable: false),
                    MaKH = table.Column<int>(type: "int", nullable: false),
                    khachHangMaKH = table.Column<int>(type: "int", nullable: false),
                    MaPTTT = table.Column<int>(type: "int", nullable: false),
                    phuongThucTTMaPTTT = table.Column<int>(type: "int", nullable: false),
                    MaPTGH = table.Column<int>(type: "int", nullable: false),
                    phuongThucGHMaPTGH = table.Column<int>(type: "int", nullable: false),
                    MaPTVC = table.Column<int>(type: "int", nullable: false),
                    phuongThucVCMaPTVC = table.Column<int>(type: "int", nullable: false),
                    MaKM = table.Column<int>(type: "int", nullable: true),
                    khuyenMaiMaKM = table.Column<int>(type: "int", nullable: true),
                    MaTX = table.Column<int>(type: "int", nullable: true),
                    taiXeMaTX = table.Column<int>(type: "int", nullable: true),
                    MaKho = table.Column<int>(type: "int", nullable: true),
                    khoMaKho = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donGiaos", x => x.MaDG);
                    table.ForeignKey(
                        name: "FK_donGiaos_khachHangs_khachHangMaKH",
                        column: x => x.khachHangMaKH,
                        principalTable: "khachHangs",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_donGiaos_khos_khoMaKho",
                        column: x => x.khoMaKho,
                        principalTable: "khos",
                        principalColumn: "MaKho");
                    table.ForeignKey(
                        name: "FK_donGiaos_khuyenMais_khuyenMaiMaKM",
                        column: x => x.khuyenMaiMaKM,
                        principalTable: "khuyenMais",
                        principalColumn: "MaKM");
                    table.ForeignKey(
                        name: "FK_donGiaos_phuongThucGHs_phuongThucGHMaPTGH",
                        column: x => x.phuongThucGHMaPTGH,
                        principalTable: "phuongThucGHs",
                        principalColumn: "MaPTGH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_donGiaos_phuongThucTTs_phuongThucTTMaPTTT",
                        column: x => x.phuongThucTTMaPTTT,
                        principalTable: "phuongThucTTs",
                        principalColumn: "MaPTTT",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_donGiaos_phuongThucVCs_phuongThucVCMaPTVC",
                        column: x => x.phuongThucVCMaPTVC,
                        principalTable: "phuongThucVCs",
                        principalColumn: "MaPTVC",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_donGiaos_taiXes_taiXeMaTX",
                        column: x => x.taiXeMaTX,
                        principalTable: "taiXes",
                        principalColumn: "MaTX");
                });

            migrationBuilder.CreateTable(
                name: "phieuXuatNhaps",
                columns: table => new
                {
                    MaPhieu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayTao = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "GETDATE()"),
                    LaPhieuXuat = table.Column<int>(type: "int", nullable: false),
                    MaDG = table.Column<int>(type: "int", nullable: false),
                    donGiaoMaDG = table.Column<int>(type: "int", nullable: false),
                    MaKho = table.Column<int>(type: "int", nullable: false),
                    khoMaKho = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phieuXuatNhaps", x => x.MaPhieu);
                    table.ForeignKey(
                        name: "FK_phieuXuatNhaps_donGiaos_donGiaoMaDG",
                        column: x => x.donGiaoMaDG,
                        principalTable: "donGiaos",
                        principalColumn: "MaDG",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_phieuXuatNhaps_khos_khoMaKho",
                        column: x => x.khoMaKho,
                        principalTable: "khos",
                        principalColumn: "MaKho",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_donGiaos_khachHangMaKH",
                table: "donGiaos",
                column: "khachHangMaKH");

            migrationBuilder.CreateIndex(
                name: "IX_donGiaos_khoMaKho",
                table: "donGiaos",
                column: "khoMaKho");

            migrationBuilder.CreateIndex(
                name: "IX_donGiaos_khuyenMaiMaKM",
                table: "donGiaos",
                column: "khuyenMaiMaKM");

            migrationBuilder.CreateIndex(
                name: "IX_donGiaos_phuongThucGHMaPTGH",
                table: "donGiaos",
                column: "phuongThucGHMaPTGH");

            migrationBuilder.CreateIndex(
                name: "IX_donGiaos_phuongThucTTMaPTTT",
                table: "donGiaos",
                column: "phuongThucTTMaPTTT");

            migrationBuilder.CreateIndex(
                name: "IX_donGiaos_phuongThucVCMaPTVC",
                table: "donGiaos",
                column: "phuongThucVCMaPTVC");

            migrationBuilder.CreateIndex(
                name: "IX_donGiaos_taiXeMaTX",
                table: "donGiaos",
                column: "taiXeMaTX");

            migrationBuilder.CreateIndex(
                name: "IX_khachHangs_taiKhoanMaTK",
                table: "khachHangs",
                column: "taiKhoanMaTK");

            migrationBuilder.CreateIndex(
                name: "IX_loTrinhs_khachHangMaKH",
                table: "loTrinhs",
                column: "khachHangMaKH");

            migrationBuilder.CreateIndex(
                name: "IX_nhanViens_khoMaKho",
                table: "nhanViens",
                column: "khoMaKho");

            migrationBuilder.CreateIndex(
                name: "IX_nhanViens_taiKhoanMaTK",
                table: "nhanViens",
                column: "taiKhoanMaTK");

            migrationBuilder.CreateIndex(
                name: "IX_phieuXuatNhaps_donGiaoMaDG",
                table: "phieuXuatNhaps",
                column: "donGiaoMaDG");

            migrationBuilder.CreateIndex(
                name: "IX_phieuXuatNhaps_khoMaKho",
                table: "phieuXuatNhaps",
                column: "khoMaKho");

            migrationBuilder.CreateIndex(
                name: "IX_taiKhoans_chucVuMaCV",
                table: "taiKhoans",
                column: "chucVuMaCV");

            migrationBuilder.CreateIndex(
                name: "IX_taiXes_phuongThucVCMaPTVC",
                table: "taiXes",
                column: "phuongThucVCMaPTVC");

            migrationBuilder.CreateIndex(
                name: "IX_taiXes_taiKhoanMaTK",
                table: "taiXes",
                column: "taiKhoanMaTK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "loTrinhs");

            migrationBuilder.DropTable(
                name: "nhanViens");

            migrationBuilder.DropTable(
                name: "phieuXuatNhaps");

            migrationBuilder.DropTable(
                name: "donGiaos");

            migrationBuilder.DropTable(
                name: "khachHangs");

            migrationBuilder.DropTable(
                name: "khos");

            migrationBuilder.DropTable(
                name: "khuyenMais");

            migrationBuilder.DropTable(
                name: "phuongThucGHs");

            migrationBuilder.DropTable(
                name: "phuongThucTTs");

            migrationBuilder.DropTable(
                name: "taiXes");

            migrationBuilder.DropTable(
                name: "phuongThucVCs");

            migrationBuilder.DropTable(
                name: "taiKhoans");

            migrationBuilder.DropTable(
                name: "chucVus");
        }
    }
}
