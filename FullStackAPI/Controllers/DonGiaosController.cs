using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FullStackAPI.Data;
using FullStackAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace FullStackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonGiaosController : ControllerBase
    {
        private readonly FullStackDbContext _context;

        public DonGiaosController(FullStackDbContext context)
        {
            _context = context;
        }

        // GET: api/DonGiaos
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonGiao>>> GetdonGiao()
        {
            if (_context.donGiaos == null)
            {
                return NotFound();
            }
            return await _context.donGiaos.ToListAsync();
        }

        // GET: dựa vào ID
        [HttpGet("{id}")]
        public async Task<ActionResult<DonGiao>> GetDonGiao(int id)
        {
            if (_context.donGiaos == null)
            {
                return NotFound();
            }
            var dongiao = await _context.donGiaos.FindAsync(id);

            if (dongiao == null)
            {
                return NotFound();
            }

            return dongiao;
        }
        // Lấy: dựa vào EMAIL
        [HttpGet("GetEmail/{email}")]
        public async Task<ActionResult<DonGiao>> GetDonGiaoFromEmail(string email)
        {
            var donGiao = await _context.donGiaos.FirstOrDefaultAsync(x => x.khachHang.Email == email);
            if (donGiao == null)
            {
                return NotFound();
            }

            return donGiao;
        }

        // PUT: api/DonGiaos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonGiao(int id, DonGiao donGiao)
        {
            if (id != donGiao.MaDG)
            {
                return BadRequest();
            }

            _context.Entry(donGiao).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/DonGiaos
        [HttpPost]
        public async Task<ActionResult<DonGiao>> PostDonGiao(DonGiao donGiao)
        {
            if (_context.donGiaos == null)
            {
                return Problem("Entity set 'FullStackDbContext.donGiaos'  is null.");
            }

            if (donGiao.MaKH == 0 || donGiao.MaPTTT == 0 || donGiao.MaPTGH == 0 || donGiao.MaPTVC == 0)
            {
                return BadRequest("Thiếu thông tin khoá ngoại");
            }

            var kh = await _context.khachHangs.FindAsync(donGiao.MaKH);
            var pttt = await _context.phuongThucTTs.FindAsync(donGiao.MaPTTT);
            var ptgh = await _context.phuongThucGHs.FindAsync(donGiao.MaPTGH);
            var ptvc = await _context.phuongThucVCs.FindAsync(donGiao.MaPTVC);


            if (kh == null || pttt == null || ptgh == null || ptvc == null)
            {
                return BadRequest("Không tìm thấy thông tin khoá ngoại!");
            }

            donGiao.khachHang = kh;
            donGiao.phuongThucTT = pttt;
            donGiao.phuongThucGH = ptgh;
            donGiao.phuongThucVC = ptvc;

            if(donGiao.MaKM != 0)
            {
                var km = await _context.khuyenMais.FindAsync(donGiao.MaKM);
                if(km != null)
                {
                    donGiao.khuyenMai = km;
                }
            }
            else
            {
                donGiao.khuyenMai = null;
            }

            if (donGiao.MaTX != 0)
            {
                var tx = await _context.taiXes.FindAsync(donGiao.MaTX);
                if (tx != null)
                {
                    donGiao.taiXe = tx;
                }
            }
            else
            {
                donGiao.taiXe = null;
            }
            if (donGiao.MaKho != 0)
            {
                var kho = await _context.khos.FindAsync(donGiao.MaKho);
                if (kho != null)
                {
                    donGiao.kho = kho;
                }
            }
            else
            {
                donGiao.kho = null;
            }


            _context.donGiaos.Add(donGiao);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetDonGiao", new { id = donGiao.MaDG }, donGiao);
        }

    
    }
}
