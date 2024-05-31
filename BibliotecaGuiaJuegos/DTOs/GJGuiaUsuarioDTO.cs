using BibliotecaGuiaJuegos.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaGuiaJuegos.DTOs
{
    public class GJGuiaUsuarioDTO : IGJGuiaUsuario
    {
        [Required]
        public int Id_Guia { get; set; }

        [Required]
        [MaxLength(256)]
        public string Id_Usuario { get; set; } = string.Empty;

        [Required]
        public bool Estado { get; set; }
    }
}
