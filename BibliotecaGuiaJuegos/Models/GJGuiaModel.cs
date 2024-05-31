using BibliotecaGuiaJuegos.Interfaces;

namespace BibliotecaGuiaJuegos.Models
{
    public class GJGuiaModel : IKeyBase, IGJGuia
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Orden { get; set; }
        public int Id_Juego { get; set; }
        public GJJuegoModel GJJuego { get; set; }
        public ICollection<GJGuiaUsuarioModel> GJGuiaUsuario { get; set; }
        public ICollection<GJAventuraModel> GJAventura { get; set; }
    }
}
