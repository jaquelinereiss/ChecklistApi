using Checklist.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Checklist.Infrastructure.Persistence.Configurations;

public class SubNoteConfiguration
    : IEntityTypeConfiguration<SubNote>
{
    public void Configure(
        EntityTypeBuilder<SubNote> builder)
    {
        builder.ToTable("SUBNOTES");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Status)
            .IsRequired();

        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}