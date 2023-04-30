namespace Domain.DTOs;

public class FileUploadDto
{
    public int OwnerId { get; }
    public string Title { get; }

    public FileUploadDto(int ownerId, string title)
    {
        OwnerId = ownerId;
        Title = title;
    }
}