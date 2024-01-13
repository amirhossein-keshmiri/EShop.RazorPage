using EShop.RazorPage.Infrastructure;
using EShop.RazorPage.Infrastructure.Utils;
using EShop.RazorPage.Models;
using EShop.RazorPage.Services.Auth;
using EShop.RazorPage.Services.MainPage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace EShop.RazorPage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IAuthService _authService;
        private readonly IMainPageService _mainPageService;
        private readonly IMemoryCache _memoryCache;
        private readonly IDistributedCache _distributedCache;

        public IndexModel(ILogger<IndexModel> logger, IAuthService authService,
            IMainPageService mainPageService, IMemoryCache memoryCache, 
            IDistributedCache distributedCache)
        {
            _logger = logger;
            _authService = authService;
            _mainPageService = mainPageService;
            _memoryCache = memoryCache;
            _distributedCache = distributedCache;
        }

        public MainPageDto MainPageData { get; set; }
        public async Task OnGet()
        {
            MainPageData = await _distributedCache.GetOrSet(CacheKeys.HomePage, () =>
            {
                return _mainPageService.GetMainPageData();
            }, new CacheOptions()
            {
                AbsoluteExpirationCacheFromMinutes = 15,
                ExpireSlidingCacheFromMinutes = 5
            });

            //MainPageData = await _memoryCache.GetOrCreateAsync(CacheKeys.HomePage, (entry) =>
            //{
            //    entry.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(15);
            //    entry.SlidingExpiration = TimeSpan.FromMinutes(5);
            //    return _mainPageService.GetMainPageData();
            //});
        }
    }
}