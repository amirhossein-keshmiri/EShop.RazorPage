﻿using EShop.RazorPage.Models.Categories;

namespace EShop.RazorPage.Models.Products;
public class ProductShopResult : BaseFilter<ProductShopDto, ProductShopFilterParam>
{
    public CategoryDto? CategoryDto { get; set; }
}
public class ProductShopDto : BaseDto
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public long InventoryId { get; set; }
    public int Price { get; set; }
    public int DiscountPercentage { get; set; }
    public string ImageName { get; set; }
    public int TotalPrice { get; set; }
}
public class ProductShopFilterParam : BaseFilterParam
{
    public string? CategorySlug { get; set; } = "";
    public string? Search { get; set; } = "";
    public bool OnlyAvailableProducts { get; set; } = false;
    public bool? JustHasDiscount { get; set; } = false;
    public ProductSearchOrderBy SearchOrderBy { get; set; } = ProductSearchOrderBy.Cheapest;
}

public enum ProductSearchOrderBy
{
    Latest,
    Expensive,
    Cheapest,
}

