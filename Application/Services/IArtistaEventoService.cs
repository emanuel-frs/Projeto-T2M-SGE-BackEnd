using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IArtistaEventoService
    {
        Task<int> AddArtistaEventoAsync(ArtistaEvento artistaEvento);
        Task<ArtistaEvento> GetArtistaEventoByIdAsync(int id);
        Task<IEnumerable<ArtistaEvento>> GetAllArtistaEventoAsync();
        Task UpdateArtistaEventoAsync(ArtistaEvento artistaEvento);
        Task DeleteArtistaEventoAsync(int id);
    }
}
