using TesteTecnico.Entities;

namespace TesteTecnico.Services
{
    public interface ITaskService
    {
        Result<TaskItem?> Create(CreateTaskRequest request);
        Result<TaskItem?> GetById(Guid id);
        IReadOnlyList<TaskItem> GetAll();
    }
}
