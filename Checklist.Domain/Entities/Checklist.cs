using Checklist.Domain.Common;

namespace Checklist.Domain.Entities;

public class Checklist : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}