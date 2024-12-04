using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insfrastructure.Dal.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        // Таблица и ключ
        builder.ToTable(nameof(Country));
        builder.HasKey(c => c.Id);

        // Поля
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Code)
            .IsRequired()
            .HasMaxLength(10);

        // Навигационная связь "один ко многим" с Drug
        builder.HasMany(c => c.Drugs)
            .WithOne(d => d.Country)
            .HasForeignKey(d => d.CountryCodeId)
            .OnDelete(DeleteBehavior.Cascade);

        // Индексы
        builder.HasIndex(c => c.Name).IsUnique();
        builder.HasIndex(c => c.Code).IsUnique();
    }
}