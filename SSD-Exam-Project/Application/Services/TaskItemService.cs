using SSD_Exam_Project.Application.Mapping;
using SSD_Exam_Project.Domain;
using SSD_Exam_Project.Infrastructure;

namespace SSD_Exam_Project.Application.Services;

public class TaskItemService(ITaskItemRepository taskItemRepository) : ITaskItemService
{
    public async Task<GetTaskItemDto> CreateAsync(CreateTaskItemDto createTaskItemDto)
    {
        var taskItem = createTaskItemDto.ToDomainTaskItem();
        var result = await taskItemRepository.CreateAsync(taskItem);
        return result.ToGetTaskItemDto;
    }

    public async Task<GetTaskItemDto> UpdateAsync(UpdateTaskItemDto updateTaskItemDto)
    {
        var taskItem = await GetTaskItemOrThrowAsync(updateTaskItemDto.Id);
        taskItem.UpdateDomainTaskItem(updateTaskItemDto);
        var result = await taskItemRepository.UpdateAsync(taskItem);
        return result.ToGetTaskItemDto;
    }

    public async Task DeleteAsync(Guid taskItemId)
    {
        var taskItem = await GetTaskItemOrThrowAsync(taskItemId);
        await taskItemRepository.DeleteAsync(taskItem);
    }

    public async Task<GetTaskItemDto> GetByIdAsync(Guid taskItemId)
    {
        var taskItem = await GetTaskItemOrThrowAsync(taskItemId);
        return taskItem.ToGetTaskItemDto;
    }

    public async Task<List<GetTaskItemDto>> GetAllAsync()
    {
        var taskItems = await taskItemRepository.GetAllAsync();
        return taskItems.Select(ti => ti.ToGetTaskItemDto).ToList();
    }

    private async Task<TaskItem> GetTaskItemOrThrowAsync(Guid taskItemId)
    {
        var taskItem = await taskItemRepository.GetByIdAsync(taskItemId);
        return taskItem ?? throw new Exception("Task item not found");
    }
}