using BibliotecaF1.Interfaces;

namespace BibliotecaF1.DTOs
{
    public class F1RepoPilotoDTO : IF1Key
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public float Estatura { get; set; }
        public float Peso { get; set; }
        public int Dorsal { get; set; }
        public string UrlPerfil { get; set; } = string.Empty;
        public bool EstaVivo { get; set; }
        public int Puntos { get; set; }

        public F1PaisGetDTO Pais { get; set; }
        public F1RepoPilotoEscuderiaDTO Escuderia { get; set; }
    }
}
