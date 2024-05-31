using BibliotecaGuiaJuegos.Interfaces;

namespace BibliotecaGuiaJuegos.DTOs
{
    public class GJAventuraImgDTO_Get : IKeyBase, IGJAventuraImg
    {
        public int Id { get; set; }
        public string Img { get; set; } = string.Empty;
        public int Orden { get; set; }
        public int Id_Aventura { get; set; }
    }
}
