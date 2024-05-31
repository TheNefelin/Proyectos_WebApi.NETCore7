using BibliotecaGuiaJuegos.Interfaces;

namespace BibliotecaGuiaJuegos.DTOs
{
    public class GJRepoGuiaDTO : IKeyBase, IGJGuia
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Orden { get; set; }
        public int Id_Juego { get; set; }
        public List<GJGuiaUsuarioDTO> GuiaUsuario { get; set; } = new List<GJGuiaUsuarioDTO>();
        public List<GJRepoAventuraDTO> Aventuras { get; set; } = new List<GJRepoAventuraDTO>();
    }
}
