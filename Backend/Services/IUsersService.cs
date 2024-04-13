using Backend.EntityDb;
using Backend.Model;

namespace Backend.Services;

public interface IUsersService
{
    Task<User?> GetUser(string? username);

    Task Register(UserAuthRequest person);

    Task<string> Login(string username, string password);




}