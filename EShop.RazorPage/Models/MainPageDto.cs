using EShop.RazorPage.Models.Banners;
using EShop.RazorPage.Models.Products;
using EShop.RazorPage.Models.Sliders;

namespace EShop.RazorPage.Models;
public class MainPageDto
{
    public List<SliderDto> Sliders { get; set; }
    public List<BannerDto> Banners { get; set; }
    public List<ProductShopDto> SpectialProducts { get; set; }
    public List<ProductShopDto> LatestProducts { get; set; }
    public List<ProductShopDto> TopVisitProducts { get; set; }
}

