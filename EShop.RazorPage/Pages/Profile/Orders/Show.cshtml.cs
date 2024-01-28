using EShop.RazorPage.Infrastructure;
using EShop.RazorPage.Models.Orders;
using EShop.RazorPage.Services.Orders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EShop.RazorPage.Pages.Profile.Orders;
public class ShowModel : PageModel
{
    private IOrderService _orderService;

    public ShowModel(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public OrderDto Order { get; set; }
    public async Task<IActionResult> OnGet(long id)
    {
        var order = await _orderService.GetOrderById(id);
        if (order == null || order.UserId != User.GetUserId())
            return RedirectToPage("Index");

        Order = order;
        return Page();
    }
}

