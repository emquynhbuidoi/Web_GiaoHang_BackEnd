﻿using System.ComponentModel.DataAnnotations;

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
        public string NgayDatGiao { get; set; }
        public string NgayGiaoHang { get; set; }
        public string TenNguoiNhan { get; set; }
        public string SDTNguoiNhan { get; set; }
        public string TenNguoiGui { get; set; }
        public string SDTNguoiGui { get; set; }
        public float TongTien { get; set; }



        public int MaKH { get; set; }
        public KhachHang khachHang { get; set; }
        public int MaPTTT { get; set; }
        public PhuongThucTT phuongThucTT { get; set; }
        public int MaPTGH { get; set; }
        public PhuongThucGH phuongThucGH { get; set; }
        public int MaPTVC { get; set; }
        public PhuongThucVC phuongThucVC { get; set; }
        public int? MaKM { get; set; }
        public KhuyenMai? khuyenMai { get; set; }
        public int? MaTX { get; set; }
        public TaiXe? taiXe { get; set; }
        public int? MaKho { get; set; }
        public Kho? kho { get; set; }
        

    }
}
