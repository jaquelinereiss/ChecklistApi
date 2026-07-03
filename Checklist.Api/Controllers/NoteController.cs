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
    }
}
