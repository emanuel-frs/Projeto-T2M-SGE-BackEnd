using Domain.Entities;

namespace Domain.Repositories
{
    public interface IEventoRepository
    {
        Task<int> AddEventoAsync(Evento evento);
        Task<Evento> GetEventoByIdAsync(int id);
        Task<IEnumerable<Evento>> GetAllEventoAsync();
        Task UpdateEventoAsync(Evento evento);
        Task DeleteEventoAsync(int id);
    }
}
