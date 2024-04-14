using Backend.EntityDb;

namespace Backend.Repositories;

public interface IFavorDishRepository
{
    Task<List<FavoriteDish>> GetList(int idUser);
    
    Task Add(FavoriteDish favoriteDish);
}