namespace Domain.DTOs;

public class FileUpdateDto
{
    public int Id { get; }
    public int? OwnerId { get; set; }
    public string? Title { get; set; }
    public bool? IsCompleted { get; set; }

    public FileUpdateDto(int id)
    {
        Id = id;
    }
}