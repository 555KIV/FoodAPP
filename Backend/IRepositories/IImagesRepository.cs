using Backend.EntityDb;

namespace Backend.Repositories;

public interface IImagesRepository
{
    Task<Image?> Get(long id);

    Task Add(string image, int idDish);
}