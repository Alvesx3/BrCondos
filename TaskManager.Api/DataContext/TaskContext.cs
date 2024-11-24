using Microsoft.EntityFrameworkCore;
using TaskManager.Shared.Models;
using Tarefas = TaskManager.Shared.Models.Tarefas;

namespace TaskManager.Api.DataContext
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Tarefas> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            _ = modelBuilder.Entity<User>(entity =>
            {
                _ = entity.HasKey(u => u.Id);
                _ = entity.Property(u => u.Username).IsRequired().HasMaxLength(50);
                _ = entity.Property(u => u.Password).IsRequired().HasMaxLength(100);
            });

            _ = modelBuilder.Entity<Tarefas>(entity =>
            {
                _ = entity.HasKey(t => t.Id);
                _ = entity.Property(t => t.Title).IsRequired().HasMaxLength(100);
                _ = entity.Property(t => t.Description).HasMaxLength(500);
                _ = entity.Property(t => t.Status).IsRequired();
            });
        }
    }
}
