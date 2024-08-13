using Presentation.Controllers;
using Domain.Entities;
using Domain.Services;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;
using Application.Services;

namespace PresentationTest.ControllerTest
{
    public class UsuarioControllerTest
    {
        private readonly UsuarioController _controller;
        private readonly Mock<IUsuarioService> _mockService;

        public UsuarioControllerTest()
        {
            _mockService = new Mock<IUsuarioService>();
            _controller = new UsuarioController(_mockService.Object);
        }

        [Fact]
        public async Task Create_DeveRetornarCreatedAtAction_QuandoUsuarioForCriado()
        {
            // Arrange
            var usuario = new Usuario { UsuarioId = 1, Nome = "Teste" };
            _mockService.Setup(service => service.AddUsuarioAsync(It.IsAny<Usuario>()))
                        .ReturnsAsync(usuario.UsuarioId);

            // Act
            var result = await _controller.Create(usuario);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(nameof(_controller.GetById), createdAtActionResult.ActionName);
            Assert.Equal(usuario.UsuarioId, createdAtActionResult.RouteValues["id"]);
        }

        [Fact]
        public async Task GetById_DeveRetornarOk_QuandoUsuarioExiste()
        {
            // Arrange
            var mockService = new Mock<IUsuarioService>();
            var usuarioId = 1;
            var usuario = new Usuario { UsuarioId = usuarioId, Nome = "João" };
            mockService.Setup(service => service.GetUsuarioByIdAsync(usuarioId)).ReturnsAsync(usuario);

            var controller = new UsuarioController(mockService.Object);

            // Act
            var result = await controller.GetById(usuarioId);

            // Assert
            // Verifique se o resultado é do tipo ActionResult e depois se é OkObjectResult
            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            // Verifique o valor dentro do OkObjectResult
            var retornoUsuario = Assert.IsType<Usuario>(okResult.Value);
            Assert.Equal(usuarioId, retornoUsuario.UsuarioId);
            Assert.Equal("João", retornoUsuario.Nome);
        }



        [Fact]
        public async Task GetById_DeveRetornarNotFound_QuandoUsuarioNaoExiste()
        {
            // Arrange
            var mockService = new Mock<IUsuarioService>();
            var usuarioId = 1;
            mockService.Setup(service => service.GetUsuarioByIdAsync(usuarioId)).ReturnsAsync((Usuario)null);

            var controller = new UsuarioController(mockService.Object);

            // Act
            var result = await controller.GetById(usuarioId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result.Result);
        }


        [Fact]
        public async Task GetAll_DeveRetornarOk_ComListaDeUsuarios()
        {
            // Arrange
            var mockService = new Mock<IUsuarioService>();
            var usuarios = new List<Usuario> { new Usuario { UsuarioId = 1, Nome = "João" } };
            mockService.Setup(service => service.GetAllUsuarioAsync()).ReturnsAsync(usuarios);

            var controller = new UsuarioController(mockService.Object);

            // Act
            var result = await controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var retornoUsuarios = Assert.IsType<List<Usuario>>(okResult.Value);
            Assert.NotEmpty(retornoUsuarios);
        }


        [Fact]
        public async Task Update_DeveRetornarBadRequest_QuandoIdNaoCorrespondeAoUsuario()
        {
            // Arrange
            var usuarioId = 1;
            var usuario = new Usuario { UsuarioId = 2, Nome = "Teste" };

            // Act
            var result = await _controller.Update(usuarioId, usuario);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Update_DeveRetornarOk_QuandoUsuarioForAtualizado()
        {
            // Arrange
            var usuarioId = 1;
            var usuario = new Usuario { UsuarioId = usuarioId, Nome = "Teste" };

            _mockService.Setup(service => service.UpdateUsuarioAsync(usuario))
                        .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Update(usuarioId, usuario);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(usuario, okResult.Value);
        }

        [Fact]
        public async Task Delete_DeveRetornarNoContent_QuandoUsuarioForDeletado()
        {
            // Arrange
            var usuarioId = 1;

            _mockService.Setup(service => service.DeleteUsuarioAsync(usuarioId))
                        .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Delete(usuarioId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
