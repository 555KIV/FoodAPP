using System.ComponentModel.DataAnnotations;

namespace Backend.EntityDb;

public class Dish
{
    [Key]
    public int Id { get; set; }
    
    public string? Name { get; set; }
    
    public short Calories { get; set; }
    
    public short Carbohydrates { get; set; }
    
    public short Fats { get; set; }
    
    public short Squirrels { get; set; }
    
    public string? Recipe { get; set; }
    
    public int[]? Ingredients { get; set; }
    
    public int[]? Grammovka { get; set; }
}