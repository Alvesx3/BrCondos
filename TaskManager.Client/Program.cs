using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TaskManager.Client.Services;

namespace TaskManager.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            _ = builder.Services.AddSingleton<TarefaService>();
            _ = builder.Services.AddSingleton<LoginService>();
            _ = builder.Services.AddScoped<AuthenticationStateProviderService>();
            _ = builder.Services.AddBlazoredLocalStorage();

            _ = builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7160") });

            _ = builder.Services.AddAuthorizationCore();
            _ = builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationStateProviderService>();

            await builder.Build().RunAsync();
        }
    }
}
