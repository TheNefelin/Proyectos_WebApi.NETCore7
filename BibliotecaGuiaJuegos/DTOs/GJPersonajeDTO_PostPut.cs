﻿using BibliotecaGuiaJuegos.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaGuiaJuegos.DTOs
{
    public class GJPersonajeDTO_PostPut : IGJPersonaje
    {
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(256)]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        [MaxLength(256)]
        public string Img { get; set; } = string.Empty;

        [Required]
        public int Id_Juego { get; set; }
    }
}
