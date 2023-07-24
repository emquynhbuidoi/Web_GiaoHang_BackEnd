using System.ComponentModel.DataAnnotations;

namespace FullStackAPI.Models
{
    public class TaiXe
    {
        [Key]
        public int MaTX { get; set; }
        public string MaBangLai { get; set; }
        public string TenPhuongTien { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }



        public TaiKhoan taiKhoan { get; set; }
    }
}
