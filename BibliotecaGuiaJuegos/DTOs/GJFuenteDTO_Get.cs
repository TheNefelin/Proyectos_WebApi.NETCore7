using BibliotecaGuiaJuegos.Interfaces;

namespace BibliotecaGuiaJuegos.DTOs
{
    public class GJFuenteDTO_Get : IKeyBase, IGJFuente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Img { get; set; } = string.Empty;
        public int Id_Juego { get; set; }
    }
}
