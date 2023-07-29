using System.ComponentModel.DataAnnotations;

namespace FullStackAPI.Models
{
    public class KhuyenMai
    {
        [Key]
        public int MaKM { get; set; }
        public float PhanTramKM { get; set; }
        public string MoTa { get; set; }
        public string NgayApDung { get; set; }
        public string NgayKetThuc { get; set; }
        public int SoLuong { get; set; }
        public float MucTienApDung { get; set; }

    }
}
