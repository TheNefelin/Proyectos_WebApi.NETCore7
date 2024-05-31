using BibliotecaGuiaJuegos.Interfaces;

namespace BibliotecaGuiaJuegos.Models
{
    public class GJFondoImgModel : IKeyBase, IGJFondoImg
    {
        public int Id { get; set; }
        public string Img { get; set; } = string.Empty;
        public int Id_Juego { get; set; }
        public GJJuegoModel GJJuego { get; set; }
    }
}
