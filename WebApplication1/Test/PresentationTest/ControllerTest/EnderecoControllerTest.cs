using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Presentation.Controllers;
using Xunit;

namespace PresentationTest.ControllerTest
{
    public class EnderecoControllerTest
    {
        private readonly EnderecoController _controller;
        private readonly Mock<IEnderecoService> _mockEnderecoService;

        public EnderecoControllerTest()
        {
            _mockEnderecoService = new Mock<IEnderecoService>();
            _controller = new EnderecoController(_mockEnderecoService.Object);
        }

        [Fact]
        public async Task Create_DeveRetornarCreatedAtAction_QuandoEnderecoForCriado()
        {
            // Arrange
            var endereco = new Endereco { EnderecoId = 1, Rua = "Rua Teste" };
            _mockEnderecoService.Setup(service => service.AddEnderecoAsync(endereco)).ReturnsAsync(1);

            // Act
            var result = await _controller.Create(endereco);

            // Assert
            var actionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetById", actionResult.ActionName);
            Assert.Equal(endereco.EnderecoId, actionResult.RouteValues["id"]);
            Assert.Equal(endereco, actionResult.Value);
        }

        [Fact]
        public async Task GetById_DeveRetornarOk_QuandoEnderecoExiste()
        {
            // Arrange
            var endereco = new Endereco { EnderecoId = 1, Rua = "Rua Teste" };
            _mockEnderecoService.Setup(service => service.GetEnderecoByIdAsync(1)).ReturnsAsync(endereco);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var retornoEndereco = Assert.IsType<Endereco>(okResult.Value);
            Assert.Equal(endereco.EnderecoId, retornoEndereco.EnderecoId);
        }

        [Fact]
        public async Task GetById_DeveRetornarNotFound_QuandoEnderecoNaoExiste()
        {
            // Arrange
            _mockEnderecoService.Setup(service => service.GetEnderecoByIdAsync(1)).ReturnsAsync((Endereco)null);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task Update_DeveRetornarOk_QuandoEnderecoForAtualizado()
        {
            // Arrange
            var endereco = new Endereco { EnderecoId = 1, Rua = "Rua Atualizada" };
            _mockEnderecoService.Setup(service => service.UpdateEnderecoAsync(endereco)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Update(1, endereco);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Delete_DeveRetornarNoContent_QuandoEnderecoForDeletado()
        {
            // Arrange
            _mockEnderecoService.Setup(service => service.DeleteEnderecoAsync(1)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task GetAll_DeveRetornarOk_ComListaDeEnderecos()
        {
            // Arrange
            var enderecos = new List<Endereco>
            {
                new Endereco { EnderecoId = 1, Rua = "Rua 1" },
                new Endereco { EnderecoId = 2, Rua = "Rua 2" }
            };
            _mockEnderecoService.Setup(service => service.GetAllEnderecoAsync()).ReturnsAsync(enderecos);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var retornoEnderecos = Assert.IsType<List<Endereco>>(okResult.Value);
            Assert.Equal(enderecos.Count, retornoEnderecos.Count);
        }
    }
}
