using System.ComponentModel.DataAnnotations;

namespace FullStackAPI.Models
{
    public class Kho
    {
        [Key]
        public int MaKho { get; set; }
        public string TenKho { get; set; }
        public string DiaChi { get; set; }

    }
}
