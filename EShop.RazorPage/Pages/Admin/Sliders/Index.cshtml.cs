using EShop.RazorPage.Infrastructure.RazorUtils;
using EShop.RazorPage.Models.Sliders;
using EShop.RazorPage.Services.Sliders;

namespace EShop.RazorPage.Pages.Admin.Sliders;
public class IndexModel : BaseRazorPage
{
    private readonly ISliderService _sliderService;

    public IndexModel(ISliderService sliderService)
    {
        _sliderService = sliderService;
    }
    public List<SliderDto> Sliders { get; set; }
    public async Task OnGet()
    {
        Sliders = await _sliderService.GetSliders();
    }
}

