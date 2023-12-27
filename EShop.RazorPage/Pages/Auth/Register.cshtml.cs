using EShop.RazorPage.Infrastructure.RazorUtils;
using EShop.RazorPage.Models.Auth;
using EShop.RazorPage.Services.Auth;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EShop.RazorPage.Pages.Auth
{
    [BindProperties]
    [ValidateAntiForgeryToken]
    public class RegisterModel : BaseRazorPage
    {
        private readonly IAuthService _authService;

        public RegisterModel(IAuthService authService)
        {
            _authService = authService;
        }

        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string PhoneNumber { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MinLength(5, ErrorMessage = "کلمه عبور باید بزرگتر ار 5 کاراکتر باشد")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "تکرار کلمه عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [Compare("Password", ErrorMessage = "کلمه های عبورر یکسان نیستند")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var result = await _authService.Register(new RegisterCommand()
            {
                PhoneNumber = PhoneNumber,
                Password = Password,
                ConfirmPassword = ConfirmPassword
            });

            return RedirectAndShowAlert(result, RedirectToPage("Login"));
        }
    }
}
