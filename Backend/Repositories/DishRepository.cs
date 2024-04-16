using Backend.EntityDb;
using Backend.IRepositories;
using Backend.Model;
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

    public async Task<List<Dish>> GetFew(List<int?> indexes)
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

    public async Task<int?> Add(Dish dish)
    {
        await _dataBase.Dishes.AddAsync(dish);
        await _dataBase.SaveChangesAsync();
        
        var id = await _dataBase.Dishes
            .AsNoTracking()
            .OrderBy(p => p.Id)
            .LastAsync();
        
        return id.Id;
    }

    public async Task<List<Dish>> GetFilterTypeAndCalories(string? typefood, Tuple<short, short>? calories)
    {
        return await _dataBase.Dishes
            .AsNoTracking()
            .Where(p => 
                (typefood == p.TypeFood) &&
                (calories!.Item1<=p.Calories && calories!.Item2>=p.Calories)
            )
            .ToListAsync();

    }

    public async Task<List<Dish>> GetFilterIngred(List<int?> listId)
    {
        return await _dataBase.Dishes
            .AsNoTracking()
            .Where(p => listId.Contains(p.Id))
            .ToListAsync();

    }
}