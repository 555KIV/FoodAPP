using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Backend.EntityDb;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Controllers;


[ApiController]
[Route("api/users")]
public class UsersController(AppDbContext dataBase) : ControllerBase
{
    private readonly AppDbContext _dataBase = dataBase;
    private readonly AuthOptions _authOptions = new();

  
    [HttpPost]
    public IResult PostLogin(User loginData)
    {
        User? person = _dataBase.Users.FirstOrDefault(p => p.Username == loginData.Username && p.Password == loginData.Password);
        
        if (person is null) return Results.Unauthorized();

        var claims = new List<Claim> { new Claim(ClaimTypes.Name, person.Username) };

        var jwt = new JwtSecurityToken(
            issuer: _authOptions.ISSUER,
            audience: _authOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.Now.Add(TimeSpan.FromMinutes(2)),
            signingCredentials: new SigningCredentials(_authOptions.GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256)
        );

        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        var response = new
        {
            access_token = encodedJwt,
            username = person.Username
        };
        
        return Results.Json(response);
    }
    
    [Authorize]
    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = new[]
        {
            new { Name = "Oleg" },
            new { Name = "Ivan" }
        };
        return Ok(users);
    }
}