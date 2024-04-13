using Microsoft.EntityFrameworkCore;
using Backend.EntityDb;

namespace Backend;

public sealed class AppDbContext: DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Dish> Dishes => Set<Dish>();
    public DbSet<FavoriteDish> FavoriteDishes => Set<FavoriteDish>();
    public DbSet<Ingredient> Ingredients => Set<Ingredient>();
    

    public AppDbContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .SetBasePath(Directory.GetCurrentDirectory())
            .Build();
        //optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=foodapp;Username=postgres;Password=R#17ad6Z");
        optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));
    }
}