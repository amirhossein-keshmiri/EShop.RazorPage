using EShop.RazorPage.Infrastructure.RazorUtils;
using EShop.RazorPage.Infrastructure.Utils;
using EShop.RazorPage.Models.Roles;
using EShop.RazorPage.Services.Roles;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EShop.RazorPage.Pages.Admin.Roles;

[BindProperties]
public class AddModel : BaseRazorPage
{
    private readonly IRoleService _roleService;

    public AddModel(IRoleService roleService)
    {
        _roleService = roleService;
    }
    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Title { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost(string[] permission)
    {
        var permissionModel = new List<Permission>();
        foreach (var item in permission)
        {
            try
            {
                permissionModel.Add(EnumUtils.ParseEnum<Permission>(item));
            }
            catch
            {
                // 
            }
        }
        var result = await _roleService.CreateRole(new CreateRoleCommand()
        {
            Title = Title,
            Permissions = permissionModel
        });
        return RedirectAndShowAlert(result, RedirectToPage("Index"));
    }
}

