using Backend.EntityDb;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class DishRepository(AppDbContext dataBase) : IDishRepository
{
    private readonly AppDbContext _dataBase = dataBase;
    
    public async Task<Dish?> Get(int id)
    {
        var dishEntite = await _dataBase.Dishes
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.Id == id);
        return dishEntite;

    }

    public async Task<List<Dish>> GetAll()
    {
        return await _dataBase.Dishes.AsNoTracking().ToListAsync();
    }

    public async Task Add(Dish dish)
    {
        await _dataBase.Dishes.AddAsync(dish);
        await _dataBase.SaveChangesAsync();
        
        return;
    }
}