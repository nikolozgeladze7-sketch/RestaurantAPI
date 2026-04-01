using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Data;
using System.Text;
using RestaurantAPI.Model.DTO;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly RestaurantDbContext context;

        public AuthController(RestaurantDbContext context)
        {
            this.context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto dto)
        {

            if (await context.Users.AnyAsync(u => u.Email == dto.Email))
            {
                return BadRequest("Email already exists");
            }

            var passwordHash = HashPassword(dto.Password);

            var user = new IdentityUser
            {
                UserName = dto.Name,
                Email = dto.Email,
                PasswordHash = passwordHash
            };

            context.Users.Add(user);
            await context.SaveChangesAsync();

            return Ok(new { message = "User registered successfully" });
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (user == null)
            {
                return Unauthorized("Invalid email or password");
            }

            var hashedPassword = HashPassword(dto.Password);

            if (user.PasswordHash != hashedPassword)
            {
                return Unauthorized("Invalid email or password");
            }

            return Ok(new
            {
                message = "Login successful",
                user = new
                {
                    user.Id,
                    user.UserName,
                    user.Email
                }
            });
        }
    }
}
