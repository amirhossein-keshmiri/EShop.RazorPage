using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EShop.RazorPage.Models.Users.Commands;
public class CreateUserCommand
{
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

    [Display(Name = "کلمه عبور")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "جنسیت")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public Gender Gender { get; set; }
}

