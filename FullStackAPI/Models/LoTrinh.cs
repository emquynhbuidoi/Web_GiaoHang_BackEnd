using System.ComponentModel.DataAnnotations;

namespace FullStackAPI.Models
{
    public class LoTrinh
    {
        [Key]
        public int MaLT { get; set; }
        public string DiaChiGiao { get; set; }
        public string DiaChiNhan { get; set; }


        public int MaKH { get; set; }
        public KhachHang khachHang { get; set; }
    }
}
