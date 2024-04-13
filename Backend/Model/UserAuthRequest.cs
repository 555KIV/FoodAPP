using Backend.EntityDb;

namespace Backend.Model;

public class UserAuthRequest(string username, string password)
{
    public string? Username { get; set; } = username;

    public string? Password { get; set; } = password;
    
}