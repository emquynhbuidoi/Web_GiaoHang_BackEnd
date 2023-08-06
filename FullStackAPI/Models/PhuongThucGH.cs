using System.ComponentModel.DataAnnotations;

namespace FullStackAPI.Models
{
    public class PhuongThucGH
    {
        [Key]
        public int MaPTGH { get; set; }
        public string TenPTGH { get; set; }
    }
}
