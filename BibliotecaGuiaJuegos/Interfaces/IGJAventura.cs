namespace BibliotecaGuiaJuegos.Interfaces
{
    internal interface IGJAventura
    {
        public string Descripcion { get; set; }
        public bool Importante { get; set; }
        public int Orden { get; set; }
        public int Id_Guia { get; set; }
    }
}
