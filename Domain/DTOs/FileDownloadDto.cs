namespace Domain.DTOs;

public class FileDownloadDto
{
    public string Title { get; }
    public byte[] Bytes { get; }
    public string ContentType { get; }

    public FileDownloadDto(string title, byte[] bytes, string contentType)
    {
        Title = title;
        Bytes = bytes;
        ContentType = contentType;
    }
}