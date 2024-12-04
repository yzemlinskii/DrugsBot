using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insfrastructure.Dal.Configurations;

public class FavoriteDrugConfiguration : IEntityTypeConfiguration<FavoriteDrug>
{
    public void Configure(EntityTypeBuilder<FavoriteDrug> builder)
    {
        // Таблица и ключ
        builder.ToTable(nameof(FavoriteDrug));
        builder.HasKey(fd => new { fd.ProfileId, fd.DrugId });

        // Поля
        builder.Property(fd => fd.ProfileId)
            .IsRequired();

        builder.Property(fd => fd.DrugId)
            .IsRequired();

        builder.Property(fd => fd.DrugStoreId)
            .IsRequired(false);

        // Связь "многие к одному" с Profile
        builder.HasOne(fd => fd.Profile)
            .WithMany(p => p.FavoriteDrugs)
            .HasForeignKey(fd => fd.ProfileId)
            .OnDelete(DeleteBehavior.Cascade);

        // Связь "многие к одному" с Drug
        builder.HasOne(fd => fd.Drug)
            .WithMany()
            .HasForeignKey(fd => fd.DrugId)
            .OnDelete(DeleteBehavior.Cascade);

        // Связь "многие к одному" с DrugStore
        builder.HasOne(fd => fd.DrugStore)
            .WithMany()
            .HasForeignKey(fd => fd.DrugStoreId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}