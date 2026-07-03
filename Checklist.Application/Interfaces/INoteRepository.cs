using NoteEntity = Checklist.Domain.Entities.Note;

namespace Checklist.Application.Interfaces
{
    public interface INoteRepository
    {
        Task<List<NoteEntity>> GetAllAsync(Guid userId);
        Task CreateAsync(NoteEntity note);
        Task<bool> CheckChecklistOwnershipAsync(Guid userId, Guid checklistId);
    }
}
