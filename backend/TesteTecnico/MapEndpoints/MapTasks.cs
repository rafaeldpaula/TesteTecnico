using Microsoft.AspNetCore.Http.HttpResults;
using TesteTecnico.Database.Entities;
using TesteTecnico.Entities;
using TesteTecnico.Services;

namespace TesteTecnico.MapEndpoints
{
    public static class MapTasks
    {
        public static void MappingTasks(this WebApplication app)
        {
            app.MapPost("/tasks",
                Results<BadRequest<string>, Created<TaskItem>> (CreateTaskRequestDTO request, ITaskService taskService) =>
            {
                var response = taskService.Create(request);

                if (response.isSuccess)
                    return TypedResults.Created(response.Location, response.Data);
                else
                    return TypedResults.BadRequest(response?.Error);
            });

            app.MapGet("/tasks/{id:guid}",
                Results<NotFound<string>, Ok<TaskItem>> (Guid id, ITaskService taskService) =>
            {
                var response = taskService.GetById(id);

                if (response.isSuccess)
                    return TypedResults.Ok(response.Data);
                else
                    return TypedResults.NotFound(response.Error);
            });

            app.MapGet("/tasks", (ITaskService taskService) => TypedResults.Ok(taskService.GetAll()));
        }
    }
}
