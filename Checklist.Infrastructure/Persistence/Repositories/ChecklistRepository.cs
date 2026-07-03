using Checklist.Application.Interfaces;
using Checklist.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Checklist.Infrastructure.Persistence.Repositories;

public class ChecklistRepository : IChecklistRepository
{
    private readonly ApplicationDbContext _context;

    public ChecklistRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Domain.Entities.Checklist>> GetAllAsync(Guid userId)
    {
        return await _context.Checklists
            .AsNoTracking()
            .Where(c => c.UserId == userId)
            .ToListAsync();
    }

    public async Task CreateAsync(Domain.Entities.Checklist checklist)
    {
        await _context.Checklists.AddAsync(checklist);
        await _context.SaveChangesAsync();
    }

    public async Task<Domain.Entities.Checklist> GetByIdAsync(Guid checklistId)
    {
        return await _context.Checklists
            .FirstOrDefaultAsync(c => c.Id == checklistId);
    }

    public async Task UpdateAsync(Domain.Entities.Checklist checklist)
    {
        var existing = await _context.Checklists.FindAsync(checklist.Id);

        if (existing == null)
            throw new Exception("Checklist não encontrado");

        existing.Title = checklist.Title;
        existing.UpdatedAt = checklist.UpdatedAt;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Domain.Entities.Checklist checklist)
    {
        _context.Checklists.Remove(checklist);

        await _context.SaveChangesAsync();
    }
}