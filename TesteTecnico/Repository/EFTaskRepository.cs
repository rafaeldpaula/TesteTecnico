using TesteTecnico.DbContext.Entities;

namespace TesteTecnico.Repository
{
    public class EFTaskRepository : ITaskRepository
    {
        public void Add(TaskItems task)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<TaskItems> GetAll()
        {
            throw new NotImplementedException();
        }

        public TaskItems? GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
