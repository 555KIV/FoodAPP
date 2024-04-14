using System.ComponentModel.DataAnnotations;

namespace Backend.EntityDb;

public class Ingredient
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(100)]
    public string? Name { get; set; }
}