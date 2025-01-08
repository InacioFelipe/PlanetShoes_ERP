using PlanetShoes.Core.Interfaces;
using PlanetShoes.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using PlanetShoes.Infrastructure.Context;

namespace PlanetShoes.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly PlanetShoesDbContext _context; // Atualizado para PlanetShoesDbContext

        public UsuarioRepository(PlanetShoesDbContext context) // Atualizado para PlanetShoesDbContext
        {
            _context = context;
        }

        public async Task<Usuario> GetUsuarioByUsernameAsync(string username)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}