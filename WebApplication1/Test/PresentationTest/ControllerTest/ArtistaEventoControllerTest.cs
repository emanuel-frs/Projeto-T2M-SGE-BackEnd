using Presentation.Controllers;
using Domain.Entities;
using Domain.Services;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;
using Application.Services;
using System.Collections.Generic;

namespace PresentationTest.ControllerTest
{
    public class ArtistaEventoControllerTest
    {
        private readonly ArtistaEventoController _controller;
        private readonly Mock<IArtistaEventoService> _mockService;

        public ArtistaEventoControllerTest()
        {
            _mockService = new Mock<IArtistaEventoService>();
            _controller = new ArtistaEventoController(_mockService.Object);
        }

        [Fact]
        public async Task Create_DeveRetornarCreatedAtAction_QuandoArtistaEventoForCriado()
        {
            // Arrange
            var artistaEvento = new ArtistaEvento { ArtistaEventoId = 1, EventoId = 1, ArtistaId = 1, DataRegistro = DateTime.Now };
            _mockService.Setup(service => service.AddArtistaEventoAsync(It.IsAny<ArtistaEvento>()))
                        .ReturnsAsync(artistaEvento.ArtistaEventoId);

            // Act
            var result = await _controller.Create(artistaEvento);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(nameof(_controller.GetById), createdAtActionResult.ActionName);
            Assert.Equal(artistaEvento.ArtistaEventoId, createdAtActionResult.RouteValues["id"]);
        }

        [Fact]
        public async Task GetById_DeveRetornarOk_QuandoArtistaEventoExiste()
        {
            // Arrange
            var artistaEventoId = 1;
            var artistaEvento = new ArtistaEvento { ArtistaEventoId = artistaEventoId, EventoId = 1, ArtistaId = 1, DataRegistro = DateTime.Now };
            _mockService.Setup(service => service.GetArtistaEventoByIdAsync(artistaEventoId)).ReturnsAsync(artistaEvento);

            // Act
            var result = await _controller.GetById(artistaEventoId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var retornoArtistaEvento = Assert.IsType<ArtistaEvento>(okResult.Value);
            Assert.Equal(artistaEventoId, retornoArtistaEvento.ArtistaEventoId);
        }

        [Fact]
        public async Task GetById_DeveRetornarNotFound_QuandoArtistaEventoNaoExiste()
        {
            // Arrange
            var artistaEventoId = 1;
            _mockService.Setup(service => service.GetArtistaEventoByIdAsync(artistaEventoId)).ReturnsAsync((ArtistaEvento)null);

            // Act
            var result = await _controller.GetById(artistaEventoId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetAll_DeveRetornarOk_ComListaDeArtistaEventos()
        {
            // Arrange
            var artistaEventos = new List<ArtistaEvento> { new ArtistaEvento { ArtistaEventoId = 1, EventoId = 1, ArtistaId = 1, DataRegistro = DateTime.Now } };
            _mockService.Setup(service => service.GetAllArtistaEventoAsync()).ReturnsAsync(artistaEventos);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var retornoArtistaEventos = Assert.IsType<List<ArtistaEvento>>(okResult.Value);
            Assert.NotEmpty(retornoArtistaEventos);
        }

        [Fact]
        public async Task Update_DeveRetornarBadRequest_QuandoIdNaoCorrespondeAoArtistaEvento()
        {
            // Arrange
            var artistaEventoId = 1;
            var artistaEvento = new ArtistaEvento { ArtistaEventoId = 2, EventoId = 1, ArtistaId = 1, DataRegistro = DateTime.Now };

            // Act
            var result = await _controller.Update(artistaEventoId, artistaEvento);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Update_DeveRetornarOk_QuandoArtistaEventoForAtualizado()
        {
            // Arrange
            var artistaEventoId = 1;
            var artistaEvento = new ArtistaEvento { ArtistaEventoId = artistaEventoId, EventoId = 1, ArtistaId = 1, DataRegistro = DateTime.Now };

            _mockService.Setup(service => service.UpdateArtistaEventoAsync(artistaEvento))
                        .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Update(artistaEventoId, artistaEvento);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(artistaEvento, okResult.Value);
        }

        [Fact]
        public async Task Delete_DeveRetornarNoContent_QuandoArtistaEventoForDeletado()
        {
            // Arrange
            var artistaEventoId = 1;

            _mockService.Setup(service => service.DeleteArtistaEventoAsync(artistaEventoId))
                        .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Delete(artistaEventoId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
