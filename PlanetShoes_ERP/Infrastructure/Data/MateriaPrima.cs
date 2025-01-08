using PlanetShoes.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace PlanetShoes.Infrastructure.Data
{
    public class MateriaPrima
    {
        [Key]
        public string? IdMateriaPrima { get; set; }

        public int Codigo { get; set; }
        public string? Nome { get; set; }
        public string? Classe { get; set; }
        public string? Descricao { get; set; }
        public UnidadeDeMedida? UnidadeMedida { get; set; }
        public decimal? Valor { get; set; }
        public decimal? ValorUnitario { get; set; }
        public byte[]? ImgMateriaPrima { get; set; }
    }
}
