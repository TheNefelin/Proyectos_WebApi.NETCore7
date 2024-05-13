using BibliotecaF1.Interfaces;

namespace BibliotecaF1.DTOs
{
    public class F1RepoEscuderiaDTO : IF1Key
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string UrlAuto { get; set; } = string.Empty;

        public F1PaisGetDTO Pais { get; set; }
        public List<F1RepoEscuderiaPilotoDTO> Pilotos { get; set; } 
    }
}
