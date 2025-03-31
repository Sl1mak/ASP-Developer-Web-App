using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practice.Data;
using Practice.Models;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    [Route("Profile")]
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("Save")]
        public async Task<IActionResult> SaveProfile([FromBody] UserProfile model)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Login))
            {
                return BadRequest(new { success = false, message = "Некорректные данные" });
            }

            var existingUser = await _context.UserProfiles
                .FirstOrDefaultAsync(u => u.Email == model.Email || u.Login == model.Login);

            if (existingUser != null)
            {
                return BadRequest(new { success = false, message = "Пользователь уже существует" });
            }

            _context.UserProfiles.Add(model);
            var result = await _context.SaveChangesAsync();

            if (result == 0)
            {
                return StatusCode(500, new { success = false, message = "Ошибка сохранения в БД" });
            }

            return Ok(new { success = true });
        }
    }
}
