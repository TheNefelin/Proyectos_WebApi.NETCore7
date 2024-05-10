using BibliotecaAuth.Interfaces;

namespace BibliotecaAuth.Models
{
    public class AuthUsuarioModel : IAuthUsuario
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Usuario { get; set; } = string.Empty;
        public string AuthHash { get; set; } = string.Empty;
        public string AuthSalt { get; set; } = string.Empty;
        public int IdPerfil { get; set; }

        public AuthPerfilModel AuthPerfil { get; set; }
    }
}
