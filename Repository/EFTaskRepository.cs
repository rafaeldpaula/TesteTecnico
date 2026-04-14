using TesteTecnico.Entities;

namespace TesteTecnico.Repository
{
    public class EFTaskRepository : ITaskRepository
    {
        public void Add(TaskItem task)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<TaskItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public TaskItem? GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
