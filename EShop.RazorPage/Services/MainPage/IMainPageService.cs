using EShop.RazorPage.Models;

namespace EShop.RazorPage.Services.MainPage;
public interface IMainPageService
{
    Task<MainPageDto> GetMainPageData();
}

