using Microsoft.EntityFrameworkCore;
using PlanetShoes.Core.Enums;
using PlanetShoes.Core.Interfaces;
using PlanetShoes.Infrastructure.Context;
using PlanetShoes.Infrastructure.Data;

namespace PlanetShoes.Infrastructure.Repositories
{
    public class PecaRepository : IPecaRepository
    {

        private readonly PlanetShoesDbContext _context;

        public PecaRepository(PlanetShoesDbContext context)
        {
            _context = context;
        }

        public async Task<List<Peca>> GetPecasByEstruturaIdAsync(string idEstrutura)
        {
            return await _context.Pecas
                .Where(p => p.IdEstrutura == idEstrutura)
                .ToListAsync();
        }
    }
}
