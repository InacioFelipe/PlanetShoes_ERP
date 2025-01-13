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
        //private readonly PlanetShoesDbContext _context;

        //public EstruturaRepository(PlanetShoesDbContext context)
        //{
        //    _context = context;
        //}

        private readonly IDbContextFactory<PlanetShoesDbContext> _contextFactory;

        public EstruturaRepository(IDbContextFactory<PlanetShoesDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<Estrutura>> GetAllEstruturasAsync()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Estruturas.ToListAsync();
            }
        }

        public async Task<Estrutura> GetEstruturaCompletaAsync(string id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Estruturas.FindAsync(id);
            }
        }

        public async Task AddEstruturaAsync(Estrutura estrutura)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                await context.Estruturas.AddAsync(estrutura);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateEstruturaAsync(Estrutura estrutura)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Estruturas.Update(estrutura);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteEstruturaAsync(string id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var estrutura = await context.Estruturas.FindAsync(id);
                if (estrutura != null)
                {
                    context.Estruturas.Remove(estrutura);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}