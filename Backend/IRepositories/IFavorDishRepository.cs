using Backend.EntityDb;

namespace Backend.Repositories;

public interface IFavorDishRepository
{
    Task<List<FavoriteDish>> GetList(long idUser);
    
    Task Add(FavoriteDish favoriteDish);
}