using EShop.RazorPage.Models.UserAddress;
using EShop.RazorPage.Models;

namespace EShop.RazorPage.Services.UserAddresses;
public interface IUserAddressService
{
    Task<ApiResult> CreateAddress(CreateUserAddressCommand command);
    Task<ApiResult> EditAddress(EditUserAddressCommand command);
    Task<ApiResult> DeleteAddress(long addressId);

    Task<AddressDto?> GetAddressById(long id);
    Task<List<AddressDto>> GetUserAddresses();
}

