using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

#pragma warning disable IL2026 // BindConfiguration RequiresUnreferencedCodeAttribute TOptions's dependent types may have their members trimmed. Ensure all required members are preserved.
builder.Services.AddOptions<GalleryBrowserOptions>().BindConfiguration("GalleryBrowser");
#pragma warning restore IL2026
builder.Services.AddSingleton<GalleryBrowserState>();
builder.Services.AddScoped<GalleryHttpClient>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
