using System;
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
    public class ArtistaEventoControllerTest
    {
        private readonly ArtistaEventoController _controller;
        private readonly Mock<IArtistaEventoService> _mockArtistaEventoService;

        public ArtistaEventoControllerTest()
        {
            _mockArtistaEventoService = new Mock<IArtistaEventoService>();
            _controller = new ArtistaEventoController(_mockArtistaEventoService.Object);
        }

        [Fact]
        public async Task Create_DeveRetornarCreatedAtAction_QuandoArtistaEventoForCriado()
        {
            // Arrange
            var artistaEvento = new ArtistaEvento { ArtistaEventoId = 1, EventoId = 2, ArtistaId = 3, DataRegistro = DateTime.Now };
            _mockArtistaEventoService.Setup(service => service.AddArtistaEventoAsync(It.IsAny<ArtistaEvento>()));

            // Act
            var result = await _controller.Create(artistaEvento);

            // Assert
            var actionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetById", actionResult.ActionName);
            Assert.Equal(artistaEvento.ArtistaEventoId, actionResult.RouteValues["id"]);
            Assert.Equal(artistaEvento, actionResult.Value);
        }

        [Fact]
        public async Task GetById_DeveRetornarOk_QuandoArtistaEventoExiste()
        {
            // Arrange
            var artistaEvento = new ArtistaEvento { ArtistaEventoId = 1, EventoId = 2, ArtistaId = 3, DataRegistro = DateTime.Now };
            _mockArtistaEventoService.Setup(service => service.GetArtistaEventoByIdAsync(1)).ReturnsAsync(artistaEvento);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var retornoArtistaEvento = Assert.IsType<ArtistaEvento>(okResult.Value);
            Assert.Equal(artistaEvento.ArtistaEventoId, retornoArtistaEvento.ArtistaEventoId);
        }

        [Fact]
        public async Task GetById_DeveRetornarNotFound_QuandoArtistaEventoNaoExiste()
        {
            // Arrange
            _mockArtistaEventoService.Setup(service => service.GetArtistaEventoByIdAsync(1)).ReturnsAsync((ArtistaEvento)null);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task Update_DeveRetornarOk_QuandoArtistaEventoForAtualizado()
        {
            // Arrange
            var artistaEvento = new ArtistaEvento { ArtistaEventoId = 1, EventoId = 2, ArtistaId = 3, DataRegistro = DateTime.Now };
            _mockArtistaEventoService.Setup(service => service.UpdateArtistaEventoAsync(artistaEvento)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Update(1, artistaEvento);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Delete_DeveRetornarNoContent_QuandoArtistaEventoForDeletado()
        {
            // Arrange
            _mockArtistaEventoService.Setup(service => service.DeleteArtistaEventoAsync(1)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task GetAll_DeveRetornarOk_ComListaDeArtistaEventos()
        {
            // Arrange
            var artistaEventos = new List<ArtistaEvento>
            {
                new ArtistaEvento { ArtistaEventoId = 1, EventoId = 2, ArtistaId = 3, DataRegistro = DateTime.Now },
                new ArtistaEvento { ArtistaEventoId = 2, EventoId = 3, ArtistaId = 4, DataRegistro = DateTime.Now }
            };
            _mockArtistaEventoService.Setup(service => service.GetAllArtistaEventoAsync()).ReturnsAsync(artistaEventos);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var retornoArtistaEventos = Assert.IsType<List<ArtistaEvento>>(okResult.Value);
            Assert.Equal(artistaEventos.Count, retornoArtistaEventos.Count);
        }
    }
}
