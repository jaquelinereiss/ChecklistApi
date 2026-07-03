using Checklist.Application.Features.Notes.DTOs;

namespace Checklist.Application.Interfaces
{
    public interface INoteService
    {
        Task<List<GetNoteResponse>> GetAllAsync(Guid userId);
        Task<CreateNoteResponse> CreateAsync(Guid userId, Guid checklistId, CreateNoteRequest request);
    }
}
