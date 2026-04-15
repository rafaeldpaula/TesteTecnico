using Moq;
using TesteTecnico.Database.Entities;
using TesteTecnico.Database.Entities.Enums;
using TesteTecnico.Entities;
using TesteTecnico.Repository;
using TesteTecnico.Services;

namespace TesteTecnico.Test.TaskServiceTest
{
    public class CreateTaskTests
    {
        public readonly ITaskService _taskService;
        public readonly Mock<ITaskRepository> _taskRepository;

        public CreateTaskTests()
        {
            _taskRepository = new Mock<ITaskRepository>();
            _taskService = new TaskService(_taskRepository.Object);
        }

        [Fact]
        public void Create_ShouldReturnSuccess_WhenRequestIsValid()
        {
            // Arrange
            var createTask = new CreateTaskRequestDTO("Title 1", "Description 1");
            var taskItem = new TaskItem() { Id = Guid.NewGuid(), Title = createTask.Title, Description = createTask.Description, Status = Status.NotStarted };

            // Act
            var result = _taskService.Create(createTask);

            // Assert
            Assert.True(result.isSuccess);
            Assert.NotNull(result);
            _taskRepository.Verify(x => x.Add(It.IsAny<TaskItem>()), Times.Once);
        }

        [Fact]
        public void Create_ShouldReturnError_WhenTitleExists()
        {
            // Arrange
            var createTask = new CreateTaskRequestDTO("", "Description 1");
            var taskItem = new TaskItem() { Id = Guid.NewGuid(), Title = createTask.Title, Description = createTask.Description, Status = Status.NotStarted };

            // Act
            var result = _taskService.Create(createTask);

            // Assert
            Assert.False(result.isSuccess);
            Assert.NotNull(result);
            Assert.Equal("Title is required!", result.Error);

            _taskRepository.Verify(x => x.Add(taskItem), Times.Never);
        }

        [Fact]
        public void Create_ShouldReturnError_WhenDescriptionExists()
        {
            // Arrange
            var createTask = new CreateTaskRequestDTO("Title 1", "");

            var taskItem = new TaskItem() { Id = Guid.NewGuid(), Title = createTask.Title, Description = createTask.Description, Status = Status.NotStarted };
            _taskRepository
                .Setup(x => x.Add(taskItem));


            // Act
            var result = _taskService.Create(createTask);

            // Assert
            Assert.False(result.isSuccess);
            Assert.NotNull(result);
            Assert.Equal("Description is Required!", result.Error);

            _taskRepository.Verify(x => x.Add(taskItem), Times.Never);
        }
    }
}
