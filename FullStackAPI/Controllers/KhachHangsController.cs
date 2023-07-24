using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FullStackAPI.Data;
using FullStackAPI.Models;
using FullStackAPI.Helpers;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using NuGet.Common;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace FullStackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangsController : ControllerBase
    {
        private readonly FullStackDbContext _context;

        public KhachHangsController(FullStackDbContext context)
        {
            _context = context;
        }

        // Đăng nhập
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] KhachHang khachHang)
        {
            if (khachHang == null)
            {
                return BadRequest();
            }
            var user = await _context.taiKhoans
                .FirstOrDefaultAsync(x => x.Email == khachHang.Email);
            if (user == null)
            {
                return NotFound(new { Message = "Không Có Tài Khoản!" });
            }
            if(!PasswordHasher.VerifyPassword(khachHang.MatKhau, user.MatKhau))
            {
                return BadRequest(new { Message = "Sai thông tin đăng nhập!" });
            }

            user.Token = CreateJwt(user);

            return Ok(new
            {
                Token= user.Token,
                Message = "Đăng nhập thành công!"
            });
        }

        //Đăng ký khách hàng
        [HttpPost]
        public async Task<ActionResult<TaiKhoan>> CreateKhachHang(KhachHang khachHang)
        {
            if (_context.khachHangs == null)
            {
                return Problem("Entity set 'FullStackDbContext.taiKhoans'  is null.");
            }
            var existingAccount = await _context.khachHangs.FirstOrDefaultAsync(x => x.Email == khachHang.Email);
            if (existingAccount != null)
            {
                return BadRequest("Khách hàng đã tồn tại !");
            }

            string mkMaHoa = PasswordHasher.HashPassword(khachHang.MatKhau);
            khachHang.MatKhau = mkMaHoa;
            khachHang.taiKhoan.MatKhau = mkMaHoa;
            //khachHang.Token = "";
            
            _context.khachHangs.Add(khachHang);
            await _context.SaveChangesAsync();

            return Ok(khachHang);
        }





        // Tao 1 Token cua chinh minh
        private string CreateJwt(TaiKhoan user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("khoabimatkhoabimat...");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role, user.TenCV),
                new Claim(ClaimTypes.Name, user.HoTen)
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }

        private string CreateRefreshToken()
        {
            var tokenBytes = RandomNumberGenerator.GetBytes(64);
            var refreshToken = Convert.ToBase64String(tokenBytes);

            //var tokenInUser = _context.Users
            //    .Any(a => a.RefreshToken == refreshToken);
            //if (tokenInUser)
            //{
            //    return CreateRefreshToken();
            //}
            return refreshToken;
        }

        private ClaimsPrincipal GetPrincipleFromExpiredToken(string token)
        {
            var key = Encoding.ASCII.GetBytes("khoabimat...");
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateLifetime = false
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("This is Invalid Token");
            return principal;

        }

    }
}
