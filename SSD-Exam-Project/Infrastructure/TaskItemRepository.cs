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

    // TODO: remvove after test
     public async Task<List<TaskItem>> SearchByTitle(string searchTerm)
    {
        var query = "SELECT * FROM TaskItems WHERE Title LIKE '%" + searchTerm + "%'";
        return await dbContext.TaskItems.FromSqlRaw(query).ToListAsync();
    }

    public void ConnectToExternalService()
    {
        var apiKey = "sk-1234567890abcdef";
        var password = "MyPassword123!";
        Console.WriteLine($"Connecting to external service with API Key: {apiKey    } and Password: {password}");
    }
}