using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Presentation.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PresentationTest.ControllerTest
{
    public class ArtistaControllerTest
    {
        private readonly ArtistaController _controller;
        private readonly Mock<IArtistaService> _mockArtistaService;

        public ArtistaControllerTest()
        {
            _mockArtistaService = new Mock<IArtistaService>();
            _controller = new ArtistaController(_mockArtistaService.Object);
        }

        [Fact]
        public async Task Create_DeveRetornarCreatedAtAction_QuandoArtistaForCriado()
        {
            // Arrange
            var artista = new Artista { ArtistaId = 1, Nome = "Artista Teste" };
            _mockArtistaService.Setup(s => s.AddArtistaAsync(It.IsAny<Artista>())).ReturnsAsync(artista.ArtistaId);

            // Act
            var result = await _controller.Create(artista);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetById", createdAtActionResult.ActionName);
            Assert.Equal(artista.ArtistaId, ((Artista)createdAtActionResult.Value).ArtistaId);
        }

        [Fact]
        public async Task GetById_DeveRetornarOk_QuandoArtistaExiste()
        {
            // Arrange
            var artista = new Artista { ArtistaId = 1, Nome = "Artista Teste" };
            _mockArtistaService.Setup(s => s.GetArtistaByIdAsync(1)).ReturnsAsync(artista);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedArtista = Assert.IsType<Artista>(okResult.Value);
            Assert.Equal(artista.ArtistaId, returnedArtista.ArtistaId);
        }

        [Fact]
        public async Task GetById_DeveRetornarNotFound_QuandoArtistaNaoExiste()
        {
            // Arrange
            _mockArtistaService.Setup(s => s.GetArtistaByIdAsync(1)).ReturnsAsync((Artista)null);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetAll_DeveRetornarOk_QuandoExistemArtistas()
        {
            // Arrange
            var artistas = new List<Artista>
            {
                new Artista { ArtistaId = 1, Nome = "Artista Teste 1" },
                new Artista { ArtistaId = 2, Nome = "Artista Teste 2" }
            };
            _mockArtistaService.Setup(s => s.GetAllArtistaAsync()).ReturnsAsync(artistas);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedArtistas = Assert.IsType<List<Artista>>(okResult.Value);
            Assert.Equal(2, returnedArtistas.Count);
        }

        [Fact]
        public async Task Update_DeveRetornarOk_QuandoArtistaForAtualizado()
        {
            // Arrange
            var artista = new Artista { ArtistaId = 1, Nome = "Artista Atualizado" };
            _mockArtistaService.Setup(s => s.UpdateArtistaAsync(It.IsAny<Artista>())).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Update(artista.ArtistaId, artista);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var updatedArtista = Assert.IsType<Artista>(okResult.Value);
            Assert.Equal(artista.Nome, updatedArtista.Nome);
        }

        [Fact]
        public async Task Update_DeveRetornarBadRequest_QuandoIdNaoCorresponde()
        {
            // Arrange
            var artista = new Artista { ArtistaId = 1, Nome = "Artista Atualizado" };

            // Act
            var result = await _controller.Update(2, artista);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Delete_DeveRetornarNoContent_QuandoArtistaForDeletado()
        {
            // Arrange
            _mockArtistaService.Setup(s => s.DeleteArtistaAsync(1)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}

