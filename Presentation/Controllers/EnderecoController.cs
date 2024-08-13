using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly EnderecoService _enderecoService;

        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Endereco endereco)
        {
            endereco.EnderecoId = await _enderecoService.AddEnderecoAsync(endereco);
            return CreatedAtAction(nameof(GetById), new { id = endereco.EnderecoId }, endereco);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Endereco>> GetById(int id)
        {
            var endereco = await _enderecoService.GetEnderecoByIdAsync(id);
            if (endereco == null) return NotFound();
            return Ok(endereco);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Endereco>>> GetAll()
        {
            var enderecos = await _enderecoService.GetAllEnderecoAsync();
            return Ok(enderecos);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Endereco endereco)
        {
            if (id != endereco.EnderecoId) return BadRequest();
            await _enderecoService.UpdateEnderecoAsync(endereco);
            return Ok(endereco);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _enderecoService.DeleteEnderecoAsync(id);
            return NoContent();
        }
    }
}
