using ChecklistEntity = Checklist.Domain.Entities.Checklist;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Checklist.Infrastructure.Persistence.Configurations;

public class ChecklistConfiguration
    : IEntityTypeConfiguration<ChecklistEntity>
{
    public void Configure(
        EntityTypeBuilder<ChecklistEntity> builder)
    {
        builder.ToTable("CHECKLISTS");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.UserId)
            .HasMaxLength(200)
            .IsRequired();

        builder.HasQueryFilter(x => !x.IsDeleted);

        //builder.HasMany(x => x.Notes)
        //    .WithOne(x => x.Checklist)
        //    .HasForeignKey(x => x.ChecklistId)
        //    .OnDelete(DeleteBehavior.Restrict);
    }
}