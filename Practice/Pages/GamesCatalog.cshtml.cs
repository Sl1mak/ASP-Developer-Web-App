using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Practice.Pages
{
    public class GamesPageModel : PageModel
    {
        private readonly ILogger<GamesPageModel> _logger;

        public GamesPageModel(ILogger<GamesPageModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
