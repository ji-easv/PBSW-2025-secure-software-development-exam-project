using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SSD_Exam_Project.Application.Services;
using SSD_Exam_Project.Domain;

namespace SSD_Exam_Project.Presentation;

public static class TaskItemApi
{
    public static RouteGroupBuilder AddTaskItemApi(this IEndpointRouteBuilder app)
    {
        var api = app
            .MapGroup("/api/v1/tasks");
        
        api.MapGet("/item/{taskId:guid}", GetTaskById)
            .WithName("GetTaskById");
        
        api.MapGet("/", GetAllTasks)
            .WithName("GetAllTasks");

        api.MapPost("/", CreateTask)
            .WithName("CreateTask");

        api.MapPut("/", UpdateTask)
            .WithName("UpdateTask");
        
        api.MapDelete("/{taskId:guid}", DeleteTask)
            .WithName("DeleteTask");

        return api;
    }

    private static async Task<Results<Ok<GetTaskItemDto>, NotFound, ProblemHttpResult>> GetTaskById(
        [FromRoute] Guid taskId,
        [FromServices] ITaskItemService toDoService)
    {
        var task = await toDoService.GetByIdAsync(taskId);
        return TypedResults.Ok(task);
    }
    
    private static async Task<Results<Ok<List<GetTaskItemDto>>, ProblemHttpResult>> GetAllTasks(
        [FromServices] ITaskItemService toDoService)
    {
        var tasks = await toDoService.GetAllAsync();
        return TypedResults.Ok(tasks);
    }

    private static async Task<Results<Created<GetTaskItemDto>, Conflict, ProblemHttpResult>> CreateTask(
        [FromBody] CreateTaskItemDto createToDoItemDto,
        [FromServices] ITaskItemService toDoService
    )
    {
        var item = await toDoService.CreateAsync(createToDoItemDto);
        return TypedResults.Created($"/api/v1/tasks/item/{item.Id}", item);
    }

    private static async Task<Results<Ok<GetTaskItemDto>, NotFound, ProblemHttpResult>> UpdateTask(
        [FromBody] UpdateTaskItemDto updateToDoItem,
        [FromServices] ITaskItemService toDoService)
    {
        var item = await toDoService.UpdateAsync(updateToDoItem);
        return TypedResults.Ok(item);
    }

    private static async Task<Results<NoContent, NotFound, ProblemHttpResult>> DeleteTask(
        Guid taskId,
        [FromServices] ITaskItemService toDoService)
    {
        await toDoService.DeleteAsync(taskId);
        return TypedResults.NoContent();
    }
}