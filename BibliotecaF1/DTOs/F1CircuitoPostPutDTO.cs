using BibliotecaF1.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaF1.DTOs
{
    public class F1CircuitoPostPutDTO : IF1Circuito
    {
        [Required]
        [MaxLength(256)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public int IdPais { get; set; }
    }
}
