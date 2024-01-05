using EShop.RazorPage.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace EShop.RazorPage.Infrastructure.RazorUtils;
public class BaseRazorFilter<TFilterParam> : PageModel where TFilterParam : BaseFilterParam
{
    [BindProperty(SupportsGet = true)]
    public TFilterParam FilterParams { get; set; }
}

