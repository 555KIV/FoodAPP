using Backend.EntityDb;
using Backend.Model;
using Backend.Repositories;

namespace Backend.Services;

public class UsersService(IUsersRepository usersRepository, IPasswordHasher passwordHasher) : IUsersService
{
    private readonly IUsersRepository _usersRepository = usersRepository;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;

    public async Task<User?> GetUser(string? username)
    {
        return await _usersRepository.Get(username);

    }

    public async Task Register(UserAuthRequest person)
    {
        var hashedPassword = _passwordHasher.Generate(person.Password);

        var user = new User(person.Username, hashedPassword.Item1, hashedPassword.Item2);

        await _usersRepository.Add(user);

        return;
    }

    public async Task<string> Login(string username, string password)
    {
        var user = await _usersRepository.Get(username);

        var verify = _passwordHasher.Verify(password, user.Password, user.Salt);

        if (!verify)
        {
            throw new Exception("Failed to login");
        }
        
        JwtProvider jwtProvider = new JwtProvider();

        var token = jwtProvider.GenerateToken(user);
        
        return token;
    }
}