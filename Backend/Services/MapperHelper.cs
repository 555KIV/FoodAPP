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
    
    public List<int> MapIngredToInt(List<Ingredient>? item)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Ingredient, int>()
            .ConstructUsing(source => source.Id));

        var mapper = new Mapper(config);

        var results = mapper.Map<List<Ingredient>, List<int>>(item!);

        return results;
    }
    public List<int?> MapStructuresToInt(List<Structure>? item)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Structure, int>()
            .ConstructUsing(source => source.IdDish));

        var mapper = new Mapper(config);

        List<int?> results = mapper.Map<List<Structure>, List<int?>>(item!);

        return results;
    }

    public Dish MapDishFullToDishEntity(DishFullResponse? item)
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<DishFullResponse, Dish>());

        var mapper = new Mapper(config);

        var results = mapper.Map<DishFullResponse, Dish>(item!);

        return results;
        
    }

    
    
}