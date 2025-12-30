using SSD_Exam_Project.Domain;

namespace SSD_Exam_Project.Application.Mapping;

public static class TaskItemMapper
{
    extension(TaskItem taskItem)
    {
        public GetTaskItemDto ToGetTaskItemDto => new()
        {
            Id = taskItem.Id,
            IsCompleted = taskItem.IsCompleted,
            Title = taskItem.Title,
            Description = taskItem.Description
        };
        
        public void UpdateDomainTaskItem(UpdateTaskItemDto updateTaskItemDto)
        {
            taskItem.IsCompleted = updateTaskItemDto.IsCompleted;
            taskItem.Title = updateTaskItemDto.Title;
            taskItem.Description = updateTaskItemDto.Description ?? taskItem.Description;
            taskItem.UpdatedAt = DateTime.UtcNow;
        }
    }
    
    extension(CreateTaskItemDto createTaskItemDto)
    {
        public TaskItem ToDomainTaskItem() =>
            new()
            {
                Id = Guid.NewGuid(),
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Title = createTaskItemDto.Title,
                Description = createTaskItemDto.Description
            };
    }
}