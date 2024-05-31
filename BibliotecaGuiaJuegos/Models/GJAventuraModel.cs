using BibliotecaGuiaJuegos.Interfaces;

namespace BibliotecaGuiaJuegos.Models
{
    public class GJAventuraModel : IKeyBase, IGJAventura
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public bool Importante { get; set; }
        public int Orden { get; set; }
        public int Id_Guia { get; set; }
        public GJGuiaModel GJGuia { get; set; }
        public ICollection<GJAventuraUsuarioModel> GJAventuraUsuario { get; set; }
        public ICollection<GJAventuraImgModel> GJAventuraImg { get; set; }
    }
}
