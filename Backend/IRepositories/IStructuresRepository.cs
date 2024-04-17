using Backend.EntityDb;
using Backend.Model;

namespace Backend.IRepositories;

public interface IStructuresRepository
{
    Task<List<Structure>> GetAllByIdDish(int id);

    Task<List<Structure>> GetFilter(List<int>? listLoveInger, List<int>? listNotLoveInger);

    Task Add(Structure dishStruct);
    Task<List<Structure>> GetAllByNotIngred(List<int> idIngred);

}