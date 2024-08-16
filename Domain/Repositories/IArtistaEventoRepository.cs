using Domain.Entities;
using Domain.Projection;

namespace Domain.Repositories
{
    public interface IArtistaEventoRepository
    {
        Task<int> AddArtistaEventoAsync(ArtistaEvento artistaEvento);
        Task<ArtistaEvento> GetArtistaEventoByIdAsync(int id);
        Task<IEnumerable<IArtistaEventoProjection>> GetAllArtistaEventoAsync();
        Task UpdateArtistaEventoAsync(ArtistaEvento artistaEvento);
        Task DeleteArtistaEventoAsync(int id);
    }
}
