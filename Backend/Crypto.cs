using System.Security.Cryptography;
using System.Text;

namespace Backend;

public class Crypto
{
    
    public static string HashWithSha256(string value)
    {
        var hash = SHA256.Create();
        var byteArray = hash.ComputeHash(Encoding.UTF8.GetBytes(value));
        return Convert.ToHexString(byteArray);
    }
}