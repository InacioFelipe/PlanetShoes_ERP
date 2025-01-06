using PlanetShoes.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetShoes.Infrastructure.Data
{
    /// <summary>
    /// Representa um componente do tipo Solado, com classificações de estrutura, altura e design.
    /// </summary>
    public class Solado : ComponenteComPecas
    {
        public TipoEstruturaSolado TipoEstrutura { get; set; }
        public AlturaSolado Altura { get; set; }
        public DesignSolado Design { get; set; }
    }
}
