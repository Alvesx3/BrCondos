using Tarefas = TaskManager.Shared.Models.Tarefas;

namespace TaskManager.Api.Repositories
{
    public interface ITaskRepository
    {
        Task<List<Tarefas>> GetAllTasksAsync();
        Task<Tarefas> GetTaskByIdAsync(int id);
        Task<Tarefas> AddTaskAsync(Tarefas task);
        Task<Tarefas> UpdateTaskAsync(Tarefas task);
        Task<bool> DeleteTaskAsync(int id);
    }
}
