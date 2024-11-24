using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Repositories;
using TaskManager.Shared.Models;

namespace TaskManager.Api.Controllers
{
    [Authorize]
    [Route("api/Task")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            List<Tarefas> tasks = await _taskRepository.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            Tarefas task = await _taskRepository.GetTaskByIdAsync(id);
            return task == null ? NotFound(new { Message = $"Task with ID {id} not found." }) : Ok(task);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> AddTask([FromBody] Tarefas task)
        {
            if (task == null)
            {
                return BadRequest(new { Message = "Invalid task data." });
            }

            Tarefas createdTask = await _taskRepository.AddTaskAsync(task);
            return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.Id }, createdTask);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] Tarefas task)
        {
            if (task == null || id != task.Id)
            {
                return BadRequest(new { Message = "Task data is invalid or mismatched ID." });
            }

            Tarefas updatedTask = await _taskRepository.UpdateTaskAsync(task);
            return updatedTask == null ? NotFound(new { Message = $"Task with ID {id} not found." }) : Ok(updatedTask);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            bool deleted = await _taskRepository.DeleteTaskAsync(id);
            return !deleted ? NotFound(new { Message = $"Task with ID {id} not found." }) : NoContent();
        }
    }
}
