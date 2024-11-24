using System.Net.Http.Json;
using TaskManager.Shared.Models;

namespace TaskManager.Client.Services
{
    public class TarefaService
    {
        private readonly HttpClient _httpClient;

        public TarefaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void SetAuthorizationToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<List<Tarefas>> GetAllTasksAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Tarefas>>("api/Task");
        }

        public async Task<Tarefas> GetTaskByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Tarefas>($"api/Task/{id}");
        }

        public async Task<Tarefas> AddTaskAsync(Tarefas task)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Task/Create", task);
            _ = response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Tarefas>();
        }

        public async Task<Tarefas> UpdateTaskAsync(Tarefas task)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"api/Task/{task.Id}", task);
            _ = response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Tarefas>();
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"api/Task/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
