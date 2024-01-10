using EShop.RazorPage.Models.Roles;

namespace EShop.RazorPage.Models.Users.Commands;
public class SetUserRoleCommand
{
    public long UserId { get; set; }
    public List<long> Roles { get; set; }
}

