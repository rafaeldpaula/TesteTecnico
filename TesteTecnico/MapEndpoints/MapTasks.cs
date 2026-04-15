using Microsoft.AspNetCore.Http.HttpResults;
using TesteTecnico.DbContext.Entities;
using TesteTecnico.Entities;
using TesteTecnico.Services;

namespace TesteTecnico.MapEndpoints
{
    public static class MapTasks
    {
        public static void MappingTasks(this WebApplication app)
        {
            app.MapPost("/tasks",
                Results<BadRequest<string>, Created<TaskItems>> (CreateTaskRequestDTO request, ITaskService taskService) =>
            {
                var response = taskService.Create(request);

                if (response.isSuccess)
                    return TypedResults.BadRequest(response?.Error);
                else
                    return TypedResults.Created(response.Location, response.Data);
                
            });

            app.MapGet("/tasks/{id:guid}",
                Results<NotFound<string>, Ok<TaskItems>> (Guid id, ITaskService taskService) =>
            {
                var response = taskService.GetById(id);

                if (response.isSuccess)
                    return TypedResults.NotFound(response.Error);
                else
                    return TypedResults.Ok(response.Data);

            });

            app.MapGet("/tasks", (ITaskService taskService) => TypedResults.Ok(taskService.GetAll()));
        }
    }
}
