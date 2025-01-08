using System.ComponentModel.DataAnnotations;

namespace PlanetShoes.Infrastructure.Data
{
    /// <summary>
    /// Classe base que representa uma estrutura genérica no sistema.
    /// Pode ser um acabado, aviamento ou componente com peças.
    /// </summary>
    public class Estrutura
    {
        [Key]
        public string IdEstrutura { get; set; } 
        public string IdSubEstrutura { get; set; } 
    }
}
