using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetShoes.Core.Enums
{
    /// Enumeração das classificações de solado com base na altura.
    public enum AlturaSolado
    {
        /// Solado rasteiro com altura de 0 - 2 cm.
        Rasteiro,

        /// Solado baixo com altura de 2 - 4 cm.
        Baixo,

        /// Solado médio com altura de 4 - 6 cm.
        Medio,

        /// Solado alto com altura de 6 - 8 cm.
        Alto,

        /// Solado plataforma com altura superior a 8 cm.
        Plataforma
    }
}
