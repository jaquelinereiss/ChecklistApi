using Checklist.Application.Features.Notes.DTOs;
using Checklist.Application.Interfaces;

namespace Checklist.Application.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _repository;

        public NoteService(INoteRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetNoteResponse>> GetAllAsync(Guid userId)
        {
            var notes = await _repository.GetAllAsync(userId);

            return notes.Select(x => new GetNoteResponse
            {
                Id = x.Id,
                Title = x.Title,
                Status = x.Status.ToString(),
                CreatedAt = x.CreatedAt,
                ChecklistId = x.ChecklistId
            }).ToList();
        }
    }
}
