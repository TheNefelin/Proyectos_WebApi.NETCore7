using BibliotecaGuiaJuegos.Interfaces;

namespace BibliotecaGuiaJuegos.DTOs
{
    public class GJRepoJuegoDTO : IKeyBase, IGJJuego
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Img { get; set; } = string.Empty;
        public bool Estado { get; set; }
        public List<GJPersonajeDTO_Get> Personajes { get; set; } = new List<GJPersonajeDTO_Get>();
        public List<GJFuenteDTO_Get> Fuentes { get; set; } = new List<GJFuenteDTO_Get>();
        public List<GJFondoImgDTO_Get> Fondos { get; set; } = new List<GJFondoImgDTO_Get>();
        public List<GJRepoGuiaDTO> Guias { get; set; } = new List<GJRepoGuiaDTO>();
    }
}
