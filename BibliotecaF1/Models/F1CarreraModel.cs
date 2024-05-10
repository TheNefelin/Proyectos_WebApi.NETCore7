using BibliotecaF1.Interfaces;

namespace BibliotecaF1.Models
{
    public class F1CarreraModel : IBaseKey, IF1Carrera
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Clima { get; set; } = string.Empty;
        public int IdCircuito { get; set; }
        public F1CircuitoModel F1Circuito { get; set; }
    }
}
