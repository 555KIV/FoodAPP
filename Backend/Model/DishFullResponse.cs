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

}