namespace Ganaderia_API.Models.DTOs
{
    public class AnimaleCreateDto
    {
        public string EspecieRaza { get; set; } = null!;
        public decimal Precio { get; set; }
        public string? Nombre { get; set; }
        public int? Edad { get; set; }
        public string Ubicacion { get; set; } = null!;
        public decimal? Peso { get; set; }
        public int UsuarioId { get; set; }
    }
}
