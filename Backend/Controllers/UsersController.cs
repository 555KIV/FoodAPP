using Backend.Model;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;


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
            var token = _usersService.Login(loginData.Username!, loginData.Password!);
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
        var user = await _usersService.GetUser(regisData.Username);
        
        if (user != null) 
            return Results.Problem();
        
        await _usersService.Register(regisData);
        
        return Results.Ok();
    }
    
}