using Backend.EntityDb;
using Backend.IRepositories;
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
    public async Task<Ingredient?> GetByName(string name)
    {
        var ingredient = await _dataBase.Ingredients
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.Name == name);
        return ingredient;
    }

    public async Task<List<Ingredient>> GetAll()
    {
        return await _dataBase.Ingredients
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<int> AddByName(string name)
    {
        var ingredient = new Ingredient();
        ingredient.Name = name;
        
        await _dataBase.Ingredients.AddAsync(ingredient);
        await _dataBase.SaveChangesAsync();
        
        var id = await _dataBase.Ingredients
            .AsNoTracking()
            .OrderBy(p => p.Id)
            .LastAsync();
        
        return id.Id;
    }
    
    public async Task<List<Ingredient>?> GetList(List<string?>? listLike)
    {
        return await _dataBase.Ingredients
            .AsNoTracking()
            .Where(p =>
                (listLike!.Contains(p.Name))
            )
            .ToListAsync();
        
    }
}