using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using TaskManager.Shared.Models;

public class AuthenticationStateProviderService : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorage;

    public AuthenticationStateProviderService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    //public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    //{
    //    var tokenModel = await _localStorage.GetItemAsync<TokenModel>("token");

    //    if (tokenModel != null && tokenModel.Expiracao > DateTime.UtcNow)
    //    {
    //        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, tokenModel.Token) }, "jwt")));
    //    }

    //    return new AuthenticationState(new ClaimsPrincipal());
    //}

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        TokenModel? tokenModel = await _localStorage.GetItemAsync<TokenModel>("token");

        if (tokenModel == null)
        {
            Console.WriteLine("Token não encontrado no LocalStorage.");
            return new AuthenticationState(new ClaimsPrincipal());
        }

        if (tokenModel.Expiracao <= DateTime.UtcNow)
        {
            Console.WriteLine("Token expirado.");
            return new AuthenticationState(new ClaimsPrincipal());
        }

        Console.WriteLine("Token válido encontrado. Autenticando...");
        ClaimsIdentity identity = new(new[] { new Claim(ClaimTypes.Name, tokenModel.Token) }, "jwt");
        return new AuthenticationState(new ClaimsPrincipal(identity));
    }

    public async Task MarkUserAsAuthenticated(TokenModel tokenModel)
    {
        await _localStorage.SetItemAsync("token", tokenModel);
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public async Task MarkUserAsUnauthenticated()
    {
        await _localStorage.RemoveItemAsync("token");
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}
