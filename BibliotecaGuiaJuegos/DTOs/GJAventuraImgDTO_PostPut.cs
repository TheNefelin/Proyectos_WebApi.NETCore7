using BibliotecaGuiaJuegos.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaGuiaJuegos.DTOs
{
    public class GJAventuraImgDTO_PostPut : IGJAventuraImg
    {
        [Required]
        [MaxLength(256)]
        public string Img { get; set; } = string.Empty;

        [Required]
        public int Orden { get; set; }

        [Required]
        public int Id_Aventura { get; set; }
    }
}
