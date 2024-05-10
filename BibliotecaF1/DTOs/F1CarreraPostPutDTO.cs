using BibliotecaF1.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaF1.DTOs
{
    public class F1CarreraPostPutDTO : IF1Carrera
    {
        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        [MaxLength(256)]
        public string Clima { get; set; } = string.Empty;

        [Required]
        public int IdCircuito { get; set; }
    }
}
