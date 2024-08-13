using Domain.Entities;

namespace Domain.Repositories
{
    public interface IArtistaRepository
    {
        Task<int> AddArtistaAsync(Artista artista);
        Task<Artista> GetArtistaByIdAsync(int id);
        Task<IEnumerable<Artista>> GetAllArtistaAsync();
        Task UpdateArtistaAsync(Artista artista);
        Task DeleteArtistaAsync(int id);
    }
}
