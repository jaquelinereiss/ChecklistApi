using Checklist.Application.Features.Checklists.DTOs;
using Checklist.Application.Interfaces;
using Checklist.Domain.Entities;

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
            IsDeleted = x.IsDeleted,
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
            IsDeleted = false,
            UserId = userId,
        };

        await _repository.CreateAsync(checklist);

        return new CreateChecklistResponse
        {
            Id = checklist.Id,
            Message = "Checklist criado com sucesso."
        };
    }
}