using BibliotecaF1.Interfaces;

namespace BibliotecaF1.DTOs
{
    public class F1CarreraGetDTO : IBaseKey, IF1Carrera
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Clima { get; set; } = string.Empty;
        public int IdCircuito { get; set; }
    }
}
