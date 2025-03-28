using Microsoft.AspNetCore.Mvc;
using Practice.Data;  // Импортируем контекст базы данных
using Practice.Models;  // Импортируем модель Letter
using System.Threading.Tasks;

namespace Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LetterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        // Внедрение контекста базы данных через DI
        public LetterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/letter
        [HttpPost]
        public async Task<IActionResult> SendLetter([FromBody] Letter letter)
        {
            if (letter == null || string.IsNullOrEmpty(letter.Text))
            {
                return BadRequest(new { success = false, message = "Текст заявки не может быть пустым." });
            }

            // Устанавливаем дату создания заявки
            letter.CreatedAt = DateTime.Now;

            // Сохраняем заявку в базе данных
            _context.Letters.Add(letter);
            await _context.SaveChangesAsync();

            // Возвращаем успешный ответ
            return Ok(new { success = true, message = "Ваша заявка отправлена!" });
        }
    }
}
