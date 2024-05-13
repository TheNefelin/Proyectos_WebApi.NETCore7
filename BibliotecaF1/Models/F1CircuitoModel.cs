using BibliotecaF1.Interfaces;

namespace BibliotecaF1.Models
{
    public class F1CircuitoModel : IF1Key, IF1Circuito
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int IdPais { get; set; }
        public ICollection<F1CarreraModel> F1Carreras { get; set; }
    }
}
