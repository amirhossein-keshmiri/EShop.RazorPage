using EShop.RazorPage.Infrastructure.RazorUtils;
using EShop.RazorPage.Infrastructure.Utils.CustomValidation.IFormFile;
using EShop.RazorPage.Models.Products;
using EShop.RazorPage.Models.Products.Commands;
using EShop.RazorPage.Services.Products;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EShop.RazorPage.Pages.Admin.Products.Galleries;


public class IndexModel : BaseRazorPage
{
    private IProductService _productService;

    public IndexModel(IProductService productService)
    {
        _productService = productService;
    }

    public List<ProductImageDto> Images { get; set; }

    [Display(Name = "عکس محصول")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [FileImage(ErrorMessage = "عکس نامعتبر است")]
    [BindProperty]
    public IFormFile ImageFile { get; set; }

    [Display(Name = "ترتیب نمایش")]
    [BindProperty]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public int Sequence { get; set; }

    public async Task<IActionResult> OnGet(long productId)
    {
        var product = await _productService.GetProductById(productId);
        if (product == null)
            return RedirectToPage("Index");

        Images = product.Images;
        return Page();
    }

    public async Task<IActionResult> OnPost(long productId)
    {
        return await AjaxTryCatch(() =>
        {
            return _productService.AddImage(new AddProductImageCommand()
            {
                ProductId = productId,
                ImageFile = ImageFile,
                Sequence = Sequence
            });
        });
    }
    public async Task<IActionResult> OnPostDeleteItem(long productId, long id)
    {
        return await AjaxTryCatch(()
            => _productService.DeleteProductImage(new DeleteProductImageCommand()
            { ProductId = productId, ImageId = id }), checkModelState: false);
    }
}

