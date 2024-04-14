using Backend.EntityDb;
using Backend.Model;

namespace Backend.Repositories;

public interface IStructuresRepository
{
    Task<List<Structure>> GetAllByIdDish(int id);

    Task Add(StructureRequest dish);
}