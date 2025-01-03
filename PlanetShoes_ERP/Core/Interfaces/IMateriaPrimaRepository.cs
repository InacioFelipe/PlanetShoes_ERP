using PlanetShoes.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanetShoes.Core.Interfaces
{
    public interface IMateriaPrimaRepository
    {
        Task<List<MateriaPrima>> GetAllAsync(); // Retorna todas as matérias-primas
        Task<MateriaPrima> GetByIdAsync(string id); // Retorna uma matéria-prima por ID
        Task AddAsync(MateriaPrima materiaPrima); // Adiciona uma nova matéria-prima
        Task UpdateAsync(MateriaPrima materiaPrima); // Atualiza uma matéria-prima existente
        Task DeleteAsync(string id); // Remove uma matéria-prima por ID
    }
}