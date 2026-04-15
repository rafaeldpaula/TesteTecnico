using TesteTecnico.Database.Entities;

namespace TesteTecnico.Repository
{
    public class InMemoryTaskRepository : ITaskRepository
    {
        private readonly List<TaskItem> taskList = new List<TaskItem>();

        public async Task AddAsync(TaskItem task)
        {
            taskList.Add(task);
        }

        public async Task<IReadOnlyList<TaskItem>> GetAllAsync()
        {
            return taskList;
        }

        public async Task<TaskItem?> GetByIdAsync(Guid id)
        {
            return taskList.FirstOrDefault(t => t.Id == id);
        }
    }
}
