using System.ComponentModel.DataAnnotations;

namespace Checklist.Application.Features.Checklists.DTOs
{
    public class CreateChecklistRequest
    {
        [Required]
        public string Title { get; set; } = string.Empty;
    }
}
