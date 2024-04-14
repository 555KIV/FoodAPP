using Backend.EntityDb;

namespace Backend.Repositories;

public interface IUsersRepository
{
    Task<User?> Get(string? username);
    Task Add(User person);
}