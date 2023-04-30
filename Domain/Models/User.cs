using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    public string Email { get; set; }
    
    public string Password { get; set; }
    public string UserName { get; set; }
    
    
    // [JsonIgnore]
    // public ICollection<Todo> Todos { get; set; }
}