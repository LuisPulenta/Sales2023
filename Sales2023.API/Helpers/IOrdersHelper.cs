using Sales2023.Shared.Responses;

namespace Sales2023.API.Helpers
{
    public interface IOrdersHelper
    {
        Task<Response> ProcessOrderAsync(string email, string remarks);
    }
}