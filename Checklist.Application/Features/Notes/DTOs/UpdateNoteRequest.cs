using Checklist.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Checklist.Application.Features.Notes.DTOs
{
    public class UpdateNoteRequest
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        public NoteStatus Status { get; set; }
    }
}
