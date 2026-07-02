using Checklist.Application.Features.Checklists.DTOs;

namespace Checklist.Application.Interfaces;

public interface IChecklistService
{
    Task<List<GetChecklistResponse>> GetAllAsync(Guid userId);
    Task<CreateChecklistResponse> CreateAsync(Guid userId, CreateChecklistRequest request);
}