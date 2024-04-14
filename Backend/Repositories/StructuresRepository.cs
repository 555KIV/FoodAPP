using Backend.EntityDb;
using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class StructuresRepository(AppDbContext dataBase) : IStructuresRepository
{
    private readonly AppDbContext _dataBase = dataBase;

    public async Task<List<Structure>> GetAllByIdDish(int id)
    {
        return await _dataBase.Structures
            .Where(item => item.IdDish == id)
            .Include(u=>u.Ingredient)
            .ToListAsync();
    }

    public async Task Add(AddDishRequest dish)
    {
        foreach (var sostav in (from ingre in dish.Ingredients 
                                                    from gram in dish.ListGrammovki 
                                                    from mease in dish.ListMeasurement 
                                                    select  Tuple.Create(ingre, gram, mease)))
        {
            //var intityInBase = new Structure(dish.IdDish, dish.Dish, sostav.Item1.Id, sostav.Item1, sostav.Item2, sostav.Item3);

            //await _dataBase.Structures.AddAsync(intityInBase);

        }

        
    }
}