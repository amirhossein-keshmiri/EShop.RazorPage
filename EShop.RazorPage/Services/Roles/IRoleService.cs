using EShop.RazorPage.Models.Roles;
using EShop.RazorPage.Models;

namespace EShop.RazorPage.Services.Roles;
public interface IRoleService
{
    Task<ApiResult> CreateRole(CreateRoleCommand command);
    Task<ApiResult> EditRole(EditRoleCommand command);
    Task<ApiResult> DeleteRole(long roleId);

    Task<RoleDto> GetRoleById(long roleId);
    Task<List<RoleDto>> GetRoles();
}

