using ChecklistEntity = Checklist.Domain.Entities.Checklist;

namespace Checklist.Application.Interfaces;

public interface IChecklistRepository
{
    Task<List<ChecklistEntity>> GetAllAsync(Guid userId);
    Task CreateAsync(ChecklistEntity checklist);
    Task UpdateAsync(ChecklistEntity checklist);
    Task<ChecklistEntity> GetByIdAsync(Guid checklistId);
    Task DeleteAsync(ChecklistEntity checklist);
}