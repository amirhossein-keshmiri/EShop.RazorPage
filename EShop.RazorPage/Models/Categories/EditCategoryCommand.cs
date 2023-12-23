namespace EShop.RazorPage.Models.Categories;

public class EditCategoryCommand
{
    public long Id { get; set; }
    public string Slug { get; set; }
    public string Title { get; set; }
    public SeoData SeoData { get; set; }
}

