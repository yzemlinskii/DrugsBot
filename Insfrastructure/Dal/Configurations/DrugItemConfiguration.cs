using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insfrastructure.Dal.Configurations;

public class DrugItemConfiguration : IEntityTypeConfiguration<DrugItem>
{
    public void Configure(EntityTypeBuilder<DrugItem> builder)
    {
        // Таблица и ключ
        builder.ToTable(nameof(DrugItem));
        builder.HasKey(x => x.Id);

        // Поля
        builder.Property(x => x.Cost)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.Count)
            .IsRequired();

        // Связь "многие к одному" с Drug
        builder.HasOne(di => di.Drug)
            .WithMany(d => d.DrugItems)
            .HasForeignKey(di => di.DrugId)
            .OnDelete(DeleteBehavior.Cascade);

        // Связь "многие к одному" с DrugStore
        builder.HasOne(di => di.DrugStore)
            .WithMany(ds => ds.DrugItems)
            .HasForeignKey(di => di.DrugStoreId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}