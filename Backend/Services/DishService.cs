using Backend.Repositories;

namespace Backend.Services;

public class DishService(IDishRepository dishRepository, 
                         IIngredientRepository ingredientRepository, 
                         IFavorDishRepository favorDishRepository) : IDishService
{
    private readonly IDishRepository _dishRepository = dishRepository;
    private readonly IIngredientRepository _ingredientRepository = ingredientRepository;
    private readonly IFavorDishRepository _favorDishRepository = favorDishRepository;
    
    
    
}