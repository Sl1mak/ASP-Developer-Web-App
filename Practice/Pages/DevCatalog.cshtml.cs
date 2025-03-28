using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Practice.Pages
{
    public class DevCatalogModel : PageModel
    {
        private readonly ILogger<DevCatalogModel> _logger;

        public DevCatalogModel(ILogger<DevCatalogModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
