using BibliotecaGuiaJuegos.Interfaces;

namespace BibliotecaGuiaJuegos.DTOs
{
    public class GJGuiaDTO_Get : IKeyBase, IGJGuia
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Orden { get; set; }
        public int Id_Juego { get; set; }
    }
}
