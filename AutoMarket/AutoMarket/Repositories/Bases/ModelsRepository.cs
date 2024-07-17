using AutoMarket.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using AutoMarket.Entities;
using AutoMarket.Data;

namespace AutoMarket.Repositories.Bases;

public class ModelsRepository(ApplicationDbContext context) : IRepository<ModelEntity>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<ModelEntity>> GetAllAsync()
    {
        var entities = await _context.Models
            .Include(c => c.Maker)
            .ToListAsync();

        return entities;
    }

    public async Task<ModelEntity> GetByIdAsync(Guid id)
    {
        var entity = await _context.Models
            .Include(c => c.Maker)
            .FirstOrDefaultAsync(c => c.Id == id);

        return entity;
    }

    public async Task AddAsync(ModelEntity entity)
    {
        await _context.Models.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ModelEntity entity)
    {
        await _context.Models
            .Where(c => c.Id == entity.Id)
            .ExecuteUpdateAsync(sp => sp
                .SetProperty(c => c.Name, entity.Name)
                .SetProperty(c => c.ReleaseYear, entity.ReleaseYear));
    }

    public async Task DeleteAsync(Guid id)
    {
        await _context.Models
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();
    }
}