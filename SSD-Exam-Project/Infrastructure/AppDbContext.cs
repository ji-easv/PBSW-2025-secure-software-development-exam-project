using Microsoft.EntityFrameworkCore;
using SSD_Exam_Project.Domain;

namespace SSD_Exam_Project.Infrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    
    public virtual DbSet<TaskItem> TaskItems { get; set; }
}