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

    public async Task<List<Dish>> GetFew(List<int> indexes)
    {
        return await _dataBase.Dishes
            .AsNoTracking()
            .Where(p => (indexes.Contains(p.Id)))
            .ToListAsync();

    }

    public async Task<List<Dish>> GetPage(int page, int size)
    {
        return await _dataBase.Dishes
            .Skip((page - 1) * size)
            .Take(size)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task Add(Dish dish)
    {
        await _dataBase.Dishes.AddAsync(dish);
        await _dataBase.SaveChangesAsync();
        
        return;
    }
}