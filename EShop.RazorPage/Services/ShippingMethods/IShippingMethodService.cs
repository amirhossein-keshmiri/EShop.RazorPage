using EShop.RazorPage.Models;
using EShop.RazorPage.Models.ShippingMethods;
using EShop.RazorPage.Models.ShippingMethods.Commands;

namespace EShop.RazorPage.Services.ShippingMethods;
public interface IShippingMethodService
{
    Task<ApiResult> CreateShippingMethod(CreateShippingMethodCommand command);
    Task<ApiResult> EditShippingMethod(EditShippingMethodCommand command);
    Task<ApiResult> DeleteShippingMethod(long shippingId);

    Task<List<ShippingMethodDto>> GetShippingMethods();
    Task<ShippingMethodDto> GetShippingMethodById(long shippingId);
}

