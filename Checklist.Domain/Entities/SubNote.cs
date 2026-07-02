using Checklist.Domain.Common;
using Checklist.Domain.Enums;

namespace Checklist.Domain.Entities;

public class SubNote : BaseEntity
{
    public string Title { get; set; } = string.Empty;

    public NoteStatus Status { get; set; }

    public Guid NoteId { get; set; }

    public Note Note { get; set; } = null!;
}