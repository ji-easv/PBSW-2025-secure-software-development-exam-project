using SSD_Exam_Project.Domain;

namespace SSD_Exam_Project.Application.Services;

public interface ITaskItemService
{
    Task<GetTaskItemDto> CreateAsync(CreateTaskItemDto taskItem);
    
    Task<GetTaskItemDto> UpdateAsync(UpdateTaskItemDto taskItem);
    
    Task DeleteAsync(Guid taskItemId);
    
    Task<GetTaskItemDto> GetByIdAsync(Guid taskItemId);
    
    Task<List<GetTaskItemDto>> GetAllAsync();
}