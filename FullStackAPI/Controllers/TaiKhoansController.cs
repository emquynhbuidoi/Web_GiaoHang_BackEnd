using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FullStackAPI.Data;
using FullStackAPI.Models;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using FullStackAPI.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace FullStackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoansController : ControllerBase
    {
        private readonly FullStackDbContext _context;

        public TaiKhoansController(FullStackDbContext context)
        {
            _context = context;
        }


        // POST: Đăng ký
        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<TaiKhoan>> CreateTaiKhoan(TaiKhoan taiKhoan)
        {
            var cv = await _context.chucVus.FindAsync(taiKhoan.chucVu.MaCV);
            if (cv == null)
            {
                return BadRequest("Không tìm thấy khoá CV!");
            }
            taiKhoan.chucVu = cv;

            if (_context.taiKhoans == null)
            {
                return Problem("Entity set 'FullStackDbContext.taiKhoans'  is null.");
            }
            var existingAccount = await _context.taiKhoans.FirstOrDefaultAsync(x => x.Email == taiKhoan.Email);
            if (existingAccount != null)
            {
                return BadRequest("Tài khoản đã tồn tại !");
            }

            taiKhoan.MatKhau = PasswordHasher.HashPassword(taiKhoan.MatKhau);
            //taiKhoan.Token = "";

            _context.taiKhoans.Add(taiKhoan);
            await _context.SaveChangesAsync();

            return Ok(taiKhoan);
        }

        // GET: api/TaiKhoans
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaiKhoan>>> GettaiKhoans()
        {
          if (_context.taiKhoans == null)
          {
              return NotFound();
          }
            return await _context.taiKhoans.ToListAsync();
        }

        // GET: dựa vào ID
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<TaiKhoan>> GetTaiKhoan(int id)
        {
          if (_context.taiKhoans == null)
          {
              return NotFound();
          }
            var taiKhoan = await _context.taiKhoans.FindAsync(id);

            if (taiKhoan == null)
            {
                return NotFound();
            }

            return taiKhoan;
        }
        // Lấy: dựa vào EMAIL
        [HttpGet("GetEmail/{email}")]
        public async Task<ActionResult<TaiKhoan>> GetTaiKhoanEmail_MK(string email)
        {
            var taiKhoan = await _context.taiKhoans.FirstOrDefaultAsync(x => x.Email == email);
            if (taiKhoan == null)
            {
                return NotFound();
            }

            return taiKhoan;
        }

        // PUT: api/TaiKhoans/5
        //[Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaiKhoan(int id, TaiKhoan taiKhoanMoi)
        {
            if (id != taiKhoanMoi.MaTK)
            {
                return BadRequest();
            }


            _context.Entry(taiKhoanMoi).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaiKhoanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/TaiKhoans/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaiKhoan(int id)
        {
            if (_context.taiKhoans == null)
            {
                return NotFound();
            }
            var taiKhoan = await _context.taiKhoans.FindAsync(id);
            if (taiKhoan == null)
            {
                return NotFound();
            }

            _context.taiKhoans.Remove(taiKhoan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaiKhoanExists(int id)
        {
            return (_context.taiKhoans?.Any(e => e.MaTK == id)).GetValueOrDefault();
        }

        private async Task<bool> TaiKhoanTonTai(string Email)
        {
            return await _context.taiKhoans.AnyAsync(e => e.Email == Email);
        }
    }
}
