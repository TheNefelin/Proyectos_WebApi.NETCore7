using BibliotecaGuiaJuegos.Interfaces;

namespace BibliotecaGuiaJuegos.Models
{
    public class GJGuiaUsuarioModel : IGJGuiaUsuario
    {
        public int Id_Guia { get; set; }
        public string Id_Usuario { get; set; } = string.Empty;
        public bool Estado { get; set; }
        public GJGuiaModel GJGuia { get; set; }
    }
}
