using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistaEventoController : ControllerBase
    {
        private readonly ArtistaEventoService _artistaEventoService;

        public ArtistaEventoController(ArtistaEventoService artistaEventoService)
        {
            _artistaEventoService = artistaEventoService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ArtistaEvento artistaEvento)
        {
            await _artistaEventoService.AddArtistaEventoAsync(artistaEvento);
            return CreatedAtAction(nameof(GetById), new { id = artistaEvento.ArtistaEventoId }, artistaEvento);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArtistaEvento>> GetById(int id)
        {
            var artistaEvento = await _artistaEventoService.GetArtistaEventoByIdAsync(id);
            if (artistaEvento == null) return NotFound();
            return Ok(artistaEvento);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtistaEvento>>> GetAll()
        {
            var artistaEvento = await _artistaEventoService.GetAllArtistaEventoAsync();
            return Ok(artistaEvento);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ArtistaEvento artistaEvento)
        {
            if (id != artistaEvento.ArtistaEventoId) return BadRequest();
            await _artistaEventoService.UpdateArtistaEventoAsync(artistaEvento);
            return Ok(artistaEvento);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _artistaEventoService.DeleteArtistaEventoAsync(id);
            return NoContent();
        }
    }
}
