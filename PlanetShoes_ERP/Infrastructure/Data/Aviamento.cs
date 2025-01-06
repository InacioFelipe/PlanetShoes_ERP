using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetShoes.Infrastructure.Data
{
    /// <summary>
    /// Representa um componente do tipo Aviamento, que pode ser composto por várias matérias-primas.
    /// </summary>
    public class Aviamento : Estrutura
    {
        public List<MateriaPrima> MateriasPrimas { get; set; } = new List<MateriaPrima>();
    }
}
