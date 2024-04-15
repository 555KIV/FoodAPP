using Backend.EntityDb;

namespace Backend.Model;

public class DishFullResponse
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public short Calories { get; set; }

    public short Carbohydrates { get; set; }

    public short Fats { get; set; }

    public short Squirrels { get; set; }

    public string? Recipe { get; set; }

    public string? CookingTime { get; set; }
    
    public long IdImageLow { get; set; }
    
    public string? TypeFood { get; set; }
    
    public List<string?>? Ingredients { get; set; }
    //public string? IngredientsStr { get; set; }
    //public string? GrammovkiStr { get; set; }
    //public string? MeasurementStr { get; set; }

    public List<short>? ListGrammovki { get; set; }

    public List<string?>? ListMeasurement { get; set; }

    public DishFullResponse(Dish dish, List<Structure> structures, List<Ingredient> ingredients)
    {
        Id = dish.Id;
        Name = dish.Name;
        Calories = dish.Calories;
        Carbohydrates = dish.Carbohydrates;
        Fats = dish.Fats;
        Squirrels = dish.Squirrels;
        Recipe = dish.Recipe;
        CookingTime = dish.CookingTime;
        IdImageLow = dish.IdImageLow;
        TypeFood = dish.TypeFood;
        Ingredients = new();
        ListGrammovki = new();
        ListMeasurement = new();
        
        foreach (var item in structures)
        {
            // IngredientsStr += ingredients.FirstOrDefault(p => p.Id == item.IdIngredient)!.Name + ";";
            // GrammovkiStr += item.Grammovka;
            // MeasurementStr += item.Measurement;
            
            ListGrammovki!.Add(item.Grammovka);
            ListMeasurement!.Add(item.Measurement);
            Ingredients!.Add(ingredients.FirstOrDefault(p=>p.Id==item.IdIngredient)!.Name);
        }
    }
}