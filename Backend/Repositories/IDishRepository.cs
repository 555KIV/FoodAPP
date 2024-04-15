using Backend.EntityDb;

namespace Backend.Repositories;

public interface IDishRepository
{
    Task<Dish?> Get(int id);

    Task<List<Dish>> GetAll();

    Task<List<Dish>> GetPage(int page, int size);

    Task<List<Dish>> GetFew(List<int> indexes);

    Task Add(Dish dish);
}