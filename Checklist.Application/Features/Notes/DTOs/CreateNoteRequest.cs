using System.ComponentModel.DataAnnotations;

namespace Checklist.Application.Features.Notes.DTOs
{
    public class CreateNoteRequest
    {
        [Required]
        public string Title { get; set; } = string.Empty;
    }
}
