using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStackAPI.Migrations
{
    /// <inheritdoc />
    public partial class fulltableKhoaNgoai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_taiXes_phuongThucVCs_phuongThucVCMaPTVC",
                table: "taiXes");

            migrationBuilder.DropIndex(
                name: "IX_taiXes_phuongThucVCMaPTVC",
                table: "taiXes");

            migrationBuilder.DropColumn(
                name: "MaPTVC",
                table: "taiXes");

            migrationBuilder.DropColumn(
                name: "MaTK",
                table: "taiXes");

            migrationBuilder.DropColumn(
                name: "phuongThucVCMaPTVC",
                table: "taiXes");

            migrationBuilder.DropColumn(
                name: "MaKho",
                table: "nhanViens");

            migrationBuilder.DropColumn(
                name: "MaTK",
                table: "nhanViens");

            migrationBuilder.DropColumn(
                name: "MaTK",
                table: "khachHangs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaPTVC",
                table: "taiXes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaTK",
                table: "taiXes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "phuongThucVCMaPTVC",
                table: "taiXes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaKho",
                table: "nhanViens",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaTK",
                table: "nhanViens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaTK",
                table: "khachHangs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_taiXes_phuongThucVCMaPTVC",
                table: "taiXes",
                column: "phuongThucVCMaPTVC");

            migrationBuilder.AddForeignKey(
                name: "FK_taiXes_phuongThucVCs_phuongThucVCMaPTVC",
                table: "taiXes",
                column: "phuongThucVCMaPTVC",
                principalTable: "phuongThucVCs",
                principalColumn: "MaPTVC",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
