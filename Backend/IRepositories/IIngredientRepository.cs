using Backend.EntityDb;

namespace Backend.IRepositories;

public interface IIngredientRepository
{
    Task<Ingredient?> Get(int id);

    Task<List<Ingredient>> GetAll();

    Task Add(Ingredient ingredient);

    Task<List<Ingredient>?> GetFilter(List<string?>? listLike, List<string?>? listNot);

}