using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityDb;

public class Image
{
    [Key]
    public long Id { get; set; }
    
    public int IdDish { get; set; }
    [ForeignKey("IdDish")]
    public Dish? Dish { get; set; }
    
    public string? Path { get; set; }
    
}