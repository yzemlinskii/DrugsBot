using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insfrastructure.Dal.Configurations;

public class DrugStoreConfiguration : IEntityTypeConfiguration<DrugStore>
{
    public void Configure(EntityTypeBuilder<DrugStore> builder)
    {
        // Таблица и ключ
        builder.ToTable(nameof(DrugStore));
        builder.HasKey(x => x.Id);

        // Поля
        builder.Property(x => x.DrugNetwork)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Number)
            .IsRequired();

        // Навигационная связь "один ко многим" с DrugItem
        builder.HasMany(ds => ds.DrugItems)
            .WithOne(di => di.DrugStore)
            .HasForeignKey(di => di.DrugStoreId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}