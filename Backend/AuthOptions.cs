using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Backend;

public class AuthOptions
{
    public readonly string? ISSUER;
    public readonly string? AUDIENCE;
    private readonly string? KEY;

    public AuthOptions()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .SetBasePath(Directory.GetCurrentDirectory())
            .Build();
        ISSUER = config["AuthOptions:Issuer"];
        AUDIENCE = config["AuthOptions:Audience"];
        KEY = config["AuthOptions:KEY"];
    }
    public SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY!));
}