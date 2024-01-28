using EShop.RazorPage.Models;
using EShop.RazorPage.Models.Transactions;

namespace EShop.RazorPage.Services.Transactions;
public class TransactionService : ITransactionService
{
    private readonly HttpClient _client;
    private const string ModuleName = "transaction";
    public TransactionService(HttpClient client)
    {
        _client = client;
    }
    public async Task<ApiResult<string>> CreateTransaction(CreateTransactionCommand command)
    {
        var result = await _client.PostAsJsonAsync(ModuleName, command);
        return await result.Content.ReadFromJsonAsync<ApiResult<string>>();
    }
}
