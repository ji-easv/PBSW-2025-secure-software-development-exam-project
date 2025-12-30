namespace SSD_Exam_Project.Domain;

public class UpdateTaskItemDto
{
    public required Guid Id { get; set; }
    public required bool IsCompleted { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
}