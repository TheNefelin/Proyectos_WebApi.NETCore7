using BibliotecaGuiaJuegos.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaGuiaJuegos.DTOs
{
    public class GJGuiaDTO_PostPut : IGJGuia
    {
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public int Orden { get; set; }

        [Required]
        public int Id_Juego { get; set; }
    }
}
