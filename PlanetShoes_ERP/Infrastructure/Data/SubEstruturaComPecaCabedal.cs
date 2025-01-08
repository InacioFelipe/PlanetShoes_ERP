using PlanetShoes.Core.Enums;

namespace PlanetShoes.Infrastructure.Data
{
    /// <summary>
    /// Representa um componente do tipo Cabedal, com classificações de estrutura, design e modelista técnico.
    /// </summary>
    public class SubEstruturaComPecaCabedal : SubEstruturaComPeca
    {
        public DesignCabedal DesignCabedal { get; set; }
        public TipoEstruturaCabedal EstruturaCabedal { get; set; }
        public List<Peca> Pecas { get; set; } = new List<Peca>();
    }
}
