namespace BibliotecaF1.Interfaces
{
    internal interface IF1Piloto
    {
        public string Nombre { get; set; }
        public DateTime FechaNaci { get; set; }
        public float Estatura { get; set; }
        public int Peso { get; set; }
        public int Dorsal { get; set; }
        public string UrlPerfil { get; set; }
        public bool EstaVivo { get; set; }
        public int Puntos { get; set; }
        public int IdPais { get; set; }
        public int IdEscuderia { get; set; }
    }
}
