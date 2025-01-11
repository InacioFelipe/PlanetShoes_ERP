using PlanetShoes.Infrastructure.Data;
using PlanetShoes.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlanetShoes.Infrastructure.Context;

namespace PlanetShoes.Infrastructure.Repositories
{
    public class EstruturaRepository : IEstruturaRepository
    {
        private readonly PlanetShoesDbContext _context;

        public EstruturaRepository(PlanetShoesDbContext context)
        {
            _context = context;
        }

        public async Task<List<Estrutura>> GetAllEstruturasAsync()
        {
            return await _context.Estruturas.ToListAsync();
        }

        public async Task<Estrutura> GetEstruturaCompletaAsync(string id)
        {
            return await _context.Estruturas.FindAsync(id);
        }

        public async Task AddEstruturaAsync(Estrutura estrutura)
        {
            await _context.Estruturas.AddAsync(estrutura);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEstruturaAsync(Estrutura estrutura)
        {
            _context.Estruturas.Update(estrutura);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEstruturaAsync(string id)
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