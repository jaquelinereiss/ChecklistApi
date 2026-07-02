using Checklist.Application.Features.Checklists.DTOs;
using Checklist.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Checklist.Api.Controllers;

[Authorize]
[ApiController]
[Route("checklists")]
public class ChecklistController : ControllerBase
{
    private readonly IChecklistService _service;

    public ChecklistController(IChecklistService service)
    {
        _service = service;
    }

    /// <summary>
    /// Retorna todas as checklists do usuário autenticado.
    /// </summary>
    /// <response code="200">Lista retornada com sucesso.</response>
    /// <response code="401">Usuário não autenticado.</response>
    /// <response code="500">Erro interno do servidor.</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<GetChecklistResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? User.FindFirstValue("sub"));

        if (userId == Guid.Empty)
        {
            return Unauthorized();
        }

        var result = await _service.GetAllAsync(userId);

        return Ok(result);
    }

    /// <summary>
    /// Cria um novo checklist para o usuário autenticado.
    /// </summary>
    /// <param name="request">Dados do checklist a ser criado.</param>
    /// <returns>Checklist criado com sucesso.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(IEnumerable<GetChecklistResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create([FromBody] CreateChecklistRequest request)
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? User.FindFirstValue("sub"));

        var response = await _service.CreateAsync(userId, request);

        return CreatedAtAction(nameof(Create), new { id = response.Id }, response);
    }
}