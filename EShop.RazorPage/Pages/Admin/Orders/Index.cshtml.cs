using EShop.RazorPage.Infrastructure.RazorUtils;
using EShop.RazorPage.Infrastructure.Utils;
using EShop.RazorPage.Models.Orders;
using EShop.RazorPage.Services.Orders;

namespace EShop.RazorPage.Pages.Admin.Orders;

public class IndexModel : BaseRazorFilter<OrderFilterParams>
{
    private IOrderService _orderService;

    public IndexModel(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public OrderFilterResult FilterResult { get; set; }
    public async Task OnGet(string? startDate, string? endDate)
    {
        if (string.IsNullOrWhiteSpace(startDate) == false)
            FilterParams.StartDate = startDate.ToMiladi();


        if (string.IsNullOrWhiteSpace(endDate) == false)
            FilterParams.StartDate = endDate.ToMiladi();

        FilterParams.Take = 1;
        FilterResult = await _orderService.GetOrders(FilterParams);
    }
}

