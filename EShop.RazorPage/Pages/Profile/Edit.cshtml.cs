using EShop.RazorPage.Infrastructure.RazorUtils;
using EShop.RazorPage.Infrastructure.Utils.CustomValidation.IFormFile;
using EShop.RazorPage.Models.Users;
using EShop.RazorPage.Models.Users.Commands;
using EShop.RazorPage.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EShop.RazorPage.Pages.Profile;

[BindProperties]
[Authorize]
public class EditModel : BaseRazorPage
{
    private readonly IUserService _userService;

    public EditModel(IUserService userService)
    {
        _userService = userService;
    }

    [Display(Name = "عکس پروفایل")]
    [FileImage(ErrorMessage = "تصویر پروفایل نامعتبر است")]
    public IFormFile? Avatar { get; set; }

    [Display(Name = "نام")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Name { get; set; }

    [Display(Name = "نام خانوادگی")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Family { get; set; }

    [Display(Name = "شماره تلفن")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [MaxLength(11, ErrorMessage = "شماره تلفن نامعتبر است")]
    [MinLength(11, ErrorMessage = "شماره تلفن نامعتبر است")]
    public string PhoneNumber { get; set; }

    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Email { get; set; }

    public Gender Gender { get; set; } = Gender.None;
    public async Task OnGet()
    {
        var user = await _userService.GetCurrentUser();
        Name = user.Name;
        Family = user.Family;
        PhoneNumber = user.PhoneNumber;
        Email = user.Email;
        Gender = user.Gender;

    }

    public async Task<IActionResult> OnPost()
    {

        var result = await _userService.EditUserCurrent(new EditUserCommand()
        {
            PhoneNumber = PhoneNumber,
            Family = Family,
            Email = Email,
            Gender = Gender,
            Name = Name,
            Avatar = Avatar
        });

        return RedirectAndShowAlert(result, RedirectToPage("Index"));
    }
}

