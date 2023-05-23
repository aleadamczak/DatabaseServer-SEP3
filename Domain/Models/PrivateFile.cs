using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class PrivateFile
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string ContentType { get; set; }
    public byte[] bytes{ get; set; }
    public User UploadedBy { get;  set; }
    public List<User> HaveAccess { get; set; }

    public PrivateFile(string title, string contentType, byte[] bytes, User uploadedBy, List<User> haveAccess)
    {
        Title = title;
        ContentType = contentType;
        this.bytes = bytes;
        UploadedBy = uploadedBy;
        HaveAccess = haveAccess;
    }

    public PrivateFile()
    {
    }

    // private PrivateFile()
    // {
    // }
}