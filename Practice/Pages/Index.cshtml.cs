using Microsoft.AspNetCore.Mvc.RazorPages;
using Practice.Data;
using Practice;  // Подключаем модель Game
using System.Collections.Generic;

namespace Practice.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Добавляем свойство для списка игр
        public List<Game> Game { get; set; }

        // Метод OnGet для получения данных
        public void OnGet()
        {
            // Загружаем все игры из базы данных
            Game = _context.Games.ToList();  // Получаем все игры из базы данных
        }
    }
}
