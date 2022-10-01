using Microsoft.AspNetCore.Components;

namespace CryptoNewBlazorWasm.Model
{
    public class NewsItem
    {
        public string Headline { get; set; }
        public MarkupString Body { get; set; }
        public string ImageUrl { get; set; }
    }
}
