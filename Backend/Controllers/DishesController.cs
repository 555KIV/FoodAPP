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
    private readonly IDishService _dishService = dishService;

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
    [HttpGet("get-love")]
    public async Task<ActionResult<List<DishesResponse>>> GetDishesLoveAll()
    {
        var vuf = this.HttpContext.Request.Headers["Authorization"].ToString();
        string token = vuf.Substring("Bearer ".Length).Trim();
        var jwt = new JwtProvider();
        string username = jwt.GetUsername(token);
        
        return await _dishService.GetDishesLoveAll(username);
    }

    [Authorize]
    [HttpPost("like-dish={idDish}")]
    public async Task<IResult> PostLikeDish(int idDish)
    {
        try
        {
            var vuf = this.HttpContext.Request.Headers["Authorization"].ToString();
            string token = vuf.Substring("Bearer ".Length).Trim();
            var jwt = new JwtProvider();
            string username = jwt.GetUsername(token);
            
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
        var vuf = this.HttpContext.Request.Headers["Authorization"].ToString();
        string token = vuf.Substring("Bearer ".Length).Trim();
        var jwt = new JwtProvider();
        string username = jwt.GetUsername(token);
        
        await _dishService.AddDish(newDish, username);
        
        return Results.Ok();
    }


    [HttpGet("get-all-ingred")]
    public async Task<List<string?>> GetAllIngred()
    {
        return await _dishService.GetIngredAll();
    }

    [HttpPost("filter")]
    public async Task<ActionResult<List<DishesResponse>>> GetByFilter(FilterRequest filterRequest)
    {
        return await _dishService.GetDishesFilter(filterRequest);
    }
    


}