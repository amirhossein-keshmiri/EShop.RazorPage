using EShop.RazorPage.Infrastructure.RazorUtils;
using EShop.RazorPage.Infrastructure.Utils.CustomValidation.IFormFile;
using EShop.RazorPage.Models.Sliders;
using EShop.RazorPage.Services.Sliders;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EShop.RazorPage.Pages.Admin.Sliders;

[BindProperties]
public class AddModel : BaseRazorPage
{
    private readonly ISliderService _sliderService;

    public AddModel(ISliderService sliderService)
    {
        _sliderService = sliderService;
    }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Title { get; set; }

    [Display(Name = "لینک")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [DataType(DataType.Url)]
    public string Link { get; set; }

    [Display(Name = "عکس اسلایدر")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [FileImage(ErrorMessage = "عکس نامعتبر است")]
    public IFormFile ImageFile { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        var result = await _sliderService.CreateSlider(new CreateSliderCommand()
        {
            ImageFile = ImageFile,
            Link = Link,
            Title = Title
        });
        return RedirectAndShowAlert(result, RedirectToPage("Index"));
    }
}

