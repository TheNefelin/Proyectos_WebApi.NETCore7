using BibliotecaGuiaJuegos.Interfaces;

namespace BibliotecaGuiaJuegos.Models
{
    public class GJAventuraUsuarioModel : IGJAventuraUsuario
    {
        public int Id_Aventura { get; set; }
        public string Id_Usuario { get; set; } = string.Empty;
        public bool Estado { get; set; }
        public GJAventuraModel GJAventura { get; set; }
    }
}
