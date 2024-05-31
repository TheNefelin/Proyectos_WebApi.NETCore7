using BibliotecaGuiaJuegos.Interfaces;

namespace BibliotecaGuiaJuegos.Models
{
    public class GJJuegoModel : IKeyBase, IGJJuego
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Img { get; set; } = string.Empty;
        public bool Estado { get; set; }
        public ICollection<GJPersonajeModel> GJPersonajes { get; set; }
        public ICollection<GJFuenteModel> GJFuentes { get; set; }
        public ICollection<GJFondoImgModel> GJFondosImg { get; set; }
        public ICollection<GJGuiaModel> GJGuias { get; set; }
    }
}
