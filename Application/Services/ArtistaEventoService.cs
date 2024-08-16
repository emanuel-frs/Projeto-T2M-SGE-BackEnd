using Domain.Entities;
using Domain.Repositories;
using Domain.Services;
using Domain.Projection;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ArtistaEventoService : IArtistaEventoService
    {
        private readonly IArtistaEventoRepository _artistaEventoRepository;

        public ArtistaEventoService(IArtistaEventoRepository artistaEventoRepository)
        {
            _artistaEventoRepository = artistaEventoRepository;
        }

        public Task<int> AddArtistaEventoAsync(ArtistaEvento artistaEvento)
        {
            return _artistaEventoRepository.AddArtistaEventoAsync(artistaEvento);
        }

        public Task<ArtistaEvento> GetArtistaEventoByIdAsync(int id)
        {
            return _artistaEventoRepository.GetArtistaEventoByIdAsync(id);
        }

        public Task<IEnumerable<IArtistaEventoProjection>> GetAllArtistaEventoAsync()
        {
            return _artistaEventoRepository.GetAllArtistaEventoAsync();
        }

        public Task UpdateArtistaEventoAsync(ArtistaEvento artistaEvento)
        {
            return _artistaEventoRepository.UpdateArtistaEventoAsync(artistaEvento);
        }

        public Task DeleteArtistaEventoAsync(int id)
        {
            return _artistaEventoRepository.DeleteArtistaEventoAsync(id);
        }
    }
}
