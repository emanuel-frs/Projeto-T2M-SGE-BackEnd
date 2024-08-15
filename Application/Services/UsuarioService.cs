using Domain.Entities;
using Domain.Repositories;
using Domain.Services;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<int> AddUsuarioAsync(Usuario usuario)
        {
            usuario.Senha = HashSenha(usuario.Senha);
            return await _usuarioRepository.AddUsuarioAsync(usuario);
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            return await _usuarioRepository.GetUsuarioByIdAsync(id);
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuarioAsync()
        {
            return await _usuarioRepository.GetAllUsuarioAsync();
        }

        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            usuario.Senha = HashSenha(usuario.Senha);
            await _usuarioRepository.UpdateUsuarioAsync(usuario);
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            await _usuarioRepository.DeleteUsuarioAsync(id);
        }

        public async Task<Usuario> LoginAsync(string email, string senha)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(email);
            if (usuario != null && VerificarSenha(senha, usuario.Senha))
            {
                return usuario;
            }
            return null;
        }

        public string HashSenha(string senha)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        private bool VerificarSenha(string senha, string hash)
        {
            return HashSenha(senha) == hash;
        }
    }
}
