using EShop.RazorPage.Services.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EShop.RazorPage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IAuthService _authService;

        public IndexModel(ILogger<IndexModel> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        public async Task OnGet()
        {
        }
    }
}