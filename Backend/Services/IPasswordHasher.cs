namespace Backend.Services;

public interface IPasswordHasher
{
    Tuple<string, string> Generate(string? password);

    bool Verify(string password, string passwordHash, string salt);

}