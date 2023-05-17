namespace Domain.DTOs;

public class FileDownloadDto
{
    public string Title { get; }
    public byte[] Bytes { get; }

    public FileDownloadDto(string title, byte[] bytes)
    {
        Title = title;
        Bytes = bytes;
    }
}