using System.ComponentModel.DataAnnotations;

namespace FullStackAPI.Models
{
    public class PhuongThucVC
    {
        [Key]
        public int MaPTVC { get; set; }
        public string TenPTVC { get; set; }
    }
}
