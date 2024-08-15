using Domain.Entities;
using Domain.Repositories;
using Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public Task<int> AddEnderecoAsync(Endereco endereco) => _enderecoRepository.AddEnderecoAsync(endereco);
        public Task<Endereco> GetEnderecoByIdAsync(int id) => _enderecoRepository.GetEnderecoByIdAsync(id);
        public Task<IEnumerable<Endereco>> GetAllEnderecoAsync() => _enderecoRepository.GetAllEnderecoAsync();
        public Task UpdateEnderecoAsync(Endereco endereco) => _enderecoRepository.UpdateEnderecoAsync(endereco);
        public Task DeleteEnderecoAsync(int id) => _enderecoRepository.DeleteEnderecoAsync(id);
    }
}
