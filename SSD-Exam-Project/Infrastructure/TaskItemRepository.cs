using Microsoft.EntityFrameworkCore;
using SSD_Exam_Project.Domain;

namespace SSD_Exam_Project.Infrastructure;

public class TaskItemRepository(AppDbContext dbContext) : ITaskItemRepository
{
    public async Task<TaskItem> CreateAsync(TaskItem taskItem)
    {
        dbContext.TaskItems.Add(taskItem);
        await dbContext.SaveChangesAsync();
        return taskItem;
    }

    public async Task<TaskItem> UpdateAsync(TaskItem taskItem)
    {
        dbContext.TaskItems.Update(taskItem);
        await dbContext.SaveChangesAsync();
        return taskItem;
    }

    public async Task DeleteAsync(TaskItem taskItem)
    {
        dbContext.TaskItems.Remove(taskItem);
        await dbContext.SaveChangesAsync();
    }

    public async Task<TaskItem?> GetByIdAsync(Guid toDoItemId)
    {
        return await dbContext.TaskItems.FindAsync(toDoItemId);
    }

    public async Task<List<TaskItem>> GetAllAsync()
    {
        return await dbContext.TaskItems.ToListAsync();
    }
}