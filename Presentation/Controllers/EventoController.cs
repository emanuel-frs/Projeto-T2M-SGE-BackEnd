using Application.Services;
using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventoController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Evento evento)
        {
            var eventoId = await _eventoService.AddEventoAsync(evento);
            return CreatedAtAction(nameof(GetById), new { id = eventoId }, evento);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetById(int id)
        {
            var evento = await _eventoService.GetEventoByIdAsync(id);
            if (evento == null) return NotFound();
            return Ok(evento);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evento>>> GetAll()
        {
            var eventos = await _eventoService.GetAllEventoAsync();
            return Ok(eventos);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Evento evento)
        {
            if (id != evento.EventoId) return BadRequest();
            await _eventoService.UpdateEventoAsync(evento);
            return Ok(evento);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _eventoService.DeleteEventoAsync(id);
            return NoContent();
        }
    }
}
