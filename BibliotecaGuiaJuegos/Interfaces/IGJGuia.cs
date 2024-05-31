namespace BibliotecaGuiaJuegos.Interfaces
{
    internal interface IGJGuia
    {
        public string Nombre { get; set; }
        public int Orden { get; set; }
        public int Id_Juego { get; set; }
    }
}
