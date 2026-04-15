using Microsoft.EntityFrameworkCore;
using TesteTecnico.Database;
using TesteTecnico.Database.Entities;

namespace TesteTecnico.Repository
{
    public class EFTaskRepository : ITaskRepository
    {
        private AppDbContext _context;

        public EFTaskRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(TaskItem task)
        {
            await _context.TaskItems.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(Guid id)
        {
            return await _context.TaskItems.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<TaskItem>> GetAllAsync()
        {
            return await _context.TaskItems.ToListAsync();
        }
    }
}
