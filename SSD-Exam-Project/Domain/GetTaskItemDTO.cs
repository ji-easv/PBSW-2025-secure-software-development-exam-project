namespace SSD_Exam_Project.Domain;

public class GetTaskItemDto
{
    public required Guid Id { get; set; }
    public required string Title { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public bool IsCompleted { get; set; }
}