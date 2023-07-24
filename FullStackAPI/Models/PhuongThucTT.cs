using System.ComponentModel.DataAnnotations;

namespace FullStackAPI.Models
{
    public class PhuongThucTT
    {
        [Key]
        public int MaPTTT { get; set; }
        public string TenPTTT { get; set; }
    }
}
