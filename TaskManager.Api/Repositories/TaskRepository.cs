using Microsoft.EntityFrameworkCore;
using TaskManager.Api.DataContext;
using Tarefas = TaskManager.Shared.Models.Tarefas;

namespace TaskManager.Api.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskContext _context;

        public TaskRepository(TaskContext context)
        {
            _context = context;
        }

        public async Task<List<Tarefas>> GetAllTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Tarefas> GetTaskByIdAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<Tarefas> AddTaskAsync(Tarefas task)
        {
            _ = _context.Tasks.Add(task);
            _ = await _context.SaveChangesAsync();
            return task;
        }

        public async Task<Tarefas> UpdateTaskAsync(Tarefas task)
        {
            Tarefas? existingTask = await _context.Tasks.FindAsync(task.Id);
            if (existingTask == null)
            {
                return null;
            }

            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.Status = task.Status;
            existingTask.CreatedAt = task.CreatedAt;

            _ = await _context.SaveChangesAsync();
            return existingTask;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            Tarefas? task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return false;
            }

            _ = _context.Tasks.Remove(task);
            _ = await _context.SaveChangesAsync();
            return true;
        }
    }
}
