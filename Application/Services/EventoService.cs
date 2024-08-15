using Domain.Entities;
using Domain.Repositories;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoService(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        public Task<int> AddEventoAsync(Evento evento) => _eventoRepository.AddEventoAsync(evento);
        public Task<Evento> GetEventoByIdAsync(int id) => _eventoRepository.GetEventoByIdAsync(id);
        public Task<IEnumerable<Evento>> GetAllEventoAsync() => _eventoRepository.GetAllEventoAsync();
        public Task UpdateEventoAsync(Evento evento) => _eventoRepository.UpdateEventoAsync(evento);
        public Task DeleteEventoAsync(int id) => _eventoRepository.DeleteEventoAsync(id);
    }
}
