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

        DishFullResponse result = new DishFullResponse();// new DishFullResponse(dish, structures, ingredients);
        result.Id = (int)dish.Id!;
        result.Name = dish.Name;
        result.Calories = dish.Calories;
        result.Carbohydrates = dish.Carbohydrates;
        result.Fats = dish.Fats;
        result.Squirrels = dish.Squirrels;
        result.Recipe = dish.Recipe;
        result.CookingTime = dish.CookingTime;
        result.IdImageLow = (int)dish.IdImageLow!;
        result.TypeFood = dish.TypeFood;
        result.Ingredients = new();
        
        foreach (var item in structures)
        {
            result.Ingredients!.Add((ingredients.FirstOrDefault(p=>p.Id==item.IdIngredient)!.Name) 
                             + " " + item.Grammovka + " " +item.Measurement);
        }
        
        
        return result;
    }

    public async Task<List<DishesResponse>> GetDishesLoveAll(string username)
    {
        var user = await _usersRepository.Get(username);
        var favorite = await _favorDishRepository.GetList(user.Id!);

        var indexes = new List<int?>();
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

        var dish = await _dishRepository.Get((int)idDish!);

        FavoriteDish? newFavoriteDish = new FavoriteDish(user!.Id, (int)dish!.Id!);

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

        var listLoveIngredients = await _ingredientRepository
            .GetList(filterRequest.ListLoveIngred);
        
        var listNotLoveIngredients = await _ingredientRepository
            .GetList(filterRequest.ListLoveIngred);

        var listIdLove = _mapperHelper.MapIngredToInt(listLoveIngredients);
        var listIdNotLove = _mapperHelper.MapIngredToInt(listNotLoveIngredients);
        
        var listStructers = await _structuresRepository.GetFilter(listIdLove, listIdNotLove);

        List<int?> listIdDishFromStruc = _mapperHelper.MapStructuresToInt(listStructers);

        var secondFilteredDishes = await _dishRepository.GetFilterIngred(listIdDishFromStruc);

        return _mapperHelper.MapDishToResponses(secondFilteredDishes);

        
    }

    public async Task AddDish(DishFullResponse dish, string username)
    {
        var dishEntity = _mapperHelper.MapDishFullToDishEntity(dish);

        dishEntity.Id = null;
        
        var idDish = await _dishRepository.Add(dishEntity);

        
        
        foreach (var item in dish.Ingredients!)
        {
            var structDish = new Structure();
            
            var bufferSplit = item!.Split();
            
            structDish.IdDish = (int)idDish!; 
            structDish.Grammovka = Convert.ToInt16(bufferSplit[1]);
            structDish.Measurement = bufferSplit[2];

            var ingred = await _ingredientRepository.GetByName(bufferSplit[0]);

            if (ingred == null)
            {
                var idIngre = await _ingredientRepository.AddByName(bufferSplit[0]);
                structDish.IdIngredient = idIngre;
            }
            else
            {
                structDish.IdIngredient = ingred.Id;
            }

            await _structuresRepository.Add(structDish);

        }

        await LikeDish(username, (int)idDish!);

    }
}