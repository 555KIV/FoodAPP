using Backend.EntityDb;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class UsersRepository(AppDbContext dataBase) : IUsersRepository
{
    private readonly AppDbContext _dataBase = dataBase;

    public async Task<User?> Get(string? username)
    {
        var userEntity = await _dataBase.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(entity => entity.Username == username);
        return userEntity;
    }

    public async Task Add(User person)
    {
       await _dataBase.Users.AddAsync(person);
       await _dataBase.SaveChangesAsync();
       return;
    }
    
}