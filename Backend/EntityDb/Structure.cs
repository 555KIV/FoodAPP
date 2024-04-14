using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityDb;

public class Structure( int idDish, Dish? dish, int idIngredient, Ingredient? ingredient, short grammovka, string? measurement)
{
    public int IdDish { get; set; } = idDish;

    [ForeignKey("IdDish")]
    public Dish? Dish { get; set; } = dish;

    public int IdIngredient { get; set; } = idIngredient;

    [ForeignKey("IdIngredient")]
    public Ingredient? Ingredient { get; set; } = ingredient;

    public short Grammovka { get; set; } = grammovka;

    [MaxLength(50)]
    public string? Measurement { get; set; } = measurement;
}