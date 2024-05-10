using BibliotecaF1.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaF1.DTOs
{
    public class F1PilotoPostPutDTO : IF1Piloto
    {
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public DateTime FechaNaci { get; set; }

        [Required]
        public float Estatura { get; set; }

        [Required]
        public int Peso { get; set; }

        [Required]
        public int Dorsal { get; set; }

        [Required]
        [MaxLength(50)]
        public string UrlPerfil { get; set; } = string.Empty;

        [Required]
        public bool EstaVivo { get; set; }

        [Required]
        public int Puntos { get; set; }

        [Required]
        public int IdPais { get; set; }

        [Required]
        public int IdEscuderia { get; set; }
    }
}
