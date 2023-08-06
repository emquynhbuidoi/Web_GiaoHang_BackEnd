using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FullStackAPI.Data;
using FullStackAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using FullStackAPI.Helpers;

namespace FullStackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanViensController : ControllerBase
    {
        private readonly FullStackDbContext _context;

        public NhanViensController(FullStackDbContext context)
        {
            _context = context;
        }

        // GET: api/NhanViens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhanVien>>> GetnhanViens()
        {
          if (_context.nhanViens == null)
          {
              return NotFound();
          }
            return await _context.nhanViens.ToListAsync();
        }

        // GET: api/NhanViens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NhanVien>> GetNhanVien(int id)
        {
          if (_context.nhanViens == null)
          {
              return NotFound();
          }
            var nhanVien = await _context.nhanViens.FindAsync(id);

            if (nhanVien == null)
            {
                return NotFound();
            }

            return nhanVien;
        }

        // POST: api/NhanViens
        [HttpPost]
        public async Task<ActionResult<NhanVien>> CreateNhanVien(NhanVien nhanVien)
        {
            if(nhanVien.MaKho != 0) { 
                var kho = await _context.khos.FindAsync(nhanVien.MaKho);
                if (kho == null)
                {
                    return BadRequest("Không tìm thấy khoá kho!");
                }
                nhanVien.kho = kho;
            }
            else
            {
                nhanVien.kho = null;
            }
            var existingAccount = await _context.nhanViens.FirstOrDefaultAsync(x => x.Email == nhanVien.Email);
            if (existingAccount != null)
            {
                return BadRequest("Nhân viên đã tồn tại !");
            }

            if (_context.nhanViens == null)
            {
                  return Problem("Entity set 'FullStackDbContext.nhanViens'  is null.");
            }

            string mkMaHoa = PasswordHasher.HashPassword(nhanVien.MatKhau);
            nhanVien.MatKhau = mkMaHoa;
            nhanVien.taiKhoan.MatKhau = mkMaHoa;

            var cv = await _context.chucVus.FindAsync(nhanVien.taiKhoan.MaCV);
            if (cv == null)
            {
                return BadRequest("Không tìm thấy khoá CV!");
            }
            nhanVien.taiKhoan.chucVu = cv;

            _context.nhanViens.Add(nhanVien);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNhanVien", new { id = nhanVien.MaNV }, nhanVien);
        }

        // DELETE: api/NhanViens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNhanVien(int id)
        {
            if (_context.nhanViens == null)
            {
                return NotFound();
            }

            var tk = await _context.taiKhoans.FindAsync(id);
            if (tk == null)
            {
                return BadRequest("Không tìm thấy khoá CV!");
            }
            _context.taiKhoans.Remove(tk);

            var nhanVien = await _context.nhanViens.FirstOrDefaultAsync(x => x.Email == tk.Email);
            if (nhanVien == null)
            {
                return NotFound();
            }
            _context.nhanViens.Remove(nhanVien);

            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
