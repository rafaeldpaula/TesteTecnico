using TesteTecnico.Entities;
using TesteTecnico.Entities.Enums;
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

        public Result<TaskItem> Create(CreateTaskRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Title))
                return new Result<TaskItem>("Title is required!");

            if (string.IsNullOrWhiteSpace(request.Description))
                return new Result<TaskItem>("Description is Required!");

            var task = new TaskItem(
                Guid.NewGuid(),
                request.Title.Trim(),
                request.Description.Trim(),
                Status.NotStarted);

            _taskRepository.Add(task);

            return new Result<TaskItem>(task, true, $"/tasks/{task.Id}");
        }

        public Result<TaskItem> GetById(Guid id)
        {
            var taskFounded = _taskRepository.GetById(id);

            return taskFounded is null
                ? new Result<TaskItem>($"Task with id {id} not found.")
                : new Result<TaskItem>(taskFounded, true);
        }

        public IReadOnlyList<TaskItem> GetAll()
        {
            return _taskRepository.GetAll();
        }
    }
}
