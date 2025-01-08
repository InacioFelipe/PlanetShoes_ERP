using PlanetShoes.Core.Enums;

namespace PlanetShoes.Infrastructure.Data
{
    /// <summary>
    /// Representa um componente do tipo Solado, com classificações de estrutura, altura e design.
    /// </summary>
    public class SubEstruturaComPecaSolado : SubEstruturaComPeca
    {
       
        public AlturaSolado AlturaSolado { get; set; }
        public DesignSolado DesignSolado { get; set; }
        public TipoEstruturaSolado EstruturaSolado { get; set; }

        public List<Peca> Pecas { get; set; }
    }
}
