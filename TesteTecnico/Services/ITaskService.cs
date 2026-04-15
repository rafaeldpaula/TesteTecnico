using TesteTecnico.Database.Entities;
using TesteTecnico.Entities;

namespace TesteTecnico.Services
{
    public interface ITaskService
    {
        Result<TaskItem?> Create(CreateTaskRequestDTO request);
        Result<TaskItem?> GetById(Guid id);
        IReadOnlyList<TaskItem> GetAll();
    }
}
