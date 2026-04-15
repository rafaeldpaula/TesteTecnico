using TesteTecnico.DbContext.Entities;
using TesteTecnico.DbContext.Entities.Enums;
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

        public Result<TaskItems> Create(CreateTaskRequestDTO request)
        {
            if (string.IsNullOrWhiteSpace(request.Title))
                return new Result<TaskItems>("Title is required!");

            if (string.IsNullOrWhiteSpace(request.Description))
                return new Result<TaskItems>("Description is Required!");

            var task = new TaskItems()
            {
                Id = Guid.NewGuid(),
                Title = request.Title.Trim(),
                Description = request.Description.Trim(),
                Status = Status.NotStarted
            };

            _taskRepository.Add(task);

            return new Result<TaskItems>(task, $"/tasks/{task.Id}");
        }

        public Result<TaskItems> GetById(Guid id)
        {
            var taskFounded = _taskRepository.GetById(id);

            return taskFounded is null
                ? new Result<TaskItems>($"Task with id {id} not found.")
                : new Result<TaskItems>(taskFounded);
        }

        public IReadOnlyList<TaskItems> GetAll()
        {
            return _taskRepository.GetAll();
        }
    }
}
