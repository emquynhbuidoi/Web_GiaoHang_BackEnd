using System.ComponentModel.DataAnnotations;

namespace FullStackAPI.Models
{
    public class PhieuXuatNhap
    {
        [Key]
        public int MaPhieu { get; set; }
        public DateTime NgayTao { get; set; }
        public int LaPhieuXuat { get; set; }

        public int MaDG { get; set; }
        public DonGiao donGiao { get; set; }
        public int MaKho { get; set; }
        public Kho kho { get; set; }

    }
}
