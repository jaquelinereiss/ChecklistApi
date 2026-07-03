using Checklist.Application.Features.Notes.DTOs;

namespace Checklist.Application.Interfaces
{
    public interface INoteService
    {
        Task<List<GetNoteResponse>> GetAllAsync(Guid userId);
    }
}
