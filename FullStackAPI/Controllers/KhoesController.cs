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
    public class KhoesController : ControllerBase
    {
        private readonly FullStackDbContext _context;

        public KhoesController(FullStackDbContext context)
        {
            _context = context;
        }

        // GET: api/Khoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kho>>> Getkhos()
        {
          if (_context.khos == null)
          {
              return NotFound();
          }
            return await _context.khos.ToListAsync();
        }

        // GET: api/Khoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kho>> GetKho(int id)
        {
          if (_context.khos == null)
          {
              return NotFound();
          }
            var kho = await _context.khos.FindAsync(id);

            if (kho == null)
            {
                return NotFound();
            }

            return kho;
        }
    }
}
