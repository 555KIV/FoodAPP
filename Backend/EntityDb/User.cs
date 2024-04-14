using System.ComponentModel.DataAnnotations;

namespace Backend.EntityDb;

public class User(string username, string password, string salt)
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(30)]
    public string? Username { get; set; } = username;

    [MaxLength(64)]
    public string? Password { get; set; } = password;

    [MaxLength(10)]
    public string? Salt { get; set; } = salt;
}