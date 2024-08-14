using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IEventoService
    {
        Task<int> AddEventoAsync(Evento evento);
        Task<Evento> GetEventoByIdAsync(int id);
        Task<IEnumerable<Evento>> GetAllEventoAsync();
        Task UpdateEventoAsync(Evento evento);
        Task DeleteEventoAsync(int id);
    }
}
