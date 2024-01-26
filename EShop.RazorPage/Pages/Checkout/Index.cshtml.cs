using EShop.RazorPage.Infrastructure.RazorUtils;
using EShop.RazorPage.Models.Orders;
using EShop.RazorPage.Models.ShippingMethods;
using EShop.RazorPage.Models.UserAddress;
using EShop.RazorPage.Services.Orders;
using EShop.RazorPage.Services.ShippingMethods;
using EShop.RazorPage.Services.UserAddresses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EShop.RazorPage.Pages.Checkout;
public class IndexModel : BaseRazorPage
{
    private IOrderService _orderService;
    private IUserAddressService _userAddressService;
    private IShippingMethodService _shippingMethodService;
    public IndexModel(IOrderService orderService, IUserAddressService userAddressService, 
        IShippingMethodService shippingMethodService)
    {
        _orderService = orderService;
        _userAddressService = userAddressService;
        _shippingMethodService = shippingMethodService;
    }

    public List<AddressDto> Addresses { get; set; }
    public OrderDto Order { get; set; }
    public List<ShippingMethodDto> ShippingMethods { get; set; }

    public async Task<IActionResult> OnGet()
    {
        var order = await _orderService.GetCurrentOrder();
        if (order == null)
            return RedirectToPage("../Index");

        Order = order;
        Addresses = await _userAddressService.GetUserAddresses();

        ShippingMethods = await _shippingMethodService.GetShippingMethods();
        if (ShippingMethods.Any() == false)
            return RedirectToPage("../Index");

        return Page();
    }
}

