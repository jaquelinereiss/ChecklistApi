using Checklist.Application.Features.Notes.DTOs;
using Checklist.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Checklist.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("notes")]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _service;

        public NoteController(INoteService service)
        {
            _service = service;
        }

        protected Guid UserId => Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? User.FindFirstValue("sub"));

        /// <summary>
        /// Retorna todas as notas do usuário autenticado.
        /// </summary>
        /// <returns>Lista de notas do usuário autenticado.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetNoteResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync(UserId);

            return Ok(result);
        }

        /// <summary>
        /// Cria um nova nota para o usuário autenticado.
        /// </summary>
        /// <param name="request">Dados da nota a ser criada.</param>
        /// <returns>Nota criada com sucesso.</returns>
        [HttpPost("{checklistId:guid}")]
        [ProducesResponseType(typeof(CreateNoteResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(Guid checklistId, [FromBody] CreateNoteRequest request)
        {
            var response = await _service.CreateAsync(UserId, checklistId, request);

            return CreatedAtAction(nameof(Create), new { id = response.Id }, response);
        }

        /// <summary>
        /// Atualiza uma nota do usuário autenticado.
        /// </summary>
        /// <param name="id">Identificador da nota.</param>
        /// <param name="request">Dados para atualização da nota.</param>
        /// <returns>Nota atualizada com sucesso.</returns>
        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateNoteRequest request)
        {
            await _service.UpdateAsync(UserId, id, request);

            return NoContent();
        }
    }
}
