using CryptoNewBlazorWasm;
using CryptoNewBlazorWasm.Controller;
using CryptoNewBlazorWasm.Model;
using CryptoNewBlazorWasm.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//var config = new ConfigurationBuilder()
//                    .AddUserSecrets<Program>()
//                    .Build();
//string apiKey = config["apikey"];

//var app = builder.Build();





builder.Services.AddTransient(sp => new HttpClient
{

    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

builder.Services.AddTransient<INewFetchService, NewsFetchController>();


await builder.Build().RunAsync();
