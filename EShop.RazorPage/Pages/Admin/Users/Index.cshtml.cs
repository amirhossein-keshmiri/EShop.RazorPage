using EShop.RazorPage.Infrastructure.RazorUtils;
using EShop.RazorPage.Models;
using EShop.RazorPage.Models.Roles;
using EShop.RazorPage.Models.Users;
using EShop.RazorPage.Models.Users.Commands;
using EShop.RazorPage.Services.Roles;
using EShop.RazorPage.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace EShop.RazorPage.Pages.Admin.Users;
public class IndexModel : BaseRazorFilter<UserFilterParams>
{
    private readonly IUserService _userService;
    private readonly IRoleService _roleService;
    private readonly IRenderViewToString _renderView;

    public IndexModel(IUserService userService, IRenderViewToString renderView, 
        IRoleService roleService)
    {
        _userService = userService;
        _renderView = renderView;
        _roleService = roleService;
    }

    public List<RoleDto> Roles { get; set; }

    public UserFilterResult UserFilterResult { get; set; }

    public async Task OnGet()
    {
        UserFilterResult = await _userService.GetUsersByFilter(FilterParams);
    }

    public async Task<IActionResult> OnGetRenderAddPage()
    {
        return await AjaxTryCatch(async () =>
        {
            var view = await _renderView.RenderToStringAsync("_Add", new CreateUserCommand(), PageContext);
            return ApiResult<string>.Success(view);
        });
    }
    public async Task<IActionResult> OnPostCreateUser(CreateUserCommand command)
    {
        return await AjaxTryCatch(() =>
            _userService.CreateUser(command));
    }

    public async Task<IActionResult> OnGetRenderEditPage(long userId)
    {
        return await AjaxTryCatch(async () =>
        {
            var user = await _userService.GetUserById(userId);
            if (user == null)
                return ApiResult<string>.Error();

            var model = new EditUserCommand()
            {
                UserId = user.Id,
                Name = user.Name,
                Family = user.Family,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Gender = user.Gender
        };
            var view = await _renderView.RenderToStringAsync("_Edit", model, PageContext);
            return ApiResult<string>.Success(view);
        });
    }

    public async Task<IActionResult> OnPostEditUser(EditUserCommand command)
    {
        return await AjaxTryCatch(() =>
            _userService.EditUser(new EditUserCommand()
            {
                UserId = command.UserId,
                PhoneNumber = command.PhoneNumber,
                Family = command.Family,
                Email = command.Email,
                Gender = command.Gender,
                Name = command.Name,
                Avatar = command.Avatar
            }));
    }

    //public async Task<IActionResult> OnGetRenderRolePage(long userId)
    //{
    //    return await AjaxTryCatch(async () =>
    //    {
    //        var user = await _userService.GetUserById(userId);
    //        if (user == null)
    //            return ApiResult<string>.Error();

    //        var view = await _renderView.RenderToStringAsync("_SetRoles", null, PageContext);
    //        return ApiResult<string>.Success(view);
    //    });
    //}

}

