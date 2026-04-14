using TesteTecnico.Entities;

namespace TesteTecnico.Repository
{
    public interface ITaskRepository
    {
        void Add(TaskItem task);
        TaskItem? GetById(Guid id);
        IReadOnlyList<TaskItem> GetAll();
    }
}
