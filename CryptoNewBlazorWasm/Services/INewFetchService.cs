using CryptoNewBlazorWasm.Model;

namespace CryptoNewBlazorWasm.Services
{
    public interface INewFetchService
    {
        Task<List<NewsItem>> GetNews();
    }
}
