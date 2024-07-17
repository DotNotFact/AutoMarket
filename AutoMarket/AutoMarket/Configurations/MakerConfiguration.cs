using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AutoMarket.Entities;

namespace AutoMarket.Configurations;

public class MakerConfiguration : IEntityTypeConfiguration<MakerEntity>
{
    public void Configure(EntityTypeBuilder<MakerEntity> builder)
    {
        builder
            .ToTable("Makers")
            .HasKey(c => c.Id);

        builder 
            .HasMany(c => c.Models)
            .WithOne(c => c.Maker)
            .HasForeignKey(c => c.MakerId);

        builder 
            .Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(c => c.Country)
            .HasMaxLength(100);

        builder
            .Property(c => c.FoundedYear)
            .IsRequired(); 
    }
}