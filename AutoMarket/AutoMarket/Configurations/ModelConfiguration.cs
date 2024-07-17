using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AutoMarket.Entities;

namespace AutoMarket.Configurations;

public class ModelConfiguration : IEntityTypeConfiguration<ModelEntity>
{
    public void Configure(EntityTypeBuilder<ModelEntity> builder)
    {
        builder
            .ToTable("Models")
            .HasKey(c => c.Id);

        builder
            .HasOne(c => c.Maker)
            .WithMany(c => c.Models)
            .HasForeignKey(c => c.MakerId);

        builder
            .Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.ReleaseYear)
            .IsRequired();
    }
}