using Checklist.Domain.Common;

namespace Checklist.Domain.Entities;

public class Checklist : BaseEntity
{
    public Guid UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public ICollection<Note> Notes { get; set; } = new List<Note>();
}