using BibliotecaGuiaJuegos.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaGuiaJuegos.DTOs
{
    public class GJFondoImgDTO_PostPut : IGJFondoImg
    {
        [Required]
        [MaxLength(256)]
        public string Img { get; set; } = string.Empty;

        [Required]
        public int Id_Juego { get; set; }
    }
}
