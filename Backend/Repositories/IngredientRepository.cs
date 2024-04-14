using Backend.EntityDb;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class IngredientRepository(AppDbContext dataBase) : IIngredientRepository
{
    private readonly AppDbContext _dataBase = dataBase;

    public async Task<Ingredient?> Get(int id)
    {
        var ingredient = await _dataBase.Ingredients
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.Id == id);
        return ingredient;
    }

    public async Task<List<Ingredient>> GetAll()
    {
        return await _dataBase.Ingredients.AsNoTracking().ToListAsync();
    }

    public async Task Add(Ingredient ingredient)
    {
        await _dataBase.Ingredients.AddAsync(ingredient);
        await _dataBase.SaveChangesAsync();
        
        return;
    }
}