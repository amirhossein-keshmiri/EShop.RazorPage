using EShop.RazorPage.Services.Auth;
using EShop.RazorPage.Services.Banners;
using EShop.RazorPage.Services.Categories;
using EShop.RazorPage.Services.Comments;
using EShop.RazorPage.Services.Orders;
using EShop.RazorPage.Services.Products;
using EShop.RazorPage.Services.Roles;
using EShop.RazorPage.Services.Sellers;
using EShop.RazorPage.Services.Sliders;
using EShop.RazorPage.Services.UserAddresses;
using EShop.RazorPage.Services.Users;

namespace EShop.RazorPage.Infrastructure;
public static class RegisterServices
{
    public static IServiceCollection RegisterApiServices(this IServiceCollection services)
    {
        const string baseAddress = "https://localhost:5001";
        services.AddHttpClient<IAuthService, AuthService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        });
        services.AddHttpClient<IBannerService, BannerService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        });
        services.AddHttpClient<ICategoryService, CategoryService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        });
        services.AddHttpClient<ICommentService, CommentService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        });
        services.AddHttpClient<IOrderService, OrderService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        });
        services.AddHttpClient<IProductService, ProductService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        });
        services.AddHttpClient<IRoleService, RoleService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        });
        services.AddHttpClient<ISellerService, SellerService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        });
        services.AddHttpClient<ISliderService, SliderService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        });
        services.AddHttpClient<IUserAddressService, UserAddressService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        });
        services.AddHttpClient<IUserService, UserService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        });


        return services;
    }
}

