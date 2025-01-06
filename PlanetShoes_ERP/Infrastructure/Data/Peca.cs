using PlanetShoes.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace PlanetShoes.Infrastructure.Data
{
    /// <summary>
    /// Classe base que representa uma peça genérica, que pode ser parte de um componente com peças.
    /// </summary>
    public class Peca
    {
        [Key] // Chave primária
        public string IdPeca { get; set; } = Guid.NewGuid().ToString(); // ID gerado por GUID
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public byte[] Imagem { get; set; } = Array.Empty<byte>(); // Vetor de bytes para a imagem
        public AgrupamentoPeca Agrupamento { get; set; }
        public TamanhoPeca Tamanho { get; set; }
    }
}
