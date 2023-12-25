using EShop.RazorPage.Models.Sliders;
using EShop.RazorPage.Models;

namespace EShop.RazorPage.Services.Sliders;
public interface ISliderService
{
    Task<ApiResult> CreateSlider(CreateSliderCommand command);
    Task<ApiResult> EditSlider(EditSliderCommand command);
    Task<ApiResult> DeleteSlider(long sliderId);

    Task<SliderDto?> GetSliderById(long sliderId);
    Task<List<SliderDto>> GetSliders();
}

