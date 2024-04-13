using System.ComponentModel.DataAnnotations;

namespace Backend.EntityDb;

public class Ingredient
{
    [Key]
    public int Id { get; set; }
    
    public string? Name { get; set; }
}