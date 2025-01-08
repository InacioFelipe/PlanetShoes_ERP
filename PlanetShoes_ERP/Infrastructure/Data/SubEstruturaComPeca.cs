using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetShoes.Infrastructure.Data
{
    /// <summary>
    /// Representa um componente que pode ser dividido em várias peças, como solado ou cabedal.
    /// </summary>
    public class SubEstruturaComPeca : Estrutura
    {
        public byte[] ImgSubEstruturaComPeca { get; set; } = new byte[0];
    }
}
