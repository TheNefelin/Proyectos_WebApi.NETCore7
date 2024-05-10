using BibliotecaF1.Interfaces;

namespace BibliotecaF1.DTOs
{
    public class F1PilotoGetDTO : IBaseKey, IF1Piloto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime FechaNaci { get; set; }
        public float Estatura { get; set; }
        public int Peso { get; set; }
        public int Dorsal { get; set; }
        public string UrlPerfil { get; set; } = string.Empty;
        public bool EstaVivo { get; set; }
        public int Puntos { get; set; }
        public int IdPais { get; set; }
        public int IdEscuderia { get; set; }
    }
}
