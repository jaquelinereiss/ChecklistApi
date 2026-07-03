using Checklist.Application.Interfaces;
using Checklist.Application.Services;
using Checklist.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Checklist.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IChecklistRepository, ChecklistRepository>();
        services.AddScoped<IChecklistService, ChecklistService>();
        services.AddScoped<INoteRepository, NoteRepository>();
        services.AddScoped<INoteService, NoteService>();

        return services;
    }
}