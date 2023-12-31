﻿using System.ComponentModel.DataAnnotations;

namespace FullStackAPI.Models
{
    public class NhanVien
    {
        [Key]
        public int MaNV { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }


        //public int MaTK { get; set; }
        public TaiKhoan taiKhoan { get; set; }
        public int? MaKho { get; set; }
        public Kho? kho { get; set; }
    }
}
