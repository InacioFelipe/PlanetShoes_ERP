using PlanetShoes.Core.Interfaces;
using PlanetShoes.Infrastructure.Context;
using PlanetShoes.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace PlanetShoes.Infrastructure.Repositories
{
    public class EstruturaRepository : IEstruturaRepository
    {
        private readonly PlanetShoesDbContext _context;

        public EstruturaRepository(PlanetShoesDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Estrutura>> GetAllAsync()
        {
            return await _context.Estruturas.ToListAsync();
        }

        public async Task<Estrutura> GetByIdAsync(string id)
        {
            return await _context.Estruturas.FindAsync(id);
        }

        public async Task AddAsync(Estrutura estrutura)
        {
            await _context.Estruturas.AddAsync(estrutura);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Estrutura estrutura)
        {
            _context.Estruturas.Update(estrutura);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var estrutura = await _context.Estruturas.FindAsync(id);
            if (estrutura != null)
            {
                _context.Estruturas.Remove(estrutura);
                await _context.SaveChangesAsync();
            }
        }
    }
}
