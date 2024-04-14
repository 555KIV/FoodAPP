using Backend.EntityDb;

namespace Backend.Model;

public class StructureRequest
{
    public int IdDish;

    public Dish? Dish;
    
    public List<Ingredient>? Ingredients;

    public List<short>? ListGrammovki;

    public List<string>? ListMeasurement;
}