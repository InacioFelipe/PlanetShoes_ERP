using PlanetShoes.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanetShoes.Core.Interfaces
{
    public interface IMateriaPrimaRepository
    {
        // Retorna uma lista de todas as matérias-primas
        Task<List<MateriaPrima>> GetAllAsync();

        // Retorna uma matéria-prima específica com base no ID
        Task<MateriaPrima> GetByIdAsync(string id);

        // Retorna uma matéria-prima específica com base no Codigo
        Task<MateriaPrima> GetByCodAsync(int cod);

        // Adiciona uma nova matéria-prima ao banco de dados
        Task AddAsync(MateriaPrima materiaPrima);

        // Atualiza uma matéria-prima existente no banco de dados
        Task UpdateAsync(MateriaPrima materiaPrima);

        // Remove uma matéria-prima do banco de dados com base no ID
        Task DeleteAsync(string id);
    }
}