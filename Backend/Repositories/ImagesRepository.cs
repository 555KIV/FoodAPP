using Backend.EntityDb;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class ImagesRepository(AppDbContext dataBase) : IImagesRepository
{
    private readonly AppDbContext _dataBase = dataBase;

    public async Task<Image?> Get(long id)
    {
        return await _dataBase.Images
            .AsNoTracking()
            .FirstOrDefaultAsync(item => item.Id == id);
    }

    public async Task Add(Image image)
    {
        await _dataBase.Images.AddAsync(image);
        await _dataBase.SaveChangesAsync();
    }
}