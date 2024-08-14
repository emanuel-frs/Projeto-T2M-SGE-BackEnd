using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ArtistaEventoService
    {
        private readonly IArtistaEventoRepository _artistaEventoRepository;

        public ArtistaEventoService(IArtistaEventoRepository artistaEventoRepository)
        {
            _artistaEventoRepository = artistaEventoRepository;
        }

        public Task<int> AddArtistaEventoAsync(ArtistaEvento artistaEvento) => _artistaEventoRepository.AddArtistaEventoAsync(artistaEvento);
        public Task<ArtistaEvento> GetArtistaEventoByIdAsync(int id) => _artistaEventoRepository.GetArtistaEventoByIdAsync(id);
        public Task<IEnumerable<ArtistaEvento>> GetAllArtistaEventoAsync() => _artistaEventoRepository.GetAllArtistaEventoAsync();
        public Task UpdateArtistaEventoAsync(ArtistaEvento artistaEvento) => _artistaEventoRepository.UpdateArtistaEventoAsync(artistaEvento);
        public Task DeleteArtistaEventoAsync(int id) => _artistaEventoRepository.DeleteArtistaEventoAsync(id);
    }
}
