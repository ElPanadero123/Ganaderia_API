using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ganaderia_API.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Precio { get; set; }

    public string? Descripcion { get; set; }

    public string Categoria { get; set; } = null!;

    public int UsuarioId { get; set; }

    public DateTime FechaCreacion { get; set; }
    [JsonIgnore]
    public virtual ICollection<CarritoItem> CarritoItems { get; set; } = new List<CarritoItem>();

    public virtual Usuario Usuario { get; set; } = null!;
}
