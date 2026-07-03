namespace Checklist.Application.Features.Checklists.DTOs
{
    public class CreateChecklistResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
