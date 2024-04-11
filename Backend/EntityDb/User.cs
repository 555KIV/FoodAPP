using System.ComponentModel.DataAnnotations;

namespace Backend.EntityDb;

public class User
{
    [Key]
    public int Id { get; init; }
    public string? Username { get; init; }
    
    public string? Password { get; init; }

   public User(string username, string password)
    {
        Username = username;
        Password = password;
    }
}