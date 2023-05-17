using Domain.Models;

namespace Domain.DTOs;

public class GetAllFilesDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Category Category { get; set; }
    
    public string ContentType { get; set; }
    public User UploadedBy { get;  set; }
    
    public GetAllFilesDto(int id, string title, string description, Category category, string contentType,User uploadedBy)
    {
        Id = id;
        Title = title;
        Description = description;
        Category = category;
        ContentType = contentType;
        UploadedBy = uploadedBy;
    }
}
