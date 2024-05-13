using BibliotecaF1.Interfaces;

namespace BibliotecaF1.DTOs
{
    public class F1CircuitoGetDTO : IF1Key, IF1Circuito
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int IdPais { get; set; }
    }
}
