namespace SSD_Exam_Project.Domain;

public class CreateTaskItemDto
{
    public required string Title { get; set; } = null!;
    public string? Description { get; set; } = null!;
}