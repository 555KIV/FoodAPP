using System.Security.Cryptography;

namespace Backend.Services;

public class PasswordHasher : IPasswordHasher
{
    public Tuple<string,string> Generate(string? password)
    {
        var saltByte = RandomNumberGenerator.GetBytes(10);
        var salt = System.Text.Encoding.UTF8.GetString(saltByte);
        string? bufferHash = Crypto.HashWithSha256(password+salt);
        return new Tuple<string, string>(bufferHash, salt);
    }

    public bool Verify(string password, string passwordHash, string salt)
    {
        var bufferHash = Crypto.HashWithSha256(password + salt);

        return bufferHash == passwordHash;

    }
}