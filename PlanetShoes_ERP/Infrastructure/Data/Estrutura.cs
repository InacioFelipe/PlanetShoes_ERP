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
        public string? NomeEstrutura {  get; set; }
        public string TipoEstrutura { get; set; }


        // Propriedades de navegação para as subestruturas
        public List<SubEstruturaAcabado> SubEstruturasAcabado { get; set; } = new List<SubEstruturaAcabado>();
        public List<SubEstruturaAviamento> SubEstruturasAviamento { get; set; } = new List<SubEstruturaAviamento>();
        public List<SubEstruturaComPeca> SubEstruturasComPeca { get; set; } = new List<SubEstruturaComPeca>();
    }
}
