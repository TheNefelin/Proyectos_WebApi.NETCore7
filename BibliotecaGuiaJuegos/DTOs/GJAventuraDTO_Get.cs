using BibliotecaGuiaJuegos.Interfaces;

namespace BibliotecaGuiaJuegos.DTOs
{
    public class GJAventuraDTO_Get : IKeyBase, IGJAventura
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public bool Importante { get; set; }
        public int Orden { get; set; }
        public int Id_Guia { get; set; }
    }
}
