using System.ComponentModel.DataAnnotations;

namespace FullStackAPI.Models
{
    public class KhachHang
    {
        [Key]
        public int MaKH { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }


        //public int MaTK { get; set; }
        public TaiKhoan taiKhoan { get; set; }
    }
}
