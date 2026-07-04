using ChecklistEntity = Checklist.Domain.Entities.Checklist;
using Checklist.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Checklist.Infrastructure.Persistence.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ChecklistEntity> Checklists => Set<ChecklistEntity>();

    public DbSet<Note> Notes => Set<Note>();

    public DbSet<SubNote> SubNotes => Set<SubNote>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(
            typeof(ApplicationDbContext).Assembly);

        builder.Entity<ChecklistEntity>().ToTable("CHECKLISTS");
        builder.Entity<Note>().ToTable("NOTES");
        builder.Entity<SubNote>().ToTable("SUBNOTES");
    }
}