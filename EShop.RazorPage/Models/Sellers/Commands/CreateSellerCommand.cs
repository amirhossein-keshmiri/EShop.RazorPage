using System.ComponentModel.DataAnnotations;

namespace EShop.RazorPage.Models.Sellers.Commands;
public class CreateSellerCommand
{
    public long UserId { get; set; }

    [Display(Name = "نام فروشگاه")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string ShopName { get; set; }

    [Display(Name = "کدملی فروشنده")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string NationalCode { get; set; }
}

