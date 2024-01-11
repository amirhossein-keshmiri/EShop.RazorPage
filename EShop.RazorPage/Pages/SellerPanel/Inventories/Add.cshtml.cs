using EShop.RazorPage.Infrastructure.RazorUtils;
using EShop.RazorPage.Models.Sellers.Commands;
using EShop.RazorPage.Services.Sellers;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EShop.RazorPage.Pages.SellerPanel.Inventories;

[BindProperties]
public class AddModel : BaseRazorPage
{
    private ISellerService _service;

    public AddModel(ISellerService service)
    {
        _service = service;
    }

    public long ProductId { get; set; }

    [Display(Name = "تعداد موجود")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public int Count { get; set; }

    [Display(Name = "مبلغ")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public int Price { get; set; }

    [Display(Name = "درصد تخفیف")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [Range(0, 100, ErrorMessage = "درصد تخفیف نامعتبر است")]
    public int PercentageDiscount { get; set; }

    public void OnGet()
    {
    }
    public async Task<IActionResult> OnPost()
    {
        var seller = await _service.GetCurrentSeller();
        if (seller == null)
            return Redirect("/");

        var result = await _service.AddInventory(new AddSellerInventoryCommand()
        {
            Count = Count,
            PercentageDiscount = PercentageDiscount,
            Price = Price,
            ProductId = ProductId,
            SellerId = seller.Id
        });
        return RedirectAndShowAlert(result, RedirectToPage("Index"));
    }
}

