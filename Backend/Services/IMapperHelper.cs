using Backend.EntityDb;
using Backend.Model;

namespace Backend.Services;

public interface IMapperHelper
{
    List<DishesResponse> MapDishToResponses(List<Dish> item);
}