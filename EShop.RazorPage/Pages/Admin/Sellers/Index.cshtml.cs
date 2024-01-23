using EShop.RazorPage.Infrastructure.RazorUtils;
using EShop.RazorPage.Models;
using EShop.RazorPage.Models.Sellers;
using EShop.RazorPage.Models.Sellers.Commands;
using EShop.RazorPage.Services.Sellers;
using Microsoft.AspNetCore.Mvc;

namespace EShop.RazorPage.Pages.Admin.Sellers;
public class IndexModel : BaseRazorFilter<SellerFilterParams>
{
    private readonly ISellerService _sellerService;
    private readonly IRenderViewToString _renderView;

    public IndexModel(ISellerService sellerService, IRenderViewToString renderView)
    {
        _sellerService = sellerService;
        _renderView = renderView;
    }

    public SellerFilterResult FilterResult { get; set; }

    public async Task OnGet()
    {
        FilterResult = await _sellerService.GetSellersByFilter(FilterParams);
    }

    public async Task<IActionResult> OnGetRenderEditPage(long sellerId)
    {
        return await AjaxTryCatch(async () =>
        {
            var seller = await _sellerService.GetSellerById(sellerId);
            if (seller == null)
                return ApiResult<string>.Error();

            var model = new EditSellerCommand()
            {
                Id = seller.Id,
                NationalCode = seller.NationalCode,
                ShopName = seller.ShopName,
                Status = seller.Status
            };
            var view = await _renderView.RenderToStringAsync("_Edit", model, PageContext);
            return ApiResult<string>.Success(view);
        });
    }
    public async Task<IActionResult> OnPostEditSeller(EditSellerCommand command)
    {
        return await AjaxTryCatch(() =>
            _sellerService.EditSeller(new EditSellerCommand()
            {
                Id = command.Id,
                NationalCode = command.NationalCode,
                ShopName = command.ShopName,
                Status = command.Status
            }));
    }
}

