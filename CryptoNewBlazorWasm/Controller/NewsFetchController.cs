using CryptoNewBlazorWasm.Model;
using CryptoNewBlazorWasm.Services;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CryptoNewBlazorWasm.Controller
{
    public class NewsFetchController : INewFetchService
    {
        private readonly HttpClient _httpClient;

        const string _baseUrl = "https://investing-cryptocurrency-markets.p.rapidapi.com";
        const string _newEndPoint = "/coins/get-news?pair_ID=1057391&page=1&time_utc_offset=28800&lang_ID=1";
        const string _host = "investing-cryptocurrency-markets.p.rapidapi.com";
        const string _key = "7ddaaf6955msh87bbaee995a77b3p1eddc8jsneb44a4cb5d9c";

        public NewsFetchController(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<NewsItem>> GetNews()
        {
            ConfigureHttpClient();
            var respone = await _httpClient.GetAsync(_newEndPoint);
            respone.EnsureSuccessStatusCode();

            using var stream = await respone.Content.ReadAsStreamAsync();

            var dto = await JsonSerializer.DeserializeAsync<NewsDto>(stream);

            //if (dto == null) return;
            return dto.data.FirstOrDefault().screen_data.news.Select(n => new NewsItem
            {
                Headline = n.HEADLINE,
                Body = (MarkupString)n.BODY,
                ImageUrl = n.related_image_big

            }).ToList();

        }

        private void ConfigureHttpClient()
        {
            _httpClient.BaseAddress = new Uri(_baseUrl);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", _key);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", _host);
        }
    }
}
