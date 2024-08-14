using Application.Services;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationTest.ServiceTest
{
    public class EnderecoServiceTests
    {
        private readonly Mock<IEnderecoRepository> _enderecoRepositoryMock;
        private readonly Mock<IViaCepService> _viaCepServiceMock;
        private readonly EnderecoService _enderecoService;

        public EnderecoServiceTests()
        {
            _enderecoRepositoryMock = new Mock<IEnderecoRepository>();
            _viaCepServiceMock = new Mock<IViaCepService>();
            _enderecoService = new EnderecoService(_enderecoRepositoryMock.Object, _viaCepServiceMock.Object);
        }

        [Fact]
        public async Task AddEnderecoAsync_EnderecoExistente_RetornaIdExistente()
        {
            // Arrange
            var endereco = new Endereco { CEP = "12345678", Numero = 10, EnderecoId = 1 };
            _enderecoRepositoryMock
                .Setup(repo => repo.GetEnderecoByCepAndNumeroAsync(endereco.CEP, endereco.Numero))
                .ReturnsAsync(endereco);

            // Act
            var result = await _enderecoService.AddEnderecoAsync(endereco);

            // Assert
            Assert.Equal(endereco.EnderecoId, result);
        }

        [Fact]
        public async Task AddEnderecoAsync_EnderecoNaoExistente_AdicionaNovoEndereco()
        {
            // Arrange
            var endereco = new Endereco { CEP = "12345678", Numero = 10 };
            var enderecoFromApi = new Endereco { Rua = "Rua Teste", Bairro = "Bairro Teste", Cidade = "Cidade Teste", Estado = "Estado Teste" };

            _enderecoRepositoryMock
                .Setup(repo => repo.GetEnderecoByCepAndNumeroAsync(endereco.CEP, endereco.Numero))
                .ReturnsAsync((Endereco)null);

            _viaCepServiceMock
                .Setup(service => service.ObterEnderecoPorCepAsync(endereco.CEP))
                .ReturnsAsync(enderecoFromApi);

            _enderecoRepositoryMock
                .Setup(repo => repo.AddEnderecoAsync(It.IsAny<Endereco>()))
                .ReturnsAsync(2);

            // Act
            var result = await _enderecoService.AddEnderecoAsync(endereco);

            // Assert
            Assert.Equal(2, result);
            _enderecoRepositoryMock.Verify(repo => repo.AddEnderecoAsync(It.Is<Endereco>(e =>
                e.Rua == "Rua Teste" &&
                e.Bairro == "Bairro Teste" &&
                e.Cidade == "Cidade Teste" &&
                e.Estado == "Estado Teste"
            )), Times.Once);
        }

        // Adicione outros testes conforme necessário, como para as operações de atualização, exclusão, etc.
    }
}
