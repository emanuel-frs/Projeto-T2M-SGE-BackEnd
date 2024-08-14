using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Task<int> AddUsuarioAsync(Usuario usuario) => _usuarioRepository.AddUsuarioAsync(usuario);
        public Task<Usuario> GetUsuarioByIdAsync(int id) => _usuarioRepository.GetUsuarioByIdAsync(id);
        public Task<IEnumerable<Usuario>> GetAllUsuarioAsync() => _usuarioRepository.GetAllUsuarioAsync();
        public Task UpdateUsuarioAsync(Usuario usuario) => _usuarioRepository.UpdateUsuarioAsync(usuario);
        public Task DeleteUsuarioAsync(int id) => _usuarioRepository.DeleteUsuarioAsync(id);
    }
}
