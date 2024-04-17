using AutoMapper;
using Backend.EntityDb;
using Backend.IRepositories;
using Backend.Model;
using Backend.Services;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class StructuresRepository(AppDbContext dataBase) : IStructuresRepository
{
    private readonly AppDbContext _dataBase = dataBase;

    public async Task<List<Structure>> GetAllByIdDish(int id)
    {
        return await _dataBase.Structures
            .Where(item => item.IdDish == id)
            .Include(u=>u.Ingredient)
            .ToListAsync();
    }
    public async Task<List<Structure>> GetAllByNotIngred(List<int> idIngred)
    {
        return await _dataBase.Structures
            .Where(item => idIngred.Contains(item.IdIngredient))
            .Include(u=>u.Ingredient)
            .ToListAsync();
    }

    public async Task Add(Structure dishStruct)
    {
        await _dataBase.Structures.AddAsync(dishStruct);

    }

    public async Task<List<Structure>> GetFilter(List<int>? listLoveInger,List<int>? listNotLoveInger)
    {
        return await _dataBase.Structures
            .AsNoTracking()
            .Where(p=> 
                (listLoveInger!.Contains(p.IdIngredient)) &&
                (!listNotLoveInger!.Contains(p.IdIngredient))
                )
            .ToListAsync();
    }
}