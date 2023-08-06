using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FullStackAPI.Data;
using FullStackAPI.Models;
using FullStackAPI.Helpers;

namespace FullStackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiXesController : ControllerBase
    {
        private readonly FullStackDbContext _context;

        public TaiXesController(FullStackDbContext context)
        {
            _context = context;
        }

        // GET: api/TaiXes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaiXe>>> GettaiXes()
        {
          if (_context.taiXes == null)
          {
              return NotFound();
          }
            return await _context.taiXes.ToListAsync();
        }

        // GET: api/TaiXes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaiXe>> GetTaiXe(int id)
        {
          if (_context.taiXes == null)
          {
              return NotFound();
          }
            var taiXe = await _context.taiXes.FindAsync(id);

            if (taiXe == null)
            {
                return NotFound();
            }

            return taiXe;
        }


        //Đăng ký tài xế
        [HttpPost]
        public async Task<ActionResult<TaiXe>> CreateTaiXe(TaiXe taiXe)
        {
            if (_context.taiXes == null)
            {
                return Problem("Entity set 'FullStackDbContext.taiXes'  is null.");
            }
            var existingAccount = await _context.taiXes.FirstOrDefaultAsync(x => x.Email == taiXe.Email);
            if (existingAccount != null)
            {
                return BadRequest("Tài xế đã tồn tại !");
            }

            string mkMaHoa = PasswordHasher.HashPassword(taiXe.MatKhau);
            taiXe.MatKhau = mkMaHoa;
            taiXe.taiKhoan.MatKhau = mkMaHoa;

            var cv = await _context.chucVus.FindAsync(taiXe.taiKhoan.MaCV);
            if (cv == null)
            {
                return BadRequest("Không tìm thấy khoá CV!");
            }
            taiXe.taiKhoan.chucVu = cv;

            var vanchuyen = await _context.phuongThucVCs.FindAsync(taiXe.MaPTVC);
            if (vanchuyen == null)
            {
                return BadRequest("Không tìm thấy phương thức vận chuyển!");
            }
            taiXe.phuongThucVC = vanchuyen;

            _context.taiXes.Add(taiXe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaiXe", new { id = taiXe.MaTX }, taiXe);
        }

        // DELETE: api/TaiXes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaiXe(int id)
        {
            if (_context.taiXes == null)
            {
                return NotFound();
            }

            var tk = await _context.taiKhoans.FindAsync(id);
            if (tk == null)
            {
                return BadRequest("Không tìm thấy khoá CV!");
            }
            _context.taiKhoans.Remove(tk);

            var taiXe = await _context.taiXes.FirstOrDefaultAsync(x => x.Email == tk.Email);
            if (taiXe == null)
            {
                return NotFound();
            }
            _context.taiXes.Remove(taiXe);

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
