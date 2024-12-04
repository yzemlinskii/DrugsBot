using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insfrastructure.Dal.Configurations;

public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        // Таблица и ключ
        builder.ToTable(nameof(Profile));
        builder.HasKey(p => p.Id);

        // Поля
        builder.Property(p => p.ExternalId)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Email)
            .HasConversion(
                email => email!.ToString(),
                emailString => new Email(emailString))
            .HasMaxLength(200);

        // Навигационная связь "один ко многим" с FavoriteDrug
        builder.HasMany(p => p.FavoriteDrugs)
            .WithOne(fd => fd.Profile)
            .HasForeignKey(fd => fd.ProfileId)
            .OnDelete(DeleteBehavior.Cascade);

        // Индексы
        builder.HasIndex(p => p.ExternalId).IsUnique();
    }
}