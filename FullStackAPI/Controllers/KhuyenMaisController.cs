using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FullStackAPI.Data;
using FullStackAPI.Models;

namespace FullStackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhuyenMaisController : ControllerBase
    {
        private readonly FullStackDbContext _context;

        public KhuyenMaisController(FullStackDbContext context)
        {
            _context = context;
        }

        // GET: api/KhuyenMais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KhuyenMai>>> GetkhuyenMais()
        {
          if (_context.khuyenMais == null)
          {
              return NotFound();
          }
            return await _context.khuyenMais.ToListAsync();
        }

        // GET: api/KhuyenMais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KhuyenMai>> GetKhuyenMai(int id)
        {
          if (_context.khuyenMais == null)
          {
              return NotFound();
          }
            var khuyenMai = await _context.khuyenMais.FindAsync(id);

            if (khuyenMai == null)
            {
                return NotFound();
            }
            return khuyenMai;
        }

        //// PUT: api/KhuyenMais/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKhuyenMai(int id, KhuyenMai khuyenMai)
        {
            if (id != khuyenMai.MaKM)
            {
                return BadRequest();
            }

            _context.Entry(khuyenMai).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        // POST: api/KhuyenMais
        [HttpPost]
        public async Task<ActionResult<KhuyenMai>> PostKhuyenMai(KhuyenMai khuyenMai)
        {
            if (_context.khuyenMais == null)
            {
                return Problem("Entity set 'FullStackDbContext.khuyenMais'  is null.");
            }
            _context.khuyenMais.Add(khuyenMai);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetKhuyenMai", new { id = khuyenMai.MaKM }, khuyenMai);
        }
        // DELETE: api/KhuyenMais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhuyenMai(int id)
        {
            if (_context.khuyenMais == null)
            {
                return NotFound();
            }
            var khuyenMai = await _context.khuyenMais.FindAsync(id);
            if (khuyenMai == null)
            {
                return NotFound();
            }
            _context.khuyenMais.Remove(khuyenMai);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
