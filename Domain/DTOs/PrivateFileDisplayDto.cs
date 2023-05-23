using Domain.Models;

namespace Domain.DTOs;

public class PrivateFileDisplayDto
{
    public string Title { get; set; }
    public string ContentType { get; set; }
    public byte[] bytes{ get; set; }
    public User UploadedBy { get;  set; }
    public int id { get; set; }
}