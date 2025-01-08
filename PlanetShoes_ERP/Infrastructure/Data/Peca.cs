using PlanetShoes.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace PlanetShoes.Infrastructure.Data
{
    /// <summary>
    /// Classe base que representa uma peça genérica, que pode ser parte de um componente com peças.
    /// </summary>
    public class Peca
    {
        [Key]
        public string IdPeca { get; set; } 

        public AgrupamentoPeca Agrupamento { get; set; }
        public int Codigo { get; set; }
        public float Consumo { get; set; }
        public string Descricao { get; set; }
        public byte[] ImgPeca { get; set; } = new byte[0];
        public string Nome { get; set; }
        public TamanhoPeca Tamanho { get; set; }

        // Relacionamento com Materia Prima
        public string IdMateriaPrima { get; set; }
    }
}
