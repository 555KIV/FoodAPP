using Backend.EntityDb;

namespace Backend.IRepositories;

public interface IDishRepository
{
    Task<Dish?> Get(int id);

    Task<List<Dish>> GetAll();

    Task<List<Dish>> GetPage(int page, int size);

    Task<List<Dish>> GetFew(List<int?> indexes);

    Task<int?> Add(Dish dish);

    Task<List<Dish>> GetFilterTypeAndCalories(string? typefood, Tuple<short, short>? calories);

    Task<List<Dish>> GetFilterIngred(List<int> listId);

    Task<List<Dish>> GetFilteredById(List<int?> finalFilteredDishes);
}