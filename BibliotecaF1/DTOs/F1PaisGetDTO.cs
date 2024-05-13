using BibliotecaF1.Interfaces;

namespace BibliotecaF1.DTOs
{
    public class F1PaisGetDTO : IF1Key, IF1Pais
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string UrlBandera { get; set; } = string.Empty;
    }
}
