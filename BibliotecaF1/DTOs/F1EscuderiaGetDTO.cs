using BibliotecaF1.Interfaces;

namespace BibliotecaF1.DTOs
{
    public class F1EscuderiaGetDTO : IBaseKey, IF1Escuderia
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = String.Empty;
        public string UrlAuto { get; set; } = String.Empty;
        public int IdPais { get; set; }
    }
}
