using System.ComponentModel.DataAnnotations;

namespace PlanetShoes.Infrastructure.Data
{
    public class ProcessoProdutivo
    {
        [Key]
        public string IdProcessoProdutivo { get; set; } = Guid.NewGuid().ToString();
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public byte[] ImgProcessoProdutivo { get; set; } = Array.Empty<byte>();
    }
}
