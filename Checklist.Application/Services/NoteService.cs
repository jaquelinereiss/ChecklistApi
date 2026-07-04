using Checklist.Application.Exceptions;
using Checklist.Application.Features.Notes.DTOs;
using Checklist.Application.Interfaces;
using Checklist.Domain.Enums;

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

        public async Task<CreateNoteResponse> CreateAsync(Guid userId, Guid checklistId, CreateNoteRequest request)
        {
            var checklistExists = await _repository.CheckChecklistOwnershipAsync(userId, checklistId);

            if (!checklistExists)
                throw new NotFoundException("Checklist não encontrado ou não pertence ao usuário.");

            var note = new Domain.Entities.Note
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                ChecklistId = checklistId,
                Status = NoteStatus.Pending,
                CreatedAt = DateTime.UtcNow,
            };

            await _repository.CreateAsync(note);

            return new CreateNoteResponse
            {
                Id = note.Id,
                Message = "Nota criada com sucesso."
            };
        }

        public async Task UpdateAsync(Guid userId, Guid noteId, UpdateNoteRequest request)
        {
            var note = await _repository.GetByIdAsync(userId, noteId) ?? throw new NotFoundException("Nota não encontrada.");

            note.Title = request.Title;
            note.Status = request.Status;
            note.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(note);
        }
    }
}
