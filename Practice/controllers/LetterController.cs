using Microsoft.AspNetCore.Mvc;
using Practice.Data;
using Practice.Models;
using System.Threading.Tasks;
using System.Linq;  // Не забудь добавить этот using для работы с LINQ

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

            // Получаем последнего зарегистрированного пользователя
            var lastUser = _context.UserProfiles.OrderByDescending(u => u.Id).FirstOrDefault();
            if (lastUser != null)
            {
                letter.User = $"{lastUser.Name} {lastUser.Surname}";  // Или укажи нужное поле
            }
            else
            {
                return BadRequest(new { success = false, message = "Нет зарегистрированных пользователей." });
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
