using Microsoft.AspNetCore.Mvc;
using Practice.Data;
using Practice;

namespace Practice.Controllers
{
    public class GameController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GameController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Метод для отображения страницы игры по ID
        [Route("Game/Details/{id}")]
        public IActionResult Details(int id)
        {
            // Ищем игру по ID
            var game = _context.Games.FirstOrDefault(g => g.Id == id);
            if (game == null)
            {
                return NotFound(); // Если игра не найдена, вернуть 404
            }

            return View(game); // Передаем игру в представление
        }
    }
}
