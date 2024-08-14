using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IArtistaService
    {
        Task<int> AddArtistaAsync(Artista artista);
        Task<Artista> GetArtistaByIdAsync(int id);
        Task<IEnumerable<Artista>> GetAllArtistaAsync();
        Task UpdateArtistaAsync(Artista artista);
        Task DeleteArtistaAsync(int id);
    }
}
