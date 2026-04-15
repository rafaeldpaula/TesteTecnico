using TesteTecnico.Database.Entities;
using TesteTecnico.Entities;

namespace TesteTecnico.Repository
{
    public interface ITaskRepository
    {
        Task AddAsync(TaskItem task);
        Task<TaskItem?> GetByIdAsync(Guid id);
        Task<IReadOnlyList<TaskItem>> GetAllAsync();
    }
}
