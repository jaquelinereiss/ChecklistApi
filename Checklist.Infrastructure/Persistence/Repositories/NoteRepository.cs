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
    }
}
