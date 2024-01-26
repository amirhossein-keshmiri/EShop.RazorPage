using EShop.RazorPage.Models;
using EShop.RazorPage.Models.ShippingMethods;
using EShop.RazorPage.Models.ShippingMethods.Commands;

namespace EShop.RazorPage.Services.ShippingMethods;
public class ShippingMethodService : IShippingMethodService
{
    private readonly HttpClient _client;
    private const string ModuleName = "ShippingMethod";
    public ShippingMethodService(HttpClient client)
    {
        _client = client;
    }
    public async Task<List<ShippingMethodDto>> GetShippingMethods()
    {
        var result = await _client.GetFromJsonAsync<ApiResult<List<ShippingMethodDto>>>($"{ModuleName}");
        return result?.Data ?? new();
    }
    public async Task<ShippingMethodDto> GetShippingMethodById(long shippingId)
    {
        var result = await _client.GetFromJsonAsync<ApiResult<ShippingMethodDto?>>($"{ModuleName}/{shippingId}");
        return result.Data;
    }

    public async Task<ApiResult> CreateShippingMethod(CreateShippingMethodCommand command)
    {
        var result = await _client.PostAsJsonAsync(ModuleName, command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> EditShippingMethod(EditShippingMethodCommand command)
    {
        var result = await _client.PutAsJsonAsync(ModuleName, command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> DeleteShippingMethod(long shippingId)
    {
        var result = await _client.DeleteAsync($"{ModuleName}/{shippingId}");
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

}

