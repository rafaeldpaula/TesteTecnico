using TesteTecnico.DbContext.Entities.Enums;

namespace TesteTecnico.DbContext.Entities
{
    public class TaskItems
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Status Status { get; set; }
    }
}
