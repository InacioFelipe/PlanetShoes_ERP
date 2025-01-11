using PlanetShoes.Infrastructure.Data;
using PlanetShoes.Infrastructure.Repositories;
using PlanetShoes.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Threading.Tasks;
using PlanetShoes.Infrastructure.Context;

namespace PlanetShoes.Infrastructure.Tests.LoginTest
{
    public class LoginTests
    {
        private readonly PlanetShoesDbContext _context;
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginTests()
        {
            // Configura o banco em memória
            var options = new DbContextOptionsBuilder<PlanetShoesDbContext>()
                .UseInMemoryDatabase(databaseName: "LoginTestDb")
                .Options;

            _context = new PlanetShoesDbContext(options);
            _usuarioRepository = new UsuarioRepository(_context);
        }

        [Fact]
        public async Task GetUsuarioByUsernameAsync_UsuarioExistente_RetornaUsuario()
        {
            // Arrange
            var usuario = new Usuario
            {
                UserId = "1",
                Username = "testuser",
                Password = "password",
                Email = "test@example.com",
                DisplayName = "Test User"
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            // Act
            var result = await _usuarioRepository.GetUsuarioByUsernameAsync("testuser");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("testuser", result.Username);
        }

        [Fact]
        public async Task GetUsuarioByUsernameAsync_UsuarioNaoExistente_RetornaNull()
        {
            // Act
            var result = await _usuarioRepository.GetUsuarioByUsernameAsync("nonexistentuser");

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetUsuarioByUsernameAsync_UsuarioComUsernameNulo_RetornaNull()
        {
            // Act
            var result = await _usuarioRepository.GetUsuarioByUsernameAsync(null);

            // Assert
            Assert.Null(result);
        }
    }
}