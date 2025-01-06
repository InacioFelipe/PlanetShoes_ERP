using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetShoes.Infrastructure.Data
{
    /// <summary>
    /// Representa uma peça específica para solados, com propriedades como peso, volume e consumo.
    /// </summary>
    public class PecaDeSolado : Peca
    {
        public float Peso { get; set; } // Usando float
        public float Volume { get; set; } // Usando float
        public MateriaPrima MateriaPrima { get; set; }
        public float Consumo { get; set; } // Usando float
    }
}
