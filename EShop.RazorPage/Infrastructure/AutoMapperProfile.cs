using AutoMapper;
using EShop.RazorPage.Models.UserAddress;
using EShop.RazorPage.ViewModels.Users.Addresses;

namespace EShop.RazorPage.Infrastructure;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CreateUserAddressCommand, CreateUserAddressViewModel>().ReverseMap();

        CreateMap<AddressDto, EditUserAddressViewModel>().ReverseMap();

        CreateMap<EditUserAddressViewModel, EditUserAddressCommand>().ReverseMap();
    }
}

