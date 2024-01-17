using System.ComponentModel.DataAnnotations;

namespace EShop.RazorPage.Models.Comments;
public class ChangeStatusCommand
{
    public long CommentId { get; set; }

    [Display(Name = "وضعیت کامنت")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public CommentStatus Status { get; set; }
}

