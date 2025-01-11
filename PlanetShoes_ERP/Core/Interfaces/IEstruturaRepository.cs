using PlanetShoes.Core.Enums;
using PlanetShoes.Infrastructure.Data;

namespace PlanetShoes.Core.Interfaces
{
    public interface IEstruturaRepository
    {
        Task<List<Estrutura>> GetAllEstruturasAsync();
        Task AddEstruturaAsync(Estrutura estrutura);
        Task UpdateEstruturaAsync(Estrutura estrutura);
        Task DeleteEstruturaAsync(string id);
    }
}