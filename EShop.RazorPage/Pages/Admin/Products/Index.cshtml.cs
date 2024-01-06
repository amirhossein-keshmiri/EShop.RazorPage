using EShop.RazorPage.Infrastructure.RazorUtils;
using EShop.RazorPage.Models.Products;
using EShop.RazorPage.Services.Categories;
using EShop.RazorPage.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace EShop.RazorPage.Pages.Admin.Products;
public class IndexModel : BaseRazorFilter<ProductFilterParams>
{
    private IProductService _productService;
    private readonly ICategoryService _categoryService;
    public IndexModel(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    public ProductFilterResult FilterResult { get; set; }
    public async Task OnGet()
    {
        FilterResult = await _productService.GetProductByFilter(FilterParams);
    }

    public async Task<IActionResult> OnGetLoadChildCategories(long parentId)
    {
        var options = "<option value='0'>انتخاب کنید</option>";
        var child = await _categoryService.GetChild(parentId);
        child.ForEach(f =>
        {
            options += $"<option value='{f.Id}'>{f.Title}</option>";
        });
        return Content(options.Trim());
    }
}

