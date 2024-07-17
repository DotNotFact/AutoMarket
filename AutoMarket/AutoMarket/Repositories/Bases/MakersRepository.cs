using AutoMarket.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using AutoMarket.Entities;
using AutoMarket.Data;

namespace AutoMarket.Repositories.Bases;

public class MakersRepository(ApplicationDbContext context) : IRepository<MakerEntity>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<MakerEntity>> GetAllAsync()
    {
        var entities = await _context.Makers
            .Include(c => c.Models)
            .ToListAsync();

        return entities;
    }

    public async Task<MakerEntity> GetByIdAsync(Guid id)
    {
        var entity = await _context.Makers
            .Include(c => c.Models)
            .FirstOrDefaultAsync(c => c.Id == id);

        return entity;
    }

    public async Task AddAsync(MakerEntity entity)
    {
        await _context.Makers.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(MakerEntity entity)
    {
        await _context.Makers
            .Where(c => c.Id == entity.Id)
            .ExecuteUpdateAsync(sp => sp
                .SetProperty(c => c.Name, entity.Name)
                .SetProperty(c => c.Country, entity.Country)
                .SetProperty(c => c.FoundedYear, entity.FoundedYear));
    }

    public async Task DeleteAsync(Guid id)
    {
        await _context.Makers
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();
    }
}