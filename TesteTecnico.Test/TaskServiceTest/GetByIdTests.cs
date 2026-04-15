using Moq;
using TesteTecnico.Database.Entities;
using TesteTecnico.Database.Entities.Enums;
using TesteTecnico.Repository;
using TesteTecnico.Services;

namespace TesteTecnico.UnitTests
{
    public class GetByIdTests
    {
        public readonly ITaskService _taskService;
        public readonly Mock<ITaskRepository> _taskRepository;

        public GetByIdTests()
        {
            _taskRepository = new Mock<ITaskRepository>();
            _taskService = new TaskService(_taskRepository.Object);
        }

        [Fact]
        public void GetById_ShouldReturnTask_WhenItExists()
        {
            // Arrange
            var NewId = Guid.NewGuid();
            TaskItem taskItem = new TaskItem() { Id = NewId, Title = "Title 1", Description = "Description 1", Status = Status.NotStarted };

            _taskRepository
                .Setup(x => x.GetByIdAsync(NewId)).ReturnsAsync(taskItem);

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
                .Setup(x => x.GetByIdAsync(NewId))
                .ReturnsAsync((TaskItem?)null);

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
