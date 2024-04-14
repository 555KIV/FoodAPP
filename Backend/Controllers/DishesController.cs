using Backend.EntityDb;
using Backend.Model;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/dishes")]
public class DishesController(IDishService dishService) : ControllerBase
{
    private IDishService _dishService = dishService;

    [HttpGet("get-all")]
    public async Task<ActionResult<List<DishesResponse>>> GetDishesAll()
    {
        return await _dishService.GetDishesAll();
    }

    [HttpGet("get-page={page};size={size}")]
    public async Task<ActionResult<List<DishesResponse>>> GetPage(int page, int size)
    {
        return await _dishService.GetPage(page, size);
    }

    [HttpGet("get-dish={id}")]
    public async Task<ActionResult<DishFullResponse>> GetDish(int id)
    {
        try
        {
            return await _dishService.GetDish(id);
        }
        catch (Exception e)
        {
            return NotFound();
        }
    }

    [Authorize]
    [HttpGet("get-love={username}")]
    public async Task<ActionResult<List<DishesResponse>>> GetDishesLoveAll(string username)
    {
        return await _dishService.GetDishesLoveAll(username);
    }

    [Authorize]
    [HttpPost("like-dish={username};{idDish}")]
    public async Task<IResult> PostLikeDish(string username, int idDish)
    {
        try
        {
            await _dishService.LikeDish(username, idDish);
            
            return Results.Ok();
        }
        catch (Exception e)
        {
            return Results.Problem();
        }
        
    }
    
    
    [Authorize]
    [HttpPost("create-dish")]
    public async Task<IResult> PostAddDish(DishFullResponse newDish)
    {

        
        
        return Results.Ok();
    }
    
}