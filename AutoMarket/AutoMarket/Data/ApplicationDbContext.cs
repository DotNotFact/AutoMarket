using Microsoft.EntityFrameworkCore;
using AutoMarket.Extensions;
using AutoMarket.Entities;

namespace AutoMarket.Data;

public class ApplicationDbContext(IConfiguration configuration) : DbContext
{
    private readonly IConfiguration _configuration = configuration;

    public DbSet<MakerEntity> Makers { get; set; }
    public DbSet<ModelEntity> Models { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); 
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly); 
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionStringOrThrow(nameof(ApplicationDbContext)));
    }
}