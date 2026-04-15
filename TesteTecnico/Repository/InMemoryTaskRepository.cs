using TesteTecnico.DbContext.Entities;

namespace TesteTecnico.Repository
{
    public class InMemoryTaskRepository : ITaskRepository
    {
        private readonly List<TaskItems> taskList = new List<TaskItems>();

        public void Add(TaskItems task)
        {
            taskList.Add(task);
        }

        public IReadOnlyList<TaskItems> GetAll()
        {
            return taskList;
        }

        public TaskItems? GetById(Guid id)
        {
            return taskList.FirstOrDefault(t => t.Id == id);
        }
    }
}
