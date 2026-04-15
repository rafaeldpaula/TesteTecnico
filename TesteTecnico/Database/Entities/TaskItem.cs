using Microsoft.EntityFrameworkCore;
using TesteTecnico.Database.Entities.Enums;

namespace TesteTecnico.Database.Entities
{
    public class TaskItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Status Status { get; set; }

        public void MapTaskItemDbContext(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>(e =>
            {
                e.ToTable("TaskItems");

                e.Property(x => x.Id)
                 .HasDefaultValueSql("lower(hex(randomblob(16)))");

                e.Property(x => x.Title)
                    .HasMaxLength(150)
                    .IsRequired();

                e.Property(x => x.Description)
                    .HasMaxLength(1500)
                    .IsRequired();

                e.Property(x => x.Status);
            });
        }
    }
}
