using Microsoft.EntityFrameworkCore;
using Backend.EntityDb;

namespace Backend;

public sealed class AppDbContext: DbContext
{
    public DbSet<User> Users => Set<User>();

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

        optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));
    }
}