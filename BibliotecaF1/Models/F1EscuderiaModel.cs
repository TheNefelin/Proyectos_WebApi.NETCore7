namespace BibliotecaF1.Models
{
    public class F1EscuderiaModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string UrlAuto { get; set; } = string.Empty;
        public int IdPais { get; set; }
        public ICollection<F1PilotoModel> F1Piloto { get; set; }
    }
}
