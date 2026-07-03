namespace Checklist.Application.Features.Notes.DTOs
{
    public class CreateNoteResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
