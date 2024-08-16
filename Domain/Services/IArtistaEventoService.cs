using Domain.Entities;
using Domain.Projection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IArtistaEventoService
    {
        Task<int> AddArtistaEventoAsync(ArtistaEvento artistaEvento);
        Task<ArtistaEvento> GetArtistaEventoByIdAsync(int id);
        Task<IEnumerable<IArtistaEventoProjection>> GetAllArtistaEventoAsync();
        Task UpdateArtistaEventoAsync(ArtistaEvento artistaEvento);
        Task DeleteArtistaEventoAsync(int id);
    }
}
