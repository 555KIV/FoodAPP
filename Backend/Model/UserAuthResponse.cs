using Backend.EntityDb;

namespace Backend.Model;

public class UserAuthResponse(string? username, string? accessToken)
{
    public string? username { get; set; } = username;

    public string? accessToken { get; set; } = accessToken;

    
}