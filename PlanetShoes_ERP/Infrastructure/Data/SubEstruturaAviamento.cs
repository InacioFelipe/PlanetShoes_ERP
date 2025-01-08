namespace PlanetShoes.Infrastructure.Data
{
    /// <summary>
    /// Representa um componente do tipo Aviamento, que pode ser composto por várias matérias-primas.
    /// </summary>
    public class SubEstruturaAviamento : Estrutura
    {
        public float Consumo { get; set; }
        public byte[] ImgAcabado { get; set; }
    }
}
