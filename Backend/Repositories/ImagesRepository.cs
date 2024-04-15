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

    public async Task Add(string image, int idDish)
    {
        var item = new Image
        {
            IdDish = idDish,
            Path = image
        };
        await _dataBase.Images.AddAsync(item);
        await _dataBase.SaveChangesAsync();

        var idImage = await _dataBase.Images
            .AsNoTracking()
            .OrderBy(p => p.Id)
            .LastAsync();
        
        var dish = await _dataBase.Dishes
            .FirstOrDefaultAsync(p => p.Id == idDish);
        
        dish!.IdImageLow = idImage.Id;
        
        await _dataBase.SaveChangesAsync();

    }
}