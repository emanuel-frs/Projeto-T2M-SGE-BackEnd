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

        public async Task<int> AddEventoAsync(Evento evento)
        {
            var eventoId = await _eventoRepository.AddEventoAsync(evento);
            evento.EventoId = eventoId; // Atribui o ID retornado à entidade
            return eventoId;
        }
        public Task<Evento> GetEventoByIdAsync(int id) => _eventoRepository.GetEventoByIdAsync(id);
        public Task<IEnumerable<Evento>> GetAllEventoAsync() => _eventoRepository.GetAllEventoAsync();
        public Task UpdateEventoAsync(Evento evento) => _eventoRepository.UpdateEventoAsync(evento);
        public Task DeleteEventoAsync(int id) => _eventoRepository.DeleteEventoAsync(id);
    }
}
