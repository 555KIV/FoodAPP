namespace Backend.Services;

public interface IFileService
{
    Task<string> GetPath(long id);
}