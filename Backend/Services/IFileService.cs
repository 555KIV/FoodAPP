namespace Backend.Services;

public interface IFileService
{
    Task<string> GetPath(long id);

    Task AddFile(IFormFile file, int idDish);
}