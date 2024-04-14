using AutoMapper;
using Backend.EntityDb;
using Backend.Model;

namespace Backend.Services;

public class MapperHelper : IMapperHelper
{
    public List<DishesResponse> MapDishToResponses(List<Dish> item)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Dish, DishesResponse>());

        var mapper = new Mapper(config);

        var results = mapper.Map<List<Dish>, List<DishesResponse>>(item);

        return results;
    }
    
    
    
}