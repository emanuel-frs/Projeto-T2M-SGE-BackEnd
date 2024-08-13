using Domain.Entities;

namespace Domain.Repositories
{
    public interface IArtistaEventoRepository
    {
        Task<int> AddArtistaEventoAsync(ArtistaEvento artistaEvento);
        Task<ArtistaEvento> GetArtistaEventoByIdAsync(int id);
        Task<IEnumerable<ArtistaEvento>> GetAllArtistaEventoAsync();
        Task UpdateArtistaEventoAsync(ArtistaEvento artistaEvento);
        Task DeleteArtistaEventoAsync(int id);
    }
}
