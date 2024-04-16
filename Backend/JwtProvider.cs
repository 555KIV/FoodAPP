using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Backend.EntityDb;
using Microsoft.IdentityModel.Tokens;

namespace Backend;

public class JwtProvider
{
    private readonly string? ISSUER;
    private readonly string? AUDIENCE;
    private readonly string? KEY;
    private readonly int TTL; //in hours

    public JwtProvider()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .SetBasePath(Directory.GetCurrentDirectory())
            .Build();
        ISSUER = config["AuthOptions:Issuer"];
        AUDIENCE = config["AuthOptions:Audience"];
        KEY = config["AuthOptions:KEY"];
        TTL = Convert.ToInt32(config["AuthOptions:ExpireHours"]);

    }

    public string GenerateToken(User user)
    {
        var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Username) };
        
        var jwt = new JwtSecurityToken(
            issuer: ISSUER,
            audience: AUDIENCE,
            claims: claims,
            expires: DateTime.Now.Add(TimeSpan.FromHours(TTL)),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY!)),
                SecurityAlgorithms.HmacSha256)
        );

        var tokenValue = new JwtSecurityTokenHandler().WriteToken(jwt);

        return tokenValue;

    }

    public string GetUsername(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadToken(token);
        var tokenS = jsonToken as JwtSecurityToken;
        var username = tokenS!.Claims.First(claim => claim.Type == ClaimTypes.Name).Value;
        
        return username;
    }
}