namespace EShop.RazorPage.Models.Categories;
public class CreateCategoryCommand
{
    public string Slug { get; set; }
    public string Title { get; set; }
    public SeoData SeoData { get; set; }
}

