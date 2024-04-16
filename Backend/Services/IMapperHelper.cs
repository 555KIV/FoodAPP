using Backend.EntityDb;
using Backend.Model;

namespace Backend.Services;

public interface IMapperHelper
{
    List<DishesResponse> MapDishToResponses(List<Dish> item);

    List<int> MapIngredToInt(List<Ingredient>? item);

    List<int?> MapStructuresToInt(List<Structure>? item);

    Dish MapDishFullToDishEntity(DishFullResponse? item);
}