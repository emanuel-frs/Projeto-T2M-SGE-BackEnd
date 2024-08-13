using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistaController : ControllerBase
    {
        private readonly ArtistaService _artistaService;

        public ArtistaController(ArtistaService artistaService)
        {
            _artistaService = artistaService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Artista artista)
        {
            await _artistaService.AddArtistaAsync(artista);
            return CreatedAtAction(nameof(GetById), new { id = artista.ArtistaId }, artista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Artista>> GetById(int id)
        {
            var artista = await _artistaService.GetArtistaByIdAsync(id);
            if (artista == null) return NotFound();
            return Ok(artista);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artista>>> GetAll()
        {
            var artistas = await _artistaService.GetAllArtistaAsync();
            return Ok(artistas);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Artista artista)
        {
            if (id != artista.ArtistaId) return BadRequest();
            await _artistaService.UpdateArtistaAsync(artista);
            return Ok(artista);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _artistaService.DeleteArtistaAsync(id);
            return NoContent();
        }
    }

}
