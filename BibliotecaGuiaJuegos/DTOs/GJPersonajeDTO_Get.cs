using BibliotecaGuiaJuegos.Interfaces;

namespace BibliotecaGuiaJuegos.DTOs
{
    public class GJPersonajeDTO_Get : IKeyBase, IGJPersonaje
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Img { get; set; } = string.Empty;
        public int Id_Juego { get; set; }
    }
}
