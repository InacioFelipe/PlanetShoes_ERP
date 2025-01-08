namespace PlanetShoes.Infrastructure.Data
{
    public class PecaCabedal : Peca
    {
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public string NomeModelo { get; set; }
        public float Perimetro { get; set; }
        public float Superficie { get; set; }
    }
}
