using PlanetShoes.Core.Interfaces;
using PlanetShoes.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanetShoes.Infrastructure.Repositories
{
    public class PecaCabedalRepository : IPecaCabedalRepository
    {
        private readonly PlanetShoesDbContext _context;

        public PecaCabedalRepository(PlanetShoesDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(PecaDeCabedal pecaDeCabedal)
        {
            await _context.PecasCabedal.AddAsync(pecaDeCabedal);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PecaDeCabedal pecaDeCabedal)
        {
            _context.PecasCabedal.Update(pecaDeCabedal);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var pecaDeCabedal = await _context.PecasCabedal.FindAsync(id);
            if (pecaDeCabedal != null)
            {
                _context.PecasCabedal.Remove(pecaDeCabedal);
                await _context.SaveChangesAsync();
            }
        }
    }
}
