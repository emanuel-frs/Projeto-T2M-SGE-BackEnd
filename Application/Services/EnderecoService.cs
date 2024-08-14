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
        private readonly IViaCepService _viaCepService;

        public EnderecoService(IEnderecoRepository enderecoRepository, IViaCepService viaCepService)
        {
            _enderecoRepository = enderecoRepository;
            _viaCepService = viaCepService;
        }

        public async Task<int> AddEnderecoAsync(Endereco endereco)
        {
            // Verifica se o endereço já existe pelo CEP e número
            var enderecoExistente = await _enderecoRepository.GetEnderecoByCepAndNumeroAsync(endereco.CEP, endereco.Numero);
            if (enderecoExistente != null)
            {
                return enderecoExistente.EnderecoId;
            }

            // Preenche os campos adicionais usando o serviço ViaCep se estiverem faltando
            if (string.IsNullOrEmpty(endereco.Rua) || string.IsNullOrEmpty(endereco.Bairro) ||
                string.IsNullOrEmpty(endereco.Cidade) || string.IsNullOrEmpty(endereco.Estado))
            {
                // Obtém os dados do endereço via ViaCep
                var enderecoFromApi = await _viaCepService.ObterEnderecoPorCepAsync(endereco.CEP);
                if (enderecoFromApi != null)
                {
                    endereco.Rua = enderecoFromApi.Rua ?? endereco.Rua;
                    endereco.Bairro = enderecoFromApi.Bairro ?? endereco.Bairro;
                    endereco.Cidade = enderecoFromApi.Cidade ?? endereco.Cidade;
                    endereco.Estado = enderecoFromApi.Estado ?? endereco.Estado;
                }
                else
                {
                    // Se não conseguir obter os dados, pode lançar uma exceção ou lidar de outra forma
                    throw new Exception("Não foi possível obter o endereço através do serviço ViaCep.");
                }
            }

            // Cria um novo endereço
            return await _enderecoRepository.AddEnderecoAsync(endereco);
        }

        public Task<Endereco> GetEnderecoByIdAsync(int id) => _enderecoRepository.GetEnderecoByIdAsync(id);
        public Task<IEnumerable<Endereco>> GetAllEnderecoAsync() => _enderecoRepository.GetAllEnderecoAsync();
        public Task UpdateEnderecoAsync(Endereco endereco) => _enderecoRepository.UpdateEnderecoAsync(endereco);
        public Task DeleteEnderecoAsync(int id) => _enderecoRepository.DeleteEnderecoAsync(id);

        public Task<Endereco> GetEnderecoByCepAndNumeroAsync(string cep, int numero)
        {
            // Chama o repositório para buscar o endereço pelo CEP e número
            return _enderecoRepository.GetEnderecoByCepAndNumeroAsync(cep, numero);
        }
    }
}
