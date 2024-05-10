using BibliotecaF1.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaF1.DTOs 
{
    public class F1PaisPostPutDTO : IF1Pais
    {
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string UrlBandera { get; set; } = string.Empty;
    }
}
