using EShop.RazorPage.Infrastructure.RazorUtils;
using EShop.RazorPage.Models.Products;
using EShop.RazorPage.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace EShop.RazorPage.Pages;
public class ProductModel : BaseRazorPage
{
    private readonly IProductService _service;

    public ProductModel(IProductService service)
    {
        _service = service;
    }

    public SingleProductDto ProductPageModel { get; set; }
    public async Task<IActionResult> OnGet(string slug)
    {
        var product = await _service.GetSingleProduct(slug);
        if (product == null)
            return NotFound();

        ProductPageModel = product;
        return Page();
    }

}

