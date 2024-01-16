using EShop.RazorPage.Infrastructure;
using EShop.RazorPage.Models;
using EShop.RazorPage.Models.Comments;

namespace EShop.RazorPage.Services.Comments;
public class CommentService : ICommentService
{
    private readonly HttpClient _client;

    public CommentService(HttpClient client)
    {
        _client = client;
    }
    public async Task<ApiResult> AddComment(AddCommentCommand command)
    {
        var result = await _client.PostAsJsonAsync("comment", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> EditComment(EditCommentCommand command)
    {
        var result = await _client.PutAsJsonAsync("comment", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> ChangeStatus(long commentId, CommentStatus status)
    {
        var result = await _client.PutAsJsonAsync("comment/changeStatus", new { id = commentId, status });
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult> DeleteComment(long commentId)
    {
        var content = await _client.DeleteAsync($"comment/{commentId}");
        return await content.Content.ReadFromJsonAsync<ApiResult>();
    }



    public async Task<CommentDto?> GetCommentById(long id)
    {
        var result = await _client.GetFromJsonAsync<ApiResult<CommentDto>>($"comment/{id}");
        return result?.Data;
    }

    public async Task<CommentFilterResult> GetCommentsByFilter(CommentFilterParams filterParams)
    {
        var url = filterParams.GenerateBaseFilterUrl("comment");
        if (filterParams.UserId != null)
            url += $"&UserId={filterParams.UserId}";

        if (filterParams.CommentStatus != null)
            url += $"&CommentStatus={filterParams.CommentStatus}";

        if (filterParams.StartDate != null)
            url += $"&StartDate{filterParams.StartDate}";

        if (filterParams.EndDate != null)
            url += $"&EndDate{filterParams.EndDate}";

        var result = await _client.GetFromJsonAsync<ApiResult<CommentFilterResult>>(url);
        return result?.Data;
    }

    public async Task<CommentFilterResult> GetProductComments(int pageId, int take, long productId)
    {
        var url = $"comment/productComments?pageId={pageId}&take={take}&productId={productId}";
        var result = await _client.GetFromJsonAsync<ApiResult<CommentFilterResult>>(url);
        return result?.Data;
    }
}

