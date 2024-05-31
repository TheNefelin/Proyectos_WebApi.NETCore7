using BibliotecaGuiaJuegos.Interfaces;

namespace BibliotecaGuiaJuegos.DTOs
{
    public class GJFondoImgDTO_Get : IKeyBase, IGJFondoImg
    {
        public int Id { get; set; }
        public string Img { get; set; } = string.Empty;
        public int Id_Juego { get; set; }
    }
}
