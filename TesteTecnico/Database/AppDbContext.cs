using Microsoft.EntityFrameworkCore;
using TesteTecnico.Database.Entities;

namespace TesteTecnico.Database
{
    public class AppDbContext : DbContext
    {
        private TaskItem mapTaskItem { get; set; } = new TaskItem();
        public DbSet<TaskItem> taskItems { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            mapTaskItem.MapTaskItemDbContext(modelBuilder);
        }
    }
}
