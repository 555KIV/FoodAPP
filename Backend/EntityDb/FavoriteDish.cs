using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityDb;

public class FavoriteDish
{
    public int IdUser { get; set; }
    [ForeignKey("IdUsers")]
    public User? User { get; set; }
    
    public int IdDish { get; set; }
    [ForeignKey("IdDish")]
    public Dish? Dish { get; set; }
}