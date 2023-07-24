using System.ComponentModel.DataAnnotations;

namespace FullStackAPI.Models
{
    public class DonGiao
    {
        [Key]
        public int MaDG { get; set; }
        public string TrangThaiDG { get; set; }
        public string DiaChiGiao { get; set; }
        public string DiaChiNhan { get; set; }
        public float KhoangCach { get; set; }
        public DateTime NgayDatGiao { get; set; }
        public DateTime NgayGiaoHang { get; set; }
        public int LaDonDatGiao { get; set; }
        public string TenNguoiNhan { get; set; }
        public string SDTNguoiNhan { get; set; }
        public float TongTien { get; set; }
        public string TenPTVC { get; set; }



        public int MaKH { get; set; }
        public KhachHang khachHang { get; set; }
        public int MaPTTT { get; set; }
        public PhuongThucTT phuongThucTT { get; set; }
        public int MaPTGH { get; set; }
        public PhuongThucGH phuongThucGH { get; set; }
        public int? MaTX { get; set; }
        public TaiXe? taiXe { get; set; }
        public int? MaKho { get; set; }
        public Kho? kho { get; set; }
        public int? MaKM { get; set; }
        public KhuyenMai? khuyenMai { get; set; }

    }
}
