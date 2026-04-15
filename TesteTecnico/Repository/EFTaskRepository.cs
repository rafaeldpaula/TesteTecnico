using TesteTecnico.Database;
using TesteTecnico.Database.Entities;

namespace TesteTecnico.Repository
{
    public class EFTaskRepository : ITaskRepository
    {
        private AppDbContext _context;

        public EFTaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(TaskItem task)
        {
            _context.taskItems.Add(task);
        }

        public IReadOnlyList<TaskItem> GetAll()
        {
            return _context.taskItems.ToList();
        }

        public TaskItem? GetById(Guid id)
        {
            return _context.taskItems.FirstOrDefault(x => x.Id == id);
        }
    }
}
