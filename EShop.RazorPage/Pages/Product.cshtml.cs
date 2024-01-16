using EShop.RazorPage.Infrastructure;
using EShop.RazorPage.Infrastructure.RazorUtils;
using EShop.RazorPage.Models.Comments;
using EShop.RazorPage.Models.Products;
using EShop.RazorPage.Services.Comments;
using EShop.RazorPage.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace EShop.RazorPage.Pages;
public class ProductModel : BaseRazorPage
{
    private readonly IProductService _service;
    private readonly ICommentService _commentService;
    public ProductModel(IProductService service, ICommentService commentService)
    {
        _service = service;
        _commentService = commentService;
    }

    public SingleProductDto ProductPageModel { get; set; }
    public async Task<IActionResult> OnGet(string slug)
    {
        var product = await _service.GetSingleProduct(slug);
        if (product == null)
            return NotFound();

        ProductPageModel = product;
        return Page();
    }

    public async Task<IActionResult> OnGetProductComments(long productId, int pageId = 1)
    {
        var commentResult = await _commentService.GetProductComments(pageId, 14, productId);
        return Partial("Shared/Products/_Comments", commentResult);
    }

    public async Task<IActionResult> OnPost(string slug, long productId, string comment)
    {
        if (User.Identity.IsAuthenticated == false)
            return Page();

        var result = await _commentService.AddComment(new AddCommentCommand()
        {
            ProductId = productId,
            Text = comment,
            UserId = User.GetUserId()
        });
        if (result.IsSuccess == false)
        {
            ErrorAlert(result.MetaData.Message);
            return Page();
        }
        SuccessAlert("نظر شما ثبت شد ، بعد از تایید در سایت نمایش داده می شود");
        return RedirectToPage("Product", new { slug });
    }
}

