using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityDb;

public class FavoriteDish(int idUser, int idDish)
{
    [Key]
    public long Id { get; set; }

    public int IdUser { get; set; } = idUser;
    [ForeignKey("IdUser")]
    public User? User { get; set; }

    public int IdDish { get; set; } = idDish;
    [ForeignKey("IdDish")]
    public Dish? Dish { get; set; }
}