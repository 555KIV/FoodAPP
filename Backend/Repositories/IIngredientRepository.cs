using Backend.EntityDb;

namespace Backend.Repositories;

public interface IIngredientRepository
{
    Task<Ingredient?> Get(int id);

    Task<List<Ingredient>> GetAll();

    Task Add(Ingredient ingredient);

}