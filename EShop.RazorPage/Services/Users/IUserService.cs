using EShop.RazorPage.Models.Users.Commands;
using EShop.RazorPage.Models;
using EShop.RazorPage.Models.Users;

namespace EShop.RazorPage.Services.Users;
public interface IUserService
{
    Task<ApiResult> CreateUser(CreateUserCommand command);
    Task<ApiResult> EditUser(EditUserCommand command);
    Task<ApiResult> EditUserCurrent(EditUserCommand command);

    Task<UserDto?> GetUserById(long userId);
    Task<UserDto?> GetCurrentUser();
    Task<UserFilterResult> GetUsersByFilter(UserFilterParams filterParams);
}

