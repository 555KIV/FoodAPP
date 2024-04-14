using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityDb;

//public class Structure( int idDish, Dish? dish, int idIngredient, Ingredient? ingredient, short grammovka, string? measurement)
public class Structure()
{
    [Key]
    public long Id { get; set; }
    public int IdDish { get; set; } 

    [ForeignKey("IdDish")]
    public Dish? Dish { get; set; }

    public int IdIngredient { get; set; } 

    [ForeignKey("IdIngredient")]
    public Ingredient? Ingredient { get; set; }

    public short Grammovka { get; set; } 

    [MaxLength(50)]
    public string? Measurement { get; set; } 
}