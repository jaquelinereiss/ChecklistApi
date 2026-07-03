namespace Checklist.Application.Features.Checklists.DTOs;

public class GetChecklistResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; }
}