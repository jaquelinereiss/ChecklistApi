using Checklist.Domain.Common;
using Checklist.Domain.Enums;

namespace Checklist.Domain.Entities;

public class Note : BaseEntity
{
    public string Title { get; set; } = string.Empty;

    public NoteStatus Status { get; set; }

    public Guid ChecklistId { get; set; }

    public Checklist Checklist { get; set; } = null!;

    public ICollection<SubNote> SubNotes { get; set; }
        = new List<SubNote>();
}