using EShop.RazorPage.Models.Products.Commands;
using EShop.RazorPage.Models;
using System.Threading.Tasks;
using EShop.RazorPage.Models.Products;

namespace EShop.RazorPage.Services.Products;
public interface IProductService
{
    Task<ApiResult> CreateProduct(CreateProductCommand command);
    Task<ApiResult> EditProduct(EditProductCommand command);
    Task<ApiResult> AddImage(AddProductImageCommand command);
    Task<ApiResult> DeleteProductImage(DeleteProductImageCommand command);

    Task<ProductDto?> GetProductById(long productId);
    Task<ProductDto?> GetProductBySlug(string slug);
    Task<SingleProductDto?> GetSingleProduct(string slug);
    Task<ProductFilterResult> GetProductByFilter(ProductFilterParams filterParams);
    Task<ProductShopResult> GetProductForShop(ProductShopFilterParam filterParams);
}

