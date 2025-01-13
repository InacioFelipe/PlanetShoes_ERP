using PlanetShoes.Core.Interfaces;
using PlanetShoes.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using PlanetShoes.Infrastructure.Context;

namespace PlanetShoes.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        //private readonly PlanetShoesDbContext _context; // Atualizado para PlanetShoesDbContext

        //public UsuarioRepository(PlanetShoesDbContext context) // Atualizado para PlanetShoesDbContext
        //{
        //    _context = context;
        //}

        private readonly IDbContextFactory<PlanetShoesDbContext> _contextFactory;

        public UsuarioRepository(IDbContextFactory<PlanetShoesDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<Usuario> GetUsuarioByUsernameAsync(string username)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Usuarios.FirstOrDefaultAsync(u => u.Username == username);
            }
        }
    }
}