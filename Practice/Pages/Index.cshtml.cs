using Microsoft.AspNetCore.Mvc.RazorPages;
using Practice.Data;
using Practice;  // ���������� ������ Game
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

        // ��������� �������� ��� ������ ���
        public List<Game> Game { get; set; }

        // ����� OnGet ��� ��������� ������
        public void OnGet()
        {
            // ��������� ��� ���� �� ���� ������
            Game = _context.Games.ToList();  // �������� ��� ���� �� ���� ������
        }
    }
}
