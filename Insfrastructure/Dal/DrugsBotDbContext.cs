using Domain.Entities;
using Insfrastructure.Dal.Configurations;
using Insfrastructure.Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Insfrastructure.Dal;

public class DrugsBotDbContext : DbContext
{
    private readonly DatabaseSettings _options;

    public DrugsBotDbContext(IOptions<DatabaseSettings> options)
    {
        _options = options.Value;
    }
    
    /// <summary>
    /// Таблица препаратов.
    /// </summary>
    public DbSet<Drug> Drugs { get; set; }

    /// <summary>
    /// Таблица стран.
    /// </summary>
    public DbSet<Country> Countries { get; set; }

    /// <summary>
    /// Таблица связей препаратов с аптеками.
    /// </summary>
    public DbSet<DrugItem> DrugItems { get; set; }

    /// <summary>
    /// Таблица аптек.
    /// </summary>
    public DbSet<DrugStore> DrugStores { get; set; }

    /// <summary>
    /// Таблица избранных препаратов.
    /// </summary>
    public DbSet<FavoriteDrug> FavoriteDrugs { get; set; }

    /// <summary>
    /// Таблица профилей пользователей.
    /// </summary>
    public DbSet<Profile> Profiles { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Конфигурации сущностей
        modelBuilder.ApplyConfiguration(new DrugConfiguration());
        modelBuilder.ApplyConfiguration(new DrugItemConfiguration());
        modelBuilder.ApplyConfiguration(new DrugStoreConfiguration());
        modelBuilder.ApplyConfiguration(new CountryConfiguration());
        modelBuilder.ApplyConfiguration(new ProfileConfiguration());
        modelBuilder.ApplyConfiguration(new FavoriteDrugConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_options.ConnectionString, (options) =>
        {
            options.CommandTimeout(_options.CommandTimeout);
        });
    }
}