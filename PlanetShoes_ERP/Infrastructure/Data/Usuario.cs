using System.ComponentModel.DataAnnotations;

namespace PlanetShoes.Infrastructure.Data
{
    public class Usuario
    {
        [Key]
        public string? UserId { get; set; } // Chave primária
        public string? Username { get; set; } // Nome de usuário
        public string? Password { get; set; } // Senha
        public string? Email { get; set; }
        public string? DisplayName { get; set; } // Nome de exibição (opcional)
        public byte[]? ProfilePicture { get; set; } // Foto de perfil (opcional)

    }
}
