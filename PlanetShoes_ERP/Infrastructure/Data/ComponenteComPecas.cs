using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetShoes.Infrastructure.Data
{
    /// <summary>
    /// Representa um componente que pode ser dividido em várias peças, como solado ou cabedal.
    /// </summary>
    public class ComponenteComPecas : Estrutura
    {
        public List<Peca> Pecas { get; set; } = new List<Peca>();
    }
}
