using PlanetShoes.Infrastructure.Data;
using PlanetShoes.Infrastructure.Repositories;
using PlanetShoes.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Threading.Tasks;
using System.Collections.Generic;
using PlanetShoes.Infrastructure.Context;

namespace PlanetShoes.Infrastructure.Tests.EstruturaTest
{
    public class EstruturaTests : IDisposable
    {
        private readonly DbContextOptions<PlanetShoesDbContext> _options;
        private readonly PlanetShoesDbContext _context;
        private readonly IEstruturaRepository _estruturaRepository;

        //public EstruturaTests()
        //{
        //    // Configura o banco em memória
        //    _options = new DbContextOptionsBuilder<PlanetShoesDbContext>()
        //        .UseInMemoryDatabase(databaseName: "EstruturaTestDb")
        //        .Options;

        //    _context = new PlanetShoesDbContext(_options);
        //    _estruturaRepository = new EstruturaRepository(_context);
        //}

        // Implementação do IDisposable
        public void Dispose()
        {
            // Limpa o banco de dados após cada teste
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Fact]
        public async Task GetAllEstruturasAsync_RetornaTodasEstruturas()
        {
            // Arrange
            var estrutura1 = new Estrutura { IdEstrutura = "1", IdSubEstrutura = "Sub1" };
            var estrutura2 = new Estrutura { IdEstrutura = "2", IdSubEstrutura = "Sub2" };

            _context.Estruturas.Add(estrutura1);
            _context.Estruturas.Add(estrutura2);
            await _context.SaveChangesAsync();

            // Act
            var result = await _estruturaRepository.GetAllEstruturasAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task AddEstruturaAsync_EstruturaValida_AdicionaEstrutura()
        {
            // Arrange
            var estrutura = new Estrutura { IdEstrutura = "1", IdSubEstrutura = "Sub1" };

            // Act
            await _estruturaRepository.AddEstruturaAsync(estrutura);
            var result = await _context.Estruturas.FindAsync("1");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("1", result.IdEstrutura);
        }

        [Fact]
        public async Task UpdateEstruturaAsync_EstruturaExistente_AtualizaEstrutura()
        {
            // Arrange
            var estrutura = new Estrutura { IdEstrutura = "1", IdSubEstrutura = "Sub1" };
            _context.Estruturas.Add(estrutura);
            await _context.SaveChangesAsync();

            estrutura.IdSubEstrutura = "Sub2";

            // Act
            await _estruturaRepository.UpdateEstruturaAsync(estrutura);
            var result = await _context.Estruturas.FindAsync("1");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Sub2", result.IdSubEstrutura);
        }

        [Fact]
        public async Task DeleteEstruturaAsync_EstruturaExistente_RemoveEstrutura()
        {
            // Arrange
            var estrutura = new Estrutura { IdEstrutura = "1", IdSubEstrutura = "Sub1" };
            _context.Estruturas.Add(estrutura);
            await _context.SaveChangesAsync();

            // Act
            await _estruturaRepository.DeleteEstruturaAsync("1");
            var result = await _context.Estruturas.FindAsync("1");

            // Assert
            Assert.Null(result);
        }
    }
}