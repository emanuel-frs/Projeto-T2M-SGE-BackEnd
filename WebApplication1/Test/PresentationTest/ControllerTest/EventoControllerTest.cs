using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Presentation.Controllers;
using Xunit;
using Domain.Services;

namespace PresentationTest.ControllerTest
{
    public class EventoControllerTest
    {
        private readonly EventoController _controller;
        private readonly Mock<IEventoService> _mockEventoService;

        public EventoControllerTest()
        {
            _mockEventoService = new Mock<IEventoService>();
            _controller = new EventoController(_mockEventoService.Object);
        }

        [Fact]
        public async Task Create_DeveRetornarCreatedAtAction_QuandoEventoForCriado()
        {
            // Arrange
            var evento = new Evento { EventoId = 1, Nome = "Evento Teste" };
            _mockEventoService.Setup(service => service.AddEventoAsync(evento)).ReturnsAsync(1);

            // Act
            var result = await _controller.Create(evento);

            // Assert
            var actionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetById", actionResult.ActionName);
            Assert.Equal(evento.EventoId, actionResult.RouteValues["id"]);
            Assert.Equal(evento, actionResult.Value);
        }

        [Fact]
        public async Task GetById_DeveRetornarOk_QuandoEventoExiste()
        {
            // Arrange
            var evento = new Evento { EventoId = 1, Nome = "Evento Teste" };
            _mockEventoService.Setup(service => service.GetEventoByIdAsync(1)).ReturnsAsync(evento);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var retornoEvento = Assert.IsType<Evento>(okResult.Value);
            Assert.Equal(evento.EventoId, retornoEvento.EventoId);
        }

        [Fact]
        public async Task GetById_DeveRetornarNotFound_QuandoEventoNaoExiste()
        {
            // Arrange
            _mockEventoService.Setup(service => service.GetEventoByIdAsync(1)).ReturnsAsync((Evento)null);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task Update_DeveRetornarOk_QuandoEventoForAtualizado()
        {
            // Arrange
            var evento = new Evento { EventoId = 1, Nome = "Evento Atualizado" };
            _mockEventoService.Setup(service => service.UpdateEventoAsync(evento)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Update(1, evento);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Delete_DeveRetornarNoContent_QuandoEventoForDeletado()
        {
            // Arrange
            _mockEventoService.Setup(service => service.DeleteEventoAsync(1)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task GetAll_DeveRetornarOk_ComListaDeEventos()
        {
            // Arrange
            var eventos = new List<Evento>
            {
                new Evento { EventoId = 1, Nome = "Evento 1" },
                new Evento { EventoId = 2, Nome = "Evento 2" }
            };
            _mockEventoService.Setup(service => service.GetAllEventoAsync()).ReturnsAsync(eventos);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var retornoEventos = Assert.IsType<List<Evento>>(okResult.Value);
            Assert.Equal(eventos.Count, retornoEventos.Count);
        }
    }
}
