using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IEnderecoService
    {
        Task<int> AddEnderecoAsync(Endereco endereco);
        Task<Endereco> GetEnderecoByIdAsync(int id);
        Task<IEnumerable<Endereco>> GetAllEnderecoAsync();
        Task UpdateEnderecoAsync(Endereco endereco);
        Task DeleteEnderecoAsync(int id);
        Task<Endereco> GetEnderecoByCepAndNumeroAsync(string cep, int numero);
    }
}
