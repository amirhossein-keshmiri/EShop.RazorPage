using EShop.RazorPage.Infrastructure.RazorUtils;
using EShop.RazorPage.Models.Products;
using EShop.RazorPage.Services.Categories;
using EShop.RazorPage.Services.Products;

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
}

