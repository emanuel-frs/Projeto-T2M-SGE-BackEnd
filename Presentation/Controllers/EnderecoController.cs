using Application.Services;
using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("endereco")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Endereco endereco)
        {
            var enderecoExistente = await _enderecoService.GetEnderecoByCepAndNumeroAsync(endereco.CEP, endereco.Numero);

            if (enderecoExistente != null)
            {
                return Conflict("Endereço já existe.");
            }

            var enderecoId = await _enderecoService.AddEnderecoAsync(endereco);
            return CreatedAtAction(nameof(GetById), new { id = enderecoId }, endereco);
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
