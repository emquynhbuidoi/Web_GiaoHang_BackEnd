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
    public class PhuongThucTTsController : ControllerBase
    {
        private readonly FullStackDbContext _context;

        public PhuongThucTTsController(FullStackDbContext context)
        {
            _context = context;
        }

        // GET: api/PhuongThucTTs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhuongThucTT>>> GetphuongThucTTs()
        {
          if (_context.phuongThucTTs == null)
          {
              return NotFound();
          }
            return await _context.phuongThucTTs.ToListAsync();
        }

        // GET: api/PhuongThucTTs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhuongThucTT>> GetPhuongThucTT(int id)
        {
          if (_context.phuongThucTTs == null)
          {
              return NotFound();
          }
            var phuongThucTT = await _context.phuongThucTTs.FindAsync(id);

            if (phuongThucTT == null)
            {
                return NotFound();
            }

            return phuongThucTT;
        }

        //// PUT: api/PhuongThucTTs/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPhuongThucTT(int id, PhuongThucTT phuongThucTT)
        //{
        //    if (id != phuongThucTT.MaPTTT)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(phuongThucTT).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PhuongThucTTExists(id))
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

        //// POST: api/PhuongThucTTs
        //[HttpPost]
        //public async Task<ActionResult<PhuongThucTT>> PostPhuongThucTT(PhuongThucTT phuongThucTT)
        //{
        //  if (_context.phuongThucTTs == null)
        //  {
        //      return Problem("Entity set 'FullStackDbContext.phuongThucTTs'  is null.");
        //  }
        //    _context.phuongThucTTs.Add(phuongThucTT);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPhuongThucTT", new { id = phuongThucTT.MaPTTT }, phuongThucTT);
        //}

        //// DELETE: api/PhuongThucTTs/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePhuongThucTT(int id)
        //{
        //    if (_context.phuongThucTTs == null)
        //    {
        //        return NotFound();
        //    }
        //    var phuongThucTT = await _context.phuongThucTTs.FindAsync(id);
        //    if (phuongThucTT == null)
        //    {
        //        return NotFound();
        //    }
        //    _context.phuongThucTTs.Remove(phuongThucTT);
        //    await _context.SaveChangesAsync();
        //    return NoContent();
        //}
        //private bool PhuongThucTTExists(int id)
        //{
        //    return (_context.phuongThucTTs?.Any(e => e.MaPTTT == id)).GetValueOrDefault();
        //}
    }
}
