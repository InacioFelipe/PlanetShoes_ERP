using PlanetShoes.Infrastructure.Data;
using System.Threading.Tasks;

namespace PlanetShoes.Core.Interfaces
{
    public interface IPecaCabedalRepository
    {
        Task AddAsync(PecaDeCabedal pecaDeCabedal);
        Task UpdateAsync(PecaDeCabedal pecaDeCabedal);
        Task DeleteAsync(string id);
    }
}