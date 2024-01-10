using EShop.RazorPage.Infrastructure.RazorUtils;
using EShop.RazorPage.Models.Roles;
using EShop.RazorPage.Models.Users;
using EShop.RazorPage.Models.Users.Commands;
using EShop.RazorPage.Services.Roles;
using EShop.RazorPage.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace EShop.RazorPage.Pages.Admin.Users;

[BindProperties]
public class SetUserRolesModel : BaseRazorPage
{
    private readonly IRoleService _roleService;
    private readonly IUserService _userService;

    public SetUserRolesModel(IRoleService roleService, IUserService userService)
    {
        _roleService = roleService;
        _userService = userService;
    }

    public List<RoleDto> Roles { get; set; }
    public List<UserRoleDto> UserRoles { get; set; }
    public async Task<IActionResult> OnGet(long userId)
    {
        var user = await _userService.GetUserById(userId);
        if (user == null)
            return RedirectToPage("Index");

        Roles = await _roleService.GetRoles();
        UserRoles = user.Roles;
        return Page();
    }

    public async Task<IActionResult> OnPost(long userId, List<long> roles)
    {
        var result = await _userService.SetUserRole(new SetUserRoleCommand()
        {
            Roles = roles,
            UserId = userId

        });
        return RedirectAndShowAlert(result, RedirectToPage("Index"), RedirectToPage("SetUserRoles", new { userId }));
    }
}

