using Domain.Entities;
using Domain.Repositories;
using Domain.Services;

namespace Application.Services
{
    public class ArtistaService : IArtistaService
    {
        private readonly IArtistaRepository _artistaRepository;

        public ArtistaService(IArtistaRepository artistaRepository)
        {
            _artistaRepository = artistaRepository;
        }

        public Task<int> AddArtistaAsync(Artista artista) => _artistaRepository.AddArtistaAsync(artista);
        public Task<Artista> GetArtistaByIdAsync(int id) => _artistaRepository.GetArtistaByIdAsync(id);
        public Task<IEnumerable<Artista>> GetAllArtistaAsync() => _artistaRepository.GetAllArtistaAsync();
        public Task UpdateArtistaAsync(Artista artista) => _artistaRepository.UpdateArtistaAsync(artista);
        public Task DeleteArtistaAsync(int id) => _artistaRepository.DeleteArtistaAsync(id);
    }
}
