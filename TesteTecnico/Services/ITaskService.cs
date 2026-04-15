using TesteTecnico.DbContext.Entities;
using TesteTecnico.Entities;

namespace TesteTecnico.Services
{
    public interface ITaskService
    {
        Result<TaskItems?> Create(CreateTaskRequestDTO request);
        Result<TaskItems?> GetById(Guid id);
        IReadOnlyList<TaskItems> GetAll();
    }
}
