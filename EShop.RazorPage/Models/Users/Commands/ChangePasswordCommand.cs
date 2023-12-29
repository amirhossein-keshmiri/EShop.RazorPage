namespace EShop.RazorPage.Models.Users.Commands;
public class ChangePasswordCommand
{
    public string CurrentPassword { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}

