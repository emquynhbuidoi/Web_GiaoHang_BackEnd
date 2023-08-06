
using System.ComponentModel.DataAnnotations;

namespace FullStackAPI.Models
{
    public class ChucVu
    {
        [Key]
        public int MaCV { get; set; }
        public string TenCV { get; set; }
    }
}
