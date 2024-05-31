using BibliotecaGuiaJuegos.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaGuiaJuegos.DTOs
{
    public class GJAventuraDTO_PostPut : IGJAventura
    {
        [Required]
        [MaxLength(800)]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        public bool Importante { get; set; }

        [Required]
        public int Orden { get; set; }

        [Required]
        public int Id_Guia { get; set; }
    }
}
