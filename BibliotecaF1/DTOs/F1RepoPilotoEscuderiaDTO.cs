namespace BibliotecaF1.DTOs
{
    public class F1RepoPilotoEscuderiaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string UrlAuto { get; set; } = string.Empty;

        public F1PaisGetDTO Pais { get; set; }
    }
}
