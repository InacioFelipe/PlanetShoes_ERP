using Microsoft.EntityFrameworkCore;
using PlanetShoes.Core.Interfaces;
using PlanetShoes.Infrastructure.Context;
using PlanetShoes.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanetShoes.Infrastructure.Repositories
{
    public class MateriaPrimaRepository : IMateriaPrimaRepository
    {
        private readonly PlanetShoesDbContext _context;

        public MateriaPrimaRepository(PlanetShoesDbContext context)
        {
            _context = context;
        }

        public async Task<List<MateriaPrima>> GetAllAsync()
        {
            return await _context.MateriasPrimas.ToListAsync();
        }

        public async Task<MateriaPrima> GetByIdAsync(string id)
        {
            return await _context.MateriasPrimas.FindAsync(id);
        }

        public async Task AddAsync(MateriaPrima materiaPrima)
        {
            await _context.MateriasPrimas.AddAsync(materiaPrima);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MateriaPrima materiaPrima)
        {
            _context.MateriasPrimas.Update(materiaPrima);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var materiaPrima = await _context.MateriasPrimas.FindAsync(id);
            if (materiaPrima != null)
            {
                _context.MateriasPrimas.Remove(materiaPrima);
                await _context.SaveChangesAsync();
            }
        }
    }
}