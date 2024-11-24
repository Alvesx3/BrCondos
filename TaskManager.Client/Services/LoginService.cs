using System.Net.Http.Json;
using TaskManager.Shared.Models;

namespace TaskManager.Client.Services
{
    public class LoginService
    {
        private readonly HttpClient _httpClient;

        public LoginService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> Login(string usuario, string senha)
        {
            HttpResponseMessage resposta = await _httpClient.PostAsJsonAsync("api/auth/login", new UserLoginModel { Username = usuario, Password = senha });
            return resposta;
        }
    }
}
