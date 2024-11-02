using System;
using System.Collections.Generic;

namespace Ganaderia_API.Models;

public partial class Remate
{
    public int Id { get; set; }

    public DateTime FechaRemate { get; set; }

    public string TipoGanado { get; set; } = null!;

    public decimal AperturaPor { get; set; }

    public string Ubicacion { get; set; } = null!;

    public string TelefonoContacto { get; set; } = null!;

    public int UsuarioId { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
