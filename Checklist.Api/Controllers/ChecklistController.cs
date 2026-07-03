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

    protected Guid UserId => Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? User.FindFirstValue("sub"));

    /// <summary>
    /// Retorna todas as checklists do usuário autenticado.
    /// </summary>
    /// <returns>Lista de checklists do usuário autenticado.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<GetChecklistResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync(UserId);

        return Ok(result);
    }

    /// <summary>
    /// Cria um novo checklist para o usuário autenticado.
    /// </summary>
    /// <param name="request">Dados do checklist a ser criado.</param>
    /// <returns>Checklist criado com sucesso.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(CreateChecklistResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create([FromBody] CreateChecklistRequest request)
    {
        var response = await _service.CreateAsync(UserId, request);

        //return CreatedAtAction(nameof(Create), new { id = response.Id }, response);
        return StatusCode(StatusCodes.Status201Created, response);
    }

    /// <summary>
    /// Atualiza um checklist do usuário autenticado.
    /// </summary>
    /// <param name="id">Identificador do checklist.</param>
    /// <param name="request">Dados para atualização do checklist.</param>
    /// <returns>Checklist atualizado com sucesso.</returns>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateChecklistRequest request)
    {
        await _service.UpdateAsync(UserId, id, request);

        return NoContent();
    }

    /// <summary>
    /// Remove um checklist do usuário autenticado.
    /// </summary>
    /// <param name="id">Identificador do checklist.</param>
    /// <returns>Retorna 204 (No Content) quando a remoção é realizada com sucesso.</returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(UserId, id);

        return NoContent();
    }
}