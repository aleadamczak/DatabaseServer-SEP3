namespace Domain.DTOs;

public class UserCreationDto
{
    public string Username { get;}
    public string Name { get; }
    public string Password { get; }
    
    public bool IsAdmin { get;}
    public UserCreationDto(string username, string name, string password, bool isAdmin)
    {
        Username = username;
        Name = name;
        Password = password;
        IsAdmin = isAdmin;
    }
}