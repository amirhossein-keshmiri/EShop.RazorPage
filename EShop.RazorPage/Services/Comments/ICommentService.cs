using EShop.RazorPage.Models.Comments;
using EShop.RazorPage.Models;

namespace EShop.RazorPage.Services.Comments;
public interface ICommentService
{
    Task<ApiResult> AddComment(AddCommentCommand command);
    Task<ApiResult> EditComment(EditCommentCommand command);
    Task<ApiResult> ChangeStatus(long commentId, CommentStatus status);
    Task<ApiResult> DeleteComment(long commentId);

    Task<CommentFilterResult> GetCommentsByFilter(CommentFilterParams filterParams);
    Task<CommentFilterResult> GetProductComments(int pageId, int take, long productId);
    Task<CommentDto?> GetCommentById(long id);
}

