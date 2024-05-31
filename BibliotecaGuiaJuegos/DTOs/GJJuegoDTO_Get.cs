using BibliotecaGuiaJuegos.Interfaces;

namespace BibliotecaGuiaJuegos.DTOs
{
    public class GJJuegoDTO_Get : IKeyBase, IGJJuego
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Img { get; set; } = string.Empty;
        public bool Estado { get; set; }
    }
}
