using PlanetShoes.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetShoes.Core.Interfaces
{
    public interface IEstruturaRepository
    {
        Task<List<Estrutura>> GetAllAsync(); // Retorna todas as estruturas
        Task<Estrutura> GetByIdAsync(string id); // Retorna uma estrutura por ID
        Task AddAsync(Estrutura estrutura); // Adiciona uma nova estrutura
        Task UpdateAsync(Estrutura estrutura); // Atualiza uma estrutura existente
        Task DeleteAsync(string id); // Remove uma estrutura por ID

    }
}
