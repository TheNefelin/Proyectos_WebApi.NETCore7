using BibliotecaF1.Interfaces;

namespace BibliotecaF1.Models
{
    public class F1PaisModel : IBaseKey, IF1Pais
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string UrlBandera { get; set; } = string.Empty;
    }
}
