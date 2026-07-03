using Checklist.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Checklist.Api.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NotFoundException ex)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            context.Response.ContentType = "application/json";

            var problem = new ProblemDetails
            {
                Title = "Recurso não encontrado",
                Detail = ex.Message,
                Status = StatusCodes.Status404NotFound
            };

            await context.Response.WriteAsJsonAsync(problem);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro não tratado durante a execução da requisição.");

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            context.Response.ContentType = "application/json";

            var problem = new ProblemDetails
            {
                Title = "Erro interno",
                Detail = "Ocorreu um erro inesperado.",
                Status = StatusCodes.Status500InternalServerError
            };

            await context.Response.WriteAsJsonAsync(problem);
        }
    }
}