using EShop.RazorPage.Infrastructure.Utils.CustomValidation.IFormFile;
using System.ComponentModel.DataAnnotations;

namespace EShop.RazorPage.Models.Users.Commands;

public class EditUserCommand
{
    public long UserId { get; set; }

    [Display(Name = "نام")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Name { get; set; }

    [Display(Name = "نام خانوادگی")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Family { get; set; }

    [Display(Name = "تلفن")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [MaxLength(11, ErrorMessage = "شماره تلفن نامعتبر است")]
    [MinLength(11, ErrorMessage = "شماره تلفن نامعتبر است")]
    public string PhoneNumber { get; set; }

    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Display(Name = "عکس پروفایل")]
    [FileImage(ErrorMessage = "تصویر پروفایل نامعتبر است")]
    public IFormFile? Avatar { get; set; }

    [Display(Name = "جنسیت")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public Gender Gender { get; set; }
}

