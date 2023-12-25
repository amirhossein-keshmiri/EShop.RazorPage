using EShop.RazorPage.Models.Sellers.Commands;
using EShop.RazorPage.Models;
using EShop.RazorPage.Models.Sellers;

namespace EShop.RazorPage.Services.Sellers;
public interface ISellerService
{
    Task<ApiResult> CreateSeller(CreateSellerCommand command);
    Task<ApiResult> EditSeller(EditSellerCommand command);
    Task<ApiResult> AddInventory(AddSellerInventoryCommand command);
    Task<ApiResult> EditInventory(EditSellerInventoryCommand command);

    Task<SellerDto?> GetSellerById(long sellerId);
    Task<SellerDto?> GetCurrentSeller();
    Task<SellerFilterResult> GetSellersByFilter(SellerFilterParams filterParams);

    Task<InventoryDto?> GetInventoryById(long inventoryId);
    Task<List<InventoryDto>> GetSellerInventories();
}

