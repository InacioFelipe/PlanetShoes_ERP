using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetShoes.Core.Enums
{
    /// Enumeração das classificações de solado com base no design.
    public enum DesignSolado
    {
        /// Solado liso, ideal para superfícies lisas e indoor.
        Liso,

        /// Solado com gomos ou sulcos pronunciados para melhor tração.
        Gomos,

        /// Solado waffle com padrão quadrado para tração e absorção de impacto.
        Waffle,

        /// Solado com padrão hexagonal para flexibilidade e tração multidirecional.
        Hexagonal,

        /// Solado tratorado com padrão agressivo, ideal para terrenos irregulares.
        Tratorado,

        /// Solado plataforma que oferece maior altura e estilo.
        Plataforma,

        /// Solado flatform com superfície totalmente plana e espessura uniforme.
        Flatform,

        /// Solado ombro com design assimétrico para uma estética moderna.
        Ombro
    }
}
