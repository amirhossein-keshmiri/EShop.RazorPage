using EShop.RazorPage.Infrastructure;
using EShop.RazorPage.Infrastructure.RazorUtils;
using EShop.RazorPage.Models.Orders;
using EShop.RazorPage.Models.Orders.Command;
using EShop.RazorPage.Models.ShippingMethods;
using EShop.RazorPage.Models.Transactions;
using EShop.RazorPage.Models.UserAddress;
using EShop.RazorPage.Services.Orders;
using EShop.RazorPage.Services.ShippingMethods;
using EShop.RazorPage.Services.Transactions;
using EShop.RazorPage.Services.UserAddresses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EShop.RazorPage.Pages.Checkout;
public class IndexModel : BaseRazorPage
{
    private readonly IOrderService _orderService;
    private readonly IUserAddressService _userAddressService;
    private readonly IShippingMethodService _shippingMethodService;
    private readonly ITransactionService _transactionService;
    public IndexModel(IOrderService orderService, IUserAddressService userAddressService,
        IShippingMethodService shippingMethodService, ITransactionService transactionService)
    {
        _orderService = orderService;
        _userAddressService = userAddressService;
        _shippingMethodService = shippingMethodService;
        _transactionService = transactionService;
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
    public async Task<IActionResult> OnPost(long shippingMethodId)
    {
        var address = await _userAddressService.GetUserAddresses();
        var currentAddress = address.FirstOrDefault(f => f.ActiveAddress);
        if (currentAddress == null)
        {
            return RedirectToPage("Index");
        }

        var result = await _orderService.CheckoutOrder(new CheckOutOrderCommand
        {
            UserId = User.GetUserId(),
            State = currentAddress.State,
            City = currentAddress.City,
            PostalCode = currentAddress.PostalCode,
            PostalAddress = currentAddress.PostalAddress,
            PhoneNumber = currentAddress.PhoneNumber,
            Name = currentAddress.Name,
            Family = currentAddress.Family,
            NationalCode = currentAddress.NationalCode,
            ShippingMethodId = shippingMethodId,

        });
        if (result.IsSuccess)
        {
            var currentOrder = await _orderService.GetCurrentOrder();
            var res = await _transactionService.CreateTransaction(new CreateTransactionCommand()
            {
                ErrorCallBackUrl =
                    $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/checkout/finallyOrder/{currentOrder.Id}",
                SuccessCallBackUrl =
                    $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/checkout/finallyOrder/{currentOrder.Id}",
                OrderId = currentOrder.Id
            });
            if (res.IsSuccess)
            {
                return Redirect(res.Data);
            }
        }

        ErrorAlert(result.MetaData.Message);
        return RedirectToPage("Index");

    }
}

