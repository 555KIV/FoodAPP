using Backend.EntityDb;
using Backend.Model;

namespace Backend.IRepositories;

public interface IStructuresRepository
{
    Task<List<Structure>> GetAllByIdDish(int id);

    Task<List<Structure>> GetFilter(List<int>? listIngred);

    Task Add(AddDishRequest dish);
    
    
}