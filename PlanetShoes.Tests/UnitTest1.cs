namespace PlanetShoes.Tests
{
    public class EstruturaTests : IDisposable
    {
        private readonly DbContextOptions<PlanetShoesDbContext> _options;
        private readonly PlanetShoesDbContext _context;
        private readonly IEstruturaRepository _estruturaRepository;

        public EstruturaTests()
        {
            // Configura o banco em memória
            _options = new DbContextOptionsBuilder<PlanetShoesDbContext>()
                .UseInMemoryDatabase(databaseName: "EstruturaTestDb")
                .Options;

            _context = new PlanetShoesDbContext(_options);
            _estruturaRepository = new EstruturaRepository(_context);
        }

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
    }
}