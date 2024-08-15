using Application.Services;
using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Usuario usuario)
        {
            var usuarioId = await _usuarioService.AddUsuarioAsync(usuario);
            return CreatedAtAction(nameof(GetById), new { id = usuarioId }, usuario);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetById(int id)
        {
            var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAll()
        {
            var usuarios = await _usuarioService.GetAllUsuarioAsync();
            return Ok(usuarios);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.UsuarioId) return BadRequest();

            await _usuarioService.UpdateUsuarioAsync(usuario);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _usuarioService.DeleteUsuarioAsync(id);
            return NoContent();
        }

        [HttpPost("login")]
        public async Task<ActionResult<Usuario>> Login([FromBody] LoginRequest loginRequest)
        {
            var usuario = await _usuarioService.LoginAsync(loginRequest.Email, loginRequest.Senha);
            if (usuario == null)
            {
                return Unauthorized(new { message = "Credenciais inválidas" });
            }
            return Ok(usuario);
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
