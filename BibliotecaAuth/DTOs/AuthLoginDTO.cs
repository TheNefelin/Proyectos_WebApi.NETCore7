using System.ComponentModel.DataAnnotations;

namespace BibliotecaAuth.DTOs
{
    public class AuthLoginDTO
    {
        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        [MaxLength(50)]
        public string Clave { get; set; } = string.Empty;
    }
}
