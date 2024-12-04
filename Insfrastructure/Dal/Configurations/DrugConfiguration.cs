using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insfrastructure.Dal.Configurations;

public class DrugConfiguration : IEntityTypeConfiguration<Drug>
{
    public void Configure(EntityTypeBuilder<Drug> builder)
    {
        // Таблица и ключ
        builder.ToTable(nameof(Drug));
        builder.HasKey(x => x.Id);

        // Поля
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.Manufacturer)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.CountryCodeId)
            .IsRequired();

        // Связь "многие к одному" с Country
        builder.HasOne(d => d.Country)
            .WithMany(c => c.Drugs)
            .HasForeignKey(d => d.CountryCodeId)
            .OnDelete(DeleteBehavior.Cascade);

        // Навигационная связь "один ко многим" с DrugItem
        builder.HasMany(d => d.DrugItems)
            .WithOne(di => di.Drug)
            .HasForeignKey(di => di.DrugId)
            .OnDelete(DeleteBehavior.Cascade);

        // Индексы
        builder.HasIndex(x => x.Name).IsUnique();
    }
}