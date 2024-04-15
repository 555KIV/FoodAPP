using System.ComponentModel.DataAnnotations;

namespace Backend.EntityDb;

public class Dish
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(100)]
    public string? Name { get; set; }
    
    public short Calories { get; set; }
    
    public short Carbohydrates { get; set; }
    
    public short Fats { get; set; }
    
    public short Squirrels { get; set; }
    
    public string? Recipe { get; set; }
    
    [MaxLength(20)]
    public string? CookingTime { get; set; }

    public long IdImageLow { get; set; }
    
    public long IdImageLarge { get; set; }
    
    public string? TypeFood { get; set; }
   
}

