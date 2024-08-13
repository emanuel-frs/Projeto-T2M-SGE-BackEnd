using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUsuarioRepository
    {
        Task<int> AddUsuarioAsync(Usuario usuario);
        Task<Usuario> GetUsuarioByIdAsync(int id);
        Task<IEnumerable<Usuario>> GetAllUsuarioAsync();
        Task UpdateUsuarioAsync(Usuario usuario);
        Task DeleteUsuarioAsync(int id);
    }
}
