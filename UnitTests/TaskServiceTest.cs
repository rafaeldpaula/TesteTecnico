using Moq;
using TesteTecnico.Entities;
using TesteTecnico.Entities.Enums;
using TesteTecnico.Repository;
using TesteTecnico.Services;
using Xunit;

namespace TesteTecnico.UnitTests
{
    public class TaskServiceTest
    {
        public readonly ITaskService _taskService;
        public readonly Mock<ITaskRepository> _taskRepository;

        public TaskServiceTest()
        {
            _taskRepository = new Mock<ITaskRepository>();
            _taskService = new TaskService(_taskRepository.Object);
        }

        [Fact]
        public void Create_ShouldReturnSuccess_WhenRequestIsValid()
        {
            // Arrange
            var createTask = new CreateTaskRequest("Title 1", "Description 1");
            TaskItem taskItem = new(Guid.NewGuid(), createTask.Title, createTask.Description, Status.NotStarted);

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
            var createTask = new CreateTaskRequest("", "Description 1");
            TaskItem taskItem = new(Guid.NewGuid(), createTask.Title, createTask.Description, Status.NotStarted);

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
            var createTask = new CreateTaskRequest("Title 1", "");

            TaskItem taskItem = new(Guid.NewGuid(), createTask.Title, createTask.Description, Status.NotStarted);
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

        [Fact]
        public void GetById_ShouldReturnTask_WhenItExists()
        {
            // Arrange
            var NewId = Guid.NewGuid();
            TaskItem taskItem = new(NewId, "Title 1", "Description 1", Status.NotStarted);

            _taskRepository
                .Setup(x => x.GetById(NewId)).Returns(taskItem);

            // Act
            var response = _taskService.GetById(NewId);

            // Assert
            Assert.True(response.isSuccess);
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
            Assert.Equal(NewId, response.Data.Id);
            Assert.Equal("Title 1", response.Data.Title);
            Assert.Equal("Description 1", response.Data.Description);
            Assert.Equal(Status.NotStarted, response.Data.Status);
        }

        [Fact]
        public void GetById_ShouldReturnError_WhenTaskDoesNotExists()
        {
            // Arrange
            var NewId = Guid.NewGuid();

            _taskRepository
                .Setup(x => x.GetById(NewId))
                .Returns((TaskItem?)null);

            // Act
            var response = _taskService.GetById(NewId);

            // Assert
            Assert.False(response.isSuccess);
            Assert.NotNull(response);
            Assert.Null(response.Data);
            Assert.Equal(($"Task with id {NewId} not found."), response.Error);
        }
    }
}
