using TesteTecnico.DbContext.Entities;
using TesteTecnico.Entities;

namespace TesteTecnico.Repository
{
    public interface ITaskRepository
    {
        void Add(TaskItems task);
        TaskItems? GetById(Guid id);
        IReadOnlyList<TaskItems> GetAll();
    }
}
