using BibliotecaAuth.Interfaces;

namespace BibliotecaAuth.Models
{
    public class AuthPerfilModel : IAuthPerfil
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public ICollection<AuthUsuarioModel> AuthUsuarios { get; set; }
    }
}
