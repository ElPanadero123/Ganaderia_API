namespace Ganaderia_API.Models.DTOs
{
    public class UsuarioDTO
    {
        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Contrasena { get; set; } = null!;

        public string? Telefono { get; set; }

        public string? Ciudad { get; set; }

        public int RolId { get; set; }
    }
}
