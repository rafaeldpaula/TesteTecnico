using TesteTecnico.Entities;

namespace TesteTecnico.Repository
{
    public class InMemoryTaskRepository : ITaskRepository
    {
        private readonly List<TaskItem> taskList = new List<TaskItem>();

        public void Add(TaskItem task)
        {
            taskList.Add(task);
        }

        public IReadOnlyList<TaskItem> GetAll()
        {
            return taskList;
        }

        public TaskItem? GetById(Guid id)
        {
            return taskList.FirstOrDefault(t => t.Id == id);
        }
    }
}
