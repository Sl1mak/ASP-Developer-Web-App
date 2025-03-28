using Microsoft.AspNetCore.Mvc;
using Practice.Data;
using System.Threading.Tasks;
using Practice.Data;
using Practice.Models;

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
            if (model == null) return BadRequest(new { success = false });

            _context.UserProfiles.Add(model);
            await _context.SaveChangesAsync();

            return Ok(new { success = true });
        }
    }
}
