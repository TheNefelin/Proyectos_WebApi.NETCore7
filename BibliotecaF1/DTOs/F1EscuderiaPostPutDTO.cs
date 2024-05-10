using BibliotecaF1.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaF1.DTOs
{
    public class F1EscuderiaPostPutDTO : IF1Escuderia
    {
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; } = String.Empty;

        [Required]
        [MaxLength(50)]
        
        public string UrlAuto { get; set; } = String.Empty;
        [Required]
        public int IdPais { get; set; }
    }
}
