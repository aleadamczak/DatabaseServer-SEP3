namespace Domain.Models;

public class PublicFile
{
    public int Id { get; set; }

    public string Title { get; set; }
    
    public string Description { get; set; }
    public string Category { get; set; }
    public string FilePath { get; set; }

    public PublicFile(User owner, string? title, string? description, string? category, string? filePath)
    {
        
    }
    
    
    
    
    
    
    
    
    
    
}