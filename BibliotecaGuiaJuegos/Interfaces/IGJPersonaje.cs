﻿namespace BibliotecaGuiaJuegos.Interfaces
{
    internal interface IGJPersonaje
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Img { get; set; }
        public int Id_Juego { get; set; }
    }
}
