using TesteTecnico.Database.Entities;
using TesteTecnico.Database.Entities.Enums;
using TesteTecnico.Entities;
using TesteTecnico.Repository;

namespace TesteTecnico.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public Result<TaskItem> Create(CreateTaskRequestDTO request)
        {
            if (string.IsNullOrWhiteSpace(request.Title))
                return new Result<TaskItem>("Title is required!");

            if (string.IsNullOrWhiteSpace(request.Description))
                return new Result<TaskItem>("Description is Required!");

            var task = new TaskItem()
            {
                Id = Guid.NewGuid(),
                Title = request.Title.Trim(),
                Description = request.Description.Trim(),
                Status = Status.NotStarted
            };

            _taskRepository.AddAsync(task).GetAwaiter().GetResult();

            return new Result<TaskItem>(task, $"/tasks/{task.Id}");
        }

        public Result<TaskItem> GetById(Guid id)
        {
            var taskFounded = _taskRepository.GetByIdAsync(id).GetAwaiter().GetResult();

            return taskFounded is null
                ? new Result<TaskItem>($"Task with id {id} not found.")
                : new Result<TaskItem>(taskFounded);
        }

        public IReadOnlyList<TaskItem> GetAll()
        {
            return _taskRepository.GetAllAsync().GetAwaiter().GetResult();
        }
    }
}
