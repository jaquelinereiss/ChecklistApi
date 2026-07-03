using Checklist.Application.Exceptions;
using Checklist.Application.Features.Checklists.DTOs;
using Checklist.Application.Interfaces;

namespace Checklist.Application.Services;

public class ChecklistService : IChecklistService
{
    private readonly IChecklistRepository _repository;

    public ChecklistService(IChecklistRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetChecklistResponse>> GetAllAsync(Guid userId)
    {
        var checklists = await _repository.GetAllAsync(userId);

        return checklists.Select(x => new GetChecklistResponse
        {
            Id = x.Id,
            Title = x.Title,
            CreatedAt = x.CreatedAt
        }).ToList();
    }

    public async Task<CreateChecklistResponse> CreateAsync(Guid userId, CreateChecklistRequest request)
    {
        var checklist = new Domain.Entities.Checklist
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            CreatedAt = DateTime.UtcNow,
            UserId = userId,
        };

        await _repository.CreateAsync(checklist);

        return new CreateChecklistResponse
        {
            Id = checklist.Id,
            Message = "Checklist criado com sucesso."
        };
    }

    public async Task UpdateAsync(Guid userId, Guid checklistId, UpdateChecklistRequest request)
    {
        var checklist = await _repository.GetByIdAsync(checklistId);

        if (checklist == null || checklist.UserId != userId)
            throw new NotFoundException("Checklist não encontrado.");

        checklist.Title = request.Title;
        checklist.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateAsync(checklist);

    }

    public async Task DeleteAsync(Guid userId, Guid checklistId)
    {
        var checklist = await _repository.GetByIdAsync(checklistId);

        if (checklist == null || checklist.UserId != userId)
            throw new NotFoundException("Checklist não encontrado.");

        await _repository.DeleteAsync(checklist);

    }
}