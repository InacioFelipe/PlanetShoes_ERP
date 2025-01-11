using PlanetShoes.Core.Enums;
using PlanetShoes.Infrastructure.Data;

namespace PlanetShoes.Core.Interfaces
{
    public interface IPecaRepository
    {
        Task<List<Peca>> GetPecasByEstruturaIdAsync(string idEstrutura); 
    }
}
