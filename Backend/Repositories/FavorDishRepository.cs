using Backend.EntityDb;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class FavorDishRepository(AppDbContext dataBase) : IFavorDishRepository
{
    private readonly AppDbContext _dataBase = dataBase;

    public async Task<List<FavoriteDish>> GetList(int idUser)
    {
        return await _dataBase
            .FavoriteDishes
            .Where(item => item.IdUser == idUser)
            .ToListAsync();
    }

    public async Task Add(FavoriteDish favoriteDish)
    {
        await _dataBase.FavoriteDishes.AddAsync(favoriteDish);
        await _dataBase.SaveChangesAsync();
        
        return;
    }
}