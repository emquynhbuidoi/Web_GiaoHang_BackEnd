using System.ComponentModel.DataAnnotations;

namespace FullStackAPI.Models
{
    public class KhuyenMai
    {
        [Key]
        public int MaKM { get; set; }
        public float PhanTramKM { get; set; }
        public string MoTa { get; set; }
        public DateTime NgayApDung { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public int SoLuong { get; set; }
        public float MuocTienApDung { get; set; }

    }
}
