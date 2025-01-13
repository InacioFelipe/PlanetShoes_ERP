using Microsoft.EntityFrameworkCore;
using PlanetShoes.Core.Interfaces;
using PlanetShoes.Infrastructure.Context;
using PlanetShoes.Infrastructure.Data;

namespace PlanetShoes.Infrastructure.Repositories
{
    public class MateriaPrimaRepository : IMateriaPrimaRepository
    {
        //private readonly PlanetShoesDbContext _context;
        //public MateriaPrimaRepository(PlanetShoesDbContext context)
        //{
        //    _context = context;
        //}


        private readonly IDbContextFactory<PlanetShoesDbContext> _contextFactory;

        public MateriaPrimaRepository(IDbContextFactory<PlanetShoesDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        

        public async Task<List<MateriaPrima>> GetAllAsync()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.MateriasPrimas.ToListAsync();
            }
        }

        public async Task<MateriaPrima> GetByIdAsync(string id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.MateriasPrimas.FindAsync(id);
            }
        }

        public async Task<MateriaPrima> GetByCodAsync(int cod)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.MateriasPrimas
                                .FirstOrDefaultAsync(mp => mp.Codigo == cod);
            }
        }

        public async Task<List<MateriaPrima>> GetByPecasCodigosAsync(List<int> codigosPecas)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.MateriasPrimas
                                    .Where(mp => codigosPecas.Contains(mp.Codigo))
                                    .ToListAsync();
            }
        }

        public async Task AddAsync(MateriaPrima materiaPrima)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                await context.MateriasPrimas.AddAsync(materiaPrima);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(MateriaPrima materiaPrima)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.MateriasPrimas.Update(materiaPrima);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(string id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var materiaPrima = await context.MateriasPrimas.FindAsync(id);
                if (materiaPrima != null)
                {
                    context.MateriasPrimas.Remove(materiaPrima);
                    await context.SaveChangesAsync();
                }
            }
        }

        
    }
}