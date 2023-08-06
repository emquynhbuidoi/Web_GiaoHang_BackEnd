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
    public class PhieuXuatNhapsController : ControllerBase
    {
        private readonly FullStackDbContext _context;

        public PhieuXuatNhapsController(FullStackDbContext context)
        {
            _context = context;
        }

        // POST: api/PhieuXuatNhaps
        [HttpPost]
        public async Task<ActionResult<PhieuXuatNhap>> PostPhieuXuatNhap(PhieuXuatNhap phieuXuatNhap)
        {
            if (_context.phieuXuatNhaps == null)
            {
                return Problem("Entity set 'FullStackDbContext.phieuXuatNhaps'  is null.");
            }

            var dg = await _context.donGiaos.FindAsync(phieuXuatNhap.MaDG);
            if (dg == null)
            {
                return BadRequest("Không tìm thấy khoá MaDG!");
            }
            phieuXuatNhap.donGiao = dg;

            var kho = await _context.khos.FindAsync(phieuXuatNhap.MaKho);
            if (kho == null)
            {
                return BadRequest("Không tìm thấy khoá MaKho!");
            }
            phieuXuatNhap.kho = kho;


            _context.phieuXuatNhaps.Add(phieuXuatNhap);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhieuXuatNhap", new { id = phieuXuatNhap.MaPhieu }, phieuXuatNhap);
        }

        // GET: api/PhieuXuatNhaps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhieuXuatNhap>>> GetphieuXuatNhaps()
        {
          if (_context.phieuXuatNhaps == null)
          {
              return NotFound();
          }
            return await _context.phieuXuatNhaps.ToListAsync();
        }

        // GET: api/PhieuXuatNhaps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhieuXuatNhap>> GetPhieuXuatNhap(int id)
        {
          if (_context.phieuXuatNhaps == null)
          {
              return NotFound();
          }
            var phieuXuatNhap = await _context.phieuXuatNhaps.FindAsync(id);

            if (phieuXuatNhap == null)
            {
                return NotFound();
            }

            return phieuXuatNhap;
        }

        // PUT: api/PhieuXuatNhaps/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhieuXuatNhap(int id, PhieuXuatNhap phieuXuatNhap)
        {
            if (id != phieuXuatNhap.MaPhieu)
            {
                return BadRequest();
            }

            _context.Entry(phieuXuatNhap).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
