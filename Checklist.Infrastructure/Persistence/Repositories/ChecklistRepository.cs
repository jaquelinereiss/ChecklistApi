using Checklist.Application.Features.Checklists.DTOs;
using Checklist.Application.Interfaces;
using Checklist.Domain.Entities;
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
            .Where(c => c.UserId == userId && c.IsDeleted == false)
            .ToListAsync();
    }

    public async Task CreateAsync(Domain.Entities.Checklist checklist)
    {
        await _context.Checklists.AddAsync(checklist);
        await _context.SaveChangesAsync();
    }
}