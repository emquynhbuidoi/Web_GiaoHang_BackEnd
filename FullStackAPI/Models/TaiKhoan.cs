using System.ComponentModel.DataAnnotations;

namespace FullStackAPI.Models
{
    public class TaiKhoan
    {
        [Key]
        public int MaTK { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public string SDT { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string NgaySinh { get; set; }
        public string HoTen { get; set; }
        public string TrangThaiTK { get; set; }
        public string TenCV { get; set; }
        public string Token { get; set; }
    }
}
