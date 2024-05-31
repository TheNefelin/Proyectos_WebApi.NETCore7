using BibliotecaGuiaJuegos.Interfaces;

namespace BibliotecaGuiaJuegos.Models
{
    public class GJAventuraImgModel : IKeyBase, IGJAventuraImg
    {
        public int Id { get; set; }
        public string Img { get; set; } = string.Empty;
        public int Orden { get; set; }
        public int Id_Aventura { get; set; }
        public GJAventuraModel GJAventura { get; set; }
    }
}
