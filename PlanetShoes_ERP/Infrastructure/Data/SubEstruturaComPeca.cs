namespace PlanetShoes.Infrastructure.Data
{
    /// <summary>
    /// Representa um componente que pode ser dividido em várias peças, como solado ou cabedal.
    /// </summary>
    public class SubEstruturaComPeca : Estrutura
    {
        public byte[] ImgSubEstruturaComPeca { get; set; } = new byte[0];

        // Propriedade de navegação para as peças
        public List<Peca> Pecas { get; set; } = new List<Peca>();
    }
}
