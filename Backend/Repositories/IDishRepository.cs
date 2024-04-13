using Backend.EntityDb;

namespace Backend.Repositories;

public interface IDishRepository
{
    Task<Dish?> Get(int id);

    Task<List<Dish>> GetAll();

    Task Add(Dish dish);
}