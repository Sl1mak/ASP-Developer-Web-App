using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Practice.Pages
{
    public class LetterModel : PageModel
    {
        private readonly ILogger<LetterModel> _logger;

        public LetterModel(ILogger<LetterModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
