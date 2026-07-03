using Checklist.Application.Interfaces;
using Checklist.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Checklist.Infrastructure.Persistence.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly ApplicationDbContext _context;

        public NoteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Entities.Note>> GetAllAsync(Guid userId)
        {
            return await _context.Notes
                .AsNoTracking()
                .Where(n => n.Checklist.UserId == userId)
                .ToListAsync();
        }

        public async Task CreateAsync(Domain.Entities.Note note)
        {
            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CheckChecklistOwnershipAsync(Guid userId, Guid checklistId)
        {
            return await _context.Checklists
                .AsNoTracking()
                .AnyAsync(c => c.Id == checklistId && c.UserId == userId);
        }
    }
}
