using BibliotecaGuiaJuegos.Interfaces;

namespace BibliotecaGuiaJuegos.Models
{
    public  class GJPersonajeModel : IKeyBase, IGJPersonaje
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Img { get; set; } = string.Empty;
        public int Id_Juego { get; set; }
        public GJJuegoModel GJJuego { get; set; }
    }
}
