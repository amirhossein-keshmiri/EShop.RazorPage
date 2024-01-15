using EShop.RazorPage.Models.Sellers;

namespace EShop.RazorPage.Models.Products;
public class SingleProductDto
{
    public ProductDto ProductDto { get; set; }
    public List<InventoryDto> Inventories { get; set; }
}

