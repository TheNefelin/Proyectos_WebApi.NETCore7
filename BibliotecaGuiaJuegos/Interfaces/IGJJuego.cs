namespace BibliotecaGuiaJuegos.Interfaces
{
    internal interface IGJJuego
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Img { get; set; }
        public bool Estado { get; set; }
    }
}
