using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Backend.EntityDb;
using Backend.Model;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Controllers;


[ApiController]
[Route("api/auth")]
public class UsersController(IUsersService userService) : ControllerBase
{
    
    private readonly IUsersService _usersService = userService;

  
    [HttpPost("login")]
    public async Task<IResult> PostLogin(UserAuthRequest loginData)
    {

        var person = await _usersService.GetUser(loginData.Username);
        
        if (person is null) return Results.NotFound();

        try
        {
            var token = _usersService.Login(loginData.Username, loginData.Password);
            UserAuthResponse response = new UserAuthResponse(loginData.Username, token.Result);
        
            return Results.Json(response);
        }
        catch (Exception e)
        {
            return Results.Unauthorized();
        }
        
    }


    [HttpPost("register")]
    public async Task<IResult> PostRegistr(UserAuthRequest regisData)
    {
        await _usersService.Register(regisData);
        
        return Results.Ok();
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