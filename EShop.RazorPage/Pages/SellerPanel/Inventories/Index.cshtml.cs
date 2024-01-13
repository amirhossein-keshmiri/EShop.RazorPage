using EShop.RazorPage.Infrastructure.RazorUtils;
using EShop.RazorPage.Models;
using EShop.RazorPage.Models.Sellers;
using EShop.RazorPage.Models.Sellers.Commands;
using EShop.RazorPage.Services.Sellers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace EShop.RazorPage.Pages.SellerPanel.Inventories;

public class IndexModel : BaseRazorPage 
{
    private ISellerService _sellerService;
    private IRenderViewToString _renderViewToString;
    private readonly IMemoryCache _memoryCache;
    public IndexModel(ISellerService sellerService, IRenderViewToString renderViewToString, 
        IMemoryCache memoryCache)
    {
        _sellerService = sellerService;
        _renderViewToString = renderViewToString;
        _memoryCache = memoryCache;
    }

    public List<InventoryDto> Inventories { get; set; }
    public async Task<IActionResult> OnGet()
    {
        var seller = await _sellerService.GetCurrentSeller();
        if (seller == null)
            return Redirect("/");

        Inventories = await _sellerService.GetSellerInventories();
        return Page();
    }

    public async Task<IActionResult> OnGetEditPage(long id)
    {
        return await AjaxTryCatch(async () =>
        {
            var inventory = await _sellerService.GetInventoryById(id);
            if (inventory == null)
                return ApiResult<string>.Success("اطلاعات نامعتبر است");
            var view = await _renderViewToString.RenderToStringAsync("_Edit", new EditSellerInventoryCommand
            {
                SellerId = inventory.SellerId,
                InventoryId = inventory.Id,
                Count = inventory.Count,
                Price = inventory.Price,
                DiscountPercentage = inventory.DiscountPercentage
            }, PageContext);
            return ApiResult<string>.Success(view);
        });
    }

    public async Task<IActionResult> OnPost(EditSellerInventoryCommand command)
    {
        //_memoryCache.Remove("main-page");
        return await AjaxTryCatch(() => _sellerService.EditInventory(command));
    }
}

