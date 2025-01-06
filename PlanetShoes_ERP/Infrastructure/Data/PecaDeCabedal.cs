using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetShoes.Infrastructure.Data
{
    public class PecaDeCabedal : Peca
    {
        // Relacionamento: Uma PecaDeCabedal pode ser associada a uma matéria-prima
        public MateriaPrima MateriaPrima { get; set; }

        public string NomeModelo { get; set; }
        public short Quantidades { get; set; } // Usando short
        public string Categoria { get; set; }
        public DateTime DataConfeccao { get; set; }
        public TimeSpan HoraConfeccao { get; set; }
        public float Perimetro { get; set; } // Usando float
        public float Superficie { get; set; } // Alterado para float
        public string Informacoes { get; set; }
        public float Consumo { get; set; } // Usando float
    }
}
