using System;
using System.Collections.Generic;

namespace Ganaderia_API.Models;

public partial class Animale
{
    public int Id { get; set; }

    public string EspecieRaza { get; set; } = null!;

    public decimal Precio { get; set; }

    public string? Nombre { get; set; }

    public int? Edad { get; set; }

    public string Ubicacion { get; set; } = null!;

    public decimal? Peso { get; set; }

    public int UsuarioId { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
