namespace Checklist.Application.Features.Notes.DTOs
{
    public class GetNoteResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid ChecklistId { get; set; }
    }
}
