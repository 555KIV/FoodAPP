using Backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Services;

public class FileService(IImagesRepository imagesRepository) : IFileService
{
    private readonly IImagesRepository _imagesRepository = imagesRepository;

    public async Task<string> GetPath(long id)
    {
        var image = await _imagesRepository.Get(id);

        return Path.Combine(Directory.GetCurrentDirectory(), "Files", image.Path);
        
    }

    public async Task AddFile(IFormFile file, int idDish)
    {
        await _imagesRepository.Add(file.FileName, idDish);
        
        var path = Path.Combine(Directory.GetCurrentDirectory(), "Files", file.FileName);
        using (var fileStream = new FileStream(path, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        
    }
}