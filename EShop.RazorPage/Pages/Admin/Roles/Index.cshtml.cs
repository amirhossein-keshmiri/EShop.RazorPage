using EShop.RazorPage.Infrastructure.RazorUtils;
using EShop.RazorPage.Models.Roles;
using EShop.RazorPage.Services.Roles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EShop.RazorPage.Pages.Admin.Roles;

[BindProperties]
public class IndexModel : BaseRazorPage
{
    private IRoleService _roleService;

    public IndexModel(IRoleService roleService)
    {
        _roleService = roleService;
    }
    public List<RoleDto> Roles { get; set; }
    public async Task OnGet()
    {
        Roles = await _roleService.GetRoles();
    }

    public async Task<IActionResult> OnPostDelete(long roleId)
    {
        return await AjaxTryCatch(() => _roleService.DeleteRole(roleId));
    }
}

