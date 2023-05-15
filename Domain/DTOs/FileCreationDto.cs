using Domain.Models;

namespace Domain.DTOs;

public class FileCreationDto
{
    
    public string Title { get; set; }
    public string Description { get; set; }
    public Category Category { get; set; }
    public User UploadedBy { get;  set; }
    public byte[] bytes{ get; set; }
}