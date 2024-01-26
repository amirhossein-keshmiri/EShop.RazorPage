using EShop.RazorPage.Infrastructure.RazorUtils;
using EShop.RazorPage.Models;
using EShop.RazorPage.Models.ShippingMethods;
using EShop.RazorPage.Models.ShippingMethods.Commands;
using EShop.RazorPage.Services.ShippingMethods;
using Microsoft.AspNetCore.Mvc;

namespace EShop.RazorPage.Pages.Admin.ShippingMethods;
public class IndexModel : BaseRazorPage
{
    private readonly IShippingMethodService _shippingMethodService;
    private readonly IRenderViewToString _renderView;

    public IndexModel(IShippingMethodService shippingMethodService, IRenderViewToString renderView)
    {
        _shippingMethodService = shippingMethodService;
        _renderView = renderView;
    }

    public List<ShippingMethodDto> ShippingMethods { get; set; }
    public async Task OnGet()
    {
        ShippingMethods = await _shippingMethodService.GetShippingMethods();
    }

    public async Task<IActionResult> OnGetRenderAddPage()
    {
        return await AjaxTryCatch(async () =>
        {
            var view = await _renderView.RenderToStringAsync("_Add", new CreateShippingMethodCommand(), PageContext);
            return ApiResult<string>.Success(view);
        });
    }

    public async Task<IActionResult> OnPostCreateShippingMethod(CreateShippingMethodCommand command)
    {
        return await AjaxTryCatch(() =>
            _shippingMethodService.CreateShippingMethod(command));
    }

    public async Task<IActionResult> OnGetRenderEditPage(long id)
    {
        return await AjaxTryCatch(async () =>
        {
            var shippingMethod = await _shippingMethodService.GetShippingMethodById(id);
            if (shippingMethod == null)
                return ApiResult<string>.Error();

            var model = new EditShippingMethodCommand()
            {
                Id = id,
                Title = shippingMethod.Title,
                Cost = shippingMethod.Cost,
            };
            var view = await _renderView.RenderToStringAsync("_Edit", model, PageContext);
            return ApiResult<string>.Success(view);
        });
    }

    public async Task<IActionResult> OnPostEditShippingMethod(EditShippingMethodCommand command)
    {
        return await AjaxTryCatch(() =>
            _shippingMethodService.EditShippingMethod(command));
    }

    public async Task<IActionResult> OnPostDelete(long id)
    {
        return await AjaxTryCatch(() =>
            _shippingMethodService.DeleteShippingMethod(id));
    }
}

