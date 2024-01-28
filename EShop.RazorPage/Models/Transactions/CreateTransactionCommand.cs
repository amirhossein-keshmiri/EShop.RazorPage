namespace EShop.RazorPage.Models.Transactions;
public class CreateTransactionCommand
{
    public long OrderId { get; set; }
    public string SuccessCallBackUrl { get; set; }
    public string ErrorCallBackUrl { get; set; }
}

