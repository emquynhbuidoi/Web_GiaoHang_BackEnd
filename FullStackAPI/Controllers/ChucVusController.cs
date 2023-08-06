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
    public class ChucVusController : ControllerBase
    {
        private readonly FullStackDbContext _context;

        public ChucVusController(FullStackDbContext context)
        {
            _context = context;
        }

        // GET: api/ChucVus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChucVu>>> GetchucVus()
        {
          if (_context.chucVus == null)
          {
              return NotFound();
          }
            return await _context.chucVus.ToListAsync();
        }

        // GET: api/ChucVus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChucVu>> GetChucVu(int id)
        {
          if (_context.chucVus == null)
          {
              return NotFound();
          }
            var chucVu = await _context.chucVus.FindAsync(id);

            if (chucVu == null)
            {
                return NotFound();
            }

            return chucVu;
        }

        //// PUT: api/ChucVus/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutChucVu(int id, ChucVu chucVu)
        //{
        //    if (id != chucVu.MaCV)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(chucVu).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ChucVuExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/ChucVus
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<ChucVu>> PostChucVu(ChucVu chucVu)
        //{
        //  if (_context.chucVus == null)
        //  {
        //      return Problem("Entity set 'FullStackDbContext.chucVus'  is null.");
        //  }
        //    _context.chucVus.Add(chucVu);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetChucVu", new { id = chucVu.MaCV }, chucVu);
        //}

        //// DELETE: api/ChucVus/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteChucVu(int id)
        //{
        //    if (_context.chucVus == null)
        //    {
        //        return NotFound();
        //    }
        //    var chucVu = await _context.chucVus.FindAsync(id);
        //    if (chucVu == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.chucVus.Remove(chucVu);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool ChucVuExists(int id)
        //{
        //    return (_context.chucVus?.Any(e => e.MaCV == id)).GetValueOrDefault();
        //}
    }
}
