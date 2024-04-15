using AutoMapper;
using Backend.EntityDb;
using Backend.IRepositories;
using Backend.Model;
using Backend.Repositories;

namespace Backend.Services;

public class DishService(IDishRepository dishRepository, 
                         IIngredientRepository ingredientRepository, 
                         IFavorDishRepository favorDishRepository,
                         IStructuresRepository structuresRepository,
                         IUsersRepository usersRepository,
                         IMapperHelper mapperHelper) : IDishService
{
    private readonly IDishRepository _dishRepository = dishRepository;
    private readonly IIngredientRepository _ingredientRepository = ingredientRepository;
    private readonly IFavorDishRepository _favorDishRepository = favorDishRepository;
    private readonly IStructuresRepository _structuresRepository = structuresRepository;
    private readonly IUsersRepository _usersRepository = usersRepository;
    private readonly IMapperHelper _mapperHelper = mapperHelper;


    public async Task<List<DishesResponse>> GetDishesAll()
    {
        var dishesListEntity = await _dishRepository.GetAll();

        var results = _mapperHelper.MapDishToResponses(dishesListEntity);
        
        return results;

    }

    public async Task<List<DishesResponse>> GetPage(int page, int size)
    {
        var dishesListEntity = await _dishRepository.GetPage(page, size);

        var results = _mapperHelper.MapDishToResponses(dishesListEntity);

        return results;
    }

    public async Task<DishFullResponse> GetDish(int id)
    {
        var dish = await _dishRepository.Get(id);
        
        if (dish == null)
        {
            throw new Exception("Not Found");
        }
        
        var structures = await _structuresRepository.GetAllByIdDish(id);
        var ingredients = new List<Ingredient?>();
        
        foreach (var item in structures)
        {
            ingredients.Add(await _ingredientRepository.Get(item.IdIngredient));
        }

        var result = new DishFullResponse(dish, structures, ingredients);
        
        return result;
    }

    public async Task<List<DishesResponse>> GetDishesLoveAll(string username)
    {
        var user = await _usersRepository.Get(username);
        var favorite = await _favorDishRepository.GetList(user.Id);

        var indexes = new List<int>();
        foreach (var item in favorite)
        {
            indexes.Add(item.IdDish);
        }

        var dishesListEntity = await _dishRepository.GetFew(indexes);
        
        var results = _mapperHelper.MapDishToResponses(dishesListEntity);

        return results;

    }

    public async Task LikeDish(string username, int idDish)
    {
        var user = await _usersRepository.Get(username);

        var dish = await _dishRepository.Get(idDish);

        FavoriteDish? newFavoriteDish = new FavoriteDish(user!.Id, dish!.Id);
        //newFavoriteDish.Dish = dish;
        //newFavoriteDish.User = user;

        await _favorDishRepository.Add(newFavoriteDish);


    }
    
    public async Task<List<string?>> GetIngredAll()
    {
        var listIngred = await _ingredientRepository.GetAll();

        var res = new List<string?>();

        foreach (var item in listIngred)
        {
            res.Add(item.Name);
        }

        return res;
    }

    public async Task<List<DishesResponse>> GetDishesFilter(FilterRequest filterRequest)
    {
        var firstListFilteredDishes = await _dishRepository
            .GetFilterTypeAndCalories(filterRequest.Typefood, filterRequest.Calories);

        var listFilterIngredients = await _ingredientRepository
            .GetFilter(filterRequest.ListLoveIngred, filterRequest.ListNotLoveIngred);

        var listId = _mapperHelper.MapIngredToInt(listFilterIngredients);
        
        var listStructers = await _structuresRepository.GetFilter(listId);

        var listIdDishFromStruc = _mapperHelper.MapStructuresToInt(listStructers);

        var secondFilteredDishes = await _dishRepository.GetFilterIngred(listIdDishFromStruc);

        return _mapperHelper.MapDishToResponses(secondFilteredDishes);

        
    }
}