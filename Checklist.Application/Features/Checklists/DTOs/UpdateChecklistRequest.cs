using System.ComponentModel.DataAnnotations;

namespace Checklist.Application.Features.Checklists.DTOs
{
    public class UpdateChecklistRequest
    {
        [Required]
        public string Title { get; set; } = string.Empty;
    }
}
