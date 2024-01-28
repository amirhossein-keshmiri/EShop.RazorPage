using EShop.RazorPage.Models.Transactions;
using EShop.RazorPage.Models;

namespace EShop.RazorPage.Services.Transactions;
public interface ITransactionService
{
    Task<ApiResult<string>> CreateTransaction(CreateTransactionCommand command);
}

