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
    public class PhuongThucVCsController : ControllerBase
    {
        private readonly FullStackDbContext _context;

        public PhuongThucVCsController(FullStackDbContext context)
        {
            _context = context;
        }

        // GET: api/PhuongThucVCs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhuongThucVC>>> GetphuongThucVCs()
        {
          if (_context.phuongThucVCs == null)
          {
              return NotFound();
          }
            return await _context.phuongThucVCs.ToListAsync();
        }

        // GET: api/PhuongThucVCs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhuongThucVC>> GetPhuongThucVC(int id)
        {
          if (_context.phuongThucVCs == null)
          {
              return NotFound();
          }
            var phuongThucVC = await _context.phuongThucVCs.FindAsync(id);

            if (phuongThucVC == null)
            {
                return NotFound();
            }

            return phuongThucVC;
        }

        //// PUT: api/PhuongThucVCs/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPhuongThucVC(int id, PhuongThucVC phuongThucVC)
        //{
        //    if (id != phuongThucVC.MaPTVC)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(phuongThucVC).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PhuongThucVCExists(id))
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

        //// POST: api/PhuongThucVCs
        //[HttpPost]
        //public async Task<ActionResult<PhuongThucVC>> PostPhuongThucVC(PhuongThucVC phuongThucVC)
        //{
        //  if (_context.phuongThucVCs == null)
        //  {
        //      return Problem("Entity set 'FullStackDbContext.phuongThucVCs'  is null.");
        //  }
        //    _context.phuongThucVCs.Add(phuongThucVC);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPhuongThucVC", new { id = phuongThucVC.MaPTVC }, phuongThucVC);
        //}

        //// DELETE: api/PhuongThucVCs/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePhuongThucVC(int id)
        //{
        //    if (_context.phuongThucVCs == null)
        //    {
        //        return NotFound();
        //    }
        //    var phuongThucVC = await _context.phuongThucVCs.FindAsync(id);
        //    if (phuongThucVC == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.phuongThucVCs.Remove(phuongThucVC);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool PhuongThucVCExists(int id)
        //{
        //    return (_context.phuongThucVCs?.Any(e => e.MaPTVC == id)).GetValueOrDefault();
        //}
    }
}
