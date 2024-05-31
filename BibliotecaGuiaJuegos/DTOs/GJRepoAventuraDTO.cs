using BibliotecaGuiaJuegos.Interfaces;

namespace BibliotecaGuiaJuegos.DTOs
{
    public class GJRepoAventuraDTO : IKeyBase, IGJAventura
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public bool Importante { get; set; }
        public int Orden { get; set; }
        public int Id_Guia { get; set; }
        public List<GJAventuraUsuarioDTO> AventuraUsuario { get; set; } = new List<GJAventuraUsuarioDTO>();
        public List<GJAventuraImgDTO_Get> AventurasImg { get; set; } = new List<GJAventuraImgDTO_Get>();
    }
}
