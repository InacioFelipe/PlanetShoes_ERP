using PlanetShoes.Core.Enums;

namespace PlanetShoes.Infrastructure.Data
{
    /// <summary>
    /// Representa um componente do tipo Cabedal, com classificações de estrutura, design e modelista técnico.
    /// </summary>
    public class Cabedal : ComponenteComPecas
    {
        public TipoEstruturaCabedal TipoEstrutura { get; set; }
        public DesignCabedal Design { get; set; }
        public string ModelistaTecnico { get; set; }
    }
}
