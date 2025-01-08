namespace PlanetShoes.Infrastructure.Data
{
    /// <summary>
    /// Representa um componente do tipo Acabado, que pode ser composto por várias matérias-primas.
    /// </summary>
    public class SubEstruturaAcabado : Estrutura
    {
        public float Consumo { get; set; }
        public byte[] ImgAcabado { get; set; }
    }
}
