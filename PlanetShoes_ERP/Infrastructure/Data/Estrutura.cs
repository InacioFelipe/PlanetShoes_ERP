using PlanetShoes.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace PlanetShoes.Infrastructure.Data
{
    /// <summary>
    /// Classe base que representa uma estrutura genérica no sistema.
    /// Pode ser um acabado, aviamento ou componente com peças.
    /// </summary>
    public abstract class Estrutura
    {
        [Key] // Chave primária
        public string Id { get; set; } = Guid.NewGuid().ToString(); // ID gerado por GUID

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public TipoEstrutura TipoEstrutura { get; set; }
        public byte[] Imagem { get; set; } = Array.Empty<byte>(); // Vetor de bytes para a imagem
    }
}
