using EShop.RazorPage.Infrastructure;
using EShop.RazorPage.Infrastructure.RazorUtils;
using EShop.RazorPage.Models;
using EShop.RazorPage.Models.Orders;
using EShop.RazorPage.Models.Orders.Command;
using EShop.RazorPage.Services.Orders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EShop.RazorPage.Pages;
public class ShopCartModel : BaseRazorPage
{
    private readonly IOrderService _orderService;

    public ShopCartModel(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public OrderDto? OrderDto { get; set; }
    public async Task OnGet()
    {
        if (User.Identity.IsAuthenticated)
        {
            OrderDto = await _orderService.GetCurrentOrder();
        }
        else
        {
            //cookie
        }
    }

    public async Task<IActionResult> OnPostDeleteItem(long id)
    {
        if (User.Identity.IsAuthenticated)
        {
            return await AjaxTryCatch(() => _orderService.DeleteOrderItem(new DeleteOrderItemCommand()
            {
                OrderItemId = id
            }));
        }
        else
        {
            //cookie
            return Page();
        }
    }
    public async Task<IActionResult> OnPostAddItem(long inventoryId, int count)
    {
        if (User.Identity.IsAuthenticated)
        {
            return await AjaxTryCatch(() => _orderService.AddOrderItem(new AddOrderItemCommand()
            {
                UserId = User.GetUserId(),
                InventoryId = inventoryId,
                Count = count
            }));
        }
        else
        {
            //cookie
            return Page();
        }
    }
    public async Task<IActionResult> OnPostIncreaseItemCount(long id)
    {
        if (User.Identity.IsAuthenticated)
        {
            return await AjaxTryCatch(() => _orderService.IncreaseOrderItem(new IncreaseOrderItemCountCommand()
            {
                Count = 1,
                UserId = User.GetUserId(),
                ItemId = id

            }));
        }
        else
        {
            return Page();
        }
    }
    public async Task<IActionResult> OnPostDecreaseItemCount(long id)
    {
        if (User.Identity.IsAuthenticated)
        {
            return await AjaxTryCatch(() => _orderService.DecreaseOrderItem(new DecreaseOrderItemCountCommand()
            {
                Count = 1,
                UserId = User.GetUserId(),
                ItemId = id
            }));
        }
        else
        {
            return Page();
        }
    }
}

