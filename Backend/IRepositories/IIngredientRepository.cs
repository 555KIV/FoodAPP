using Backend.EntityDb;

namespace Backend.IRepositories;

public interface IIngredientRepository
{
    Task<Ingredient?> Get(int id);

    Task<Ingredient?> GetByName(string name);

    Task<List<Ingredient>> GetAll();

    Task<int> AddByName(string name);

    Task<List<Ingredient>?> GetList(List<string?>? listLike);

}