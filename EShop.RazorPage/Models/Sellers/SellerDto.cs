namespace EShop.RazorPage.Models.Sellers;
public class SellerDto : BaseDto
{
    public long UserId { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public string PhoneNumber { get; set; }
    public string ShopName { get; set; }
    public string NationalCode { get; set; }
    public SellerStatus Status { get; set; }
}
public enum SellerStatus
{
    New,
    Accepted,
    InActive,
    Rejected
}
public class SellerFilterResult : BaseFilter<SellerDto, SellerFilterParams>
{

}

public class SellerFilterParams : BaseFilterParam
{
    public string? ShopName { get; set; }
    public string? NationalCode { get; set; }
    public SellerStatus? Status { get; set; }
}