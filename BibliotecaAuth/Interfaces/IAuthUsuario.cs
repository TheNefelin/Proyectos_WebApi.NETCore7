namespace BibliotecaAuth.Interfaces
{
    internal interface IAuthUsuario
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Usuario { get; set; }
        public string AuthHash { get; set; }
        public string AuthSalt { get; set; }
        public int IdPerfil { get; set; }
    }
}
