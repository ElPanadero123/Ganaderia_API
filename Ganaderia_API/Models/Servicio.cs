using System;
using System.Collections.Generic;

namespace Ganaderia_API.Models;

public partial class Servicio
{
    public int Id { get; set; }

    public string TipoServicio { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string TelefonoContacto { get; set; } = null!;

    public int UsuarioId { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
