using EShop.RazorPage.Models.Auth;
using EShop.RazorPage.Models;

namespace EShop.RazorPage.Services.Auth;
public interface IAuthService
{
    Task<ApiResult<LoginResponse>?> Login(LoginCommand command);
    Task<ApiResult?> Register(RegisterCommand command);
    Task<ApiResult<LoginResponse>?> RefreshToken();
    Task<ApiResult?> Logout();
}

