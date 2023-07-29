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
    public class PhuongThucGHsController : ControllerBase
    {
        private readonly FullStackDbContext _context;

        public PhuongThucGHsController(FullStackDbContext context)
        {
            _context = context;
        }

        // GET: api/PhuongThucGHs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhuongThucGH>>> GetphuongThucGHs()
        {
          if (_context.phuongThucGHs == null)
          {
              return NotFound();
          }
            return await _context.phuongThucGHs.ToListAsync();
        }

        // GET: api/PhuongThucGHs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhuongThucGH>> GetPhuongThucGH(int id)
        {
          if (_context.phuongThucGHs == null)
          {
              return NotFound();
          }
            var phuongThucGH = await _context.phuongThucGHs.FindAsync(id);

            if (phuongThucGH == null)
            {
                return NotFound();
            }

            return phuongThucGH;
        }

        //// PUT: api/PhuongThucGHs/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPhuongThucGH(int id, PhuongThucGH phuongThucGH)
        //{
        //    if (id != phuongThucGH.MaPTGH)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(phuongThucGH).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PhuongThucGHExists(id))
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

        //// POST: api/PhuongThucGHs
        //[HttpPost]
        //public async Task<ActionResult<PhuongThucGH>> PostPhuongThucGH(PhuongThucGH phuongThucGH)
        //{
        //  if (_context.phuongThucGHs == null)
        //  {
        //      return Problem("Entity set 'FullStackDbContext.phuongThucGHs'  is null.");
        //  }
        //    _context.phuongThucGHs.Add(phuongThucGH);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPhuongThucGH", new { id = phuongThucGH.MaPTGH }, phuongThucGH);
        //}

        //// DELETE: api/PhuongThucGHs/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePhuongThucGH(int id)
        //{
        //    if (_context.phuongThucGHs == null)
        //    {
        //        return NotFound();
        //    }
        //    var phuongThucGH = await _context.phuongThucGHs.FindAsync(id);
        //    if (phuongThucGH == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.phuongThucGHs.Remove(phuongThucGH);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool PhuongThucGHExists(int id)
        //{
        //    return (_context.phuongThucGHs?.Any(e => e.MaPTGH == id)).GetValueOrDefault();
        //}
    }
}
