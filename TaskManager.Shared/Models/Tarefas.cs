using TaskManager.Shared.Models.Enum;

namespace TaskManager.Shared.Models
{
    public class Tarefas
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
