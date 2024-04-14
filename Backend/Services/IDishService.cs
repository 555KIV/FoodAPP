using Backend.Model;

namespace Backend.Services;

public interface IDishService
{
    Task<List<DishesResponse>> GetDishesAll();

    Task<List<DishesResponse>> GetPage(int page, int size);

    Task<DishFullResponse> GetDish(int id);

    Task<List<DishesResponse>> GetDishesLoveAll(string username);

    Task LikeDish(string username, int idDish);
}