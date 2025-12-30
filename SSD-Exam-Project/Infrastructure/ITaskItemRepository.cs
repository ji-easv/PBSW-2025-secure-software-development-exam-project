using SSD_Exam_Project.Domain;

namespace SSD_Exam_Project.Infrastructure;

public interface ITaskItemRepository
{
    Task<TaskItem> CreateAsync(TaskItem taskItem);
    
    Task<TaskItem> UpdateAsync(TaskItem taskItem);
    
    Task DeleteAsync(TaskItem taskItem);
    
    Task<TaskItem?> GetByIdAsync(Guid toDoItemId);
    
    Task<List<TaskItem>> GetAllAsync();
}